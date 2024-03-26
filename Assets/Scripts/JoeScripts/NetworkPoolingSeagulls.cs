using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Rendering;

public class NetworkPoolingSeagulls : NetworkBehaviour
{
   public static NetworkPoolingSeagulls Singleton { get; private set; }

   [SerializeField] private List<PoolConfigObject> PooledSeagullPrefabList;

   private HashSet<GameObject> _Prefabs = new HashSet<GameObject>();

   Dictionary<GameObject, ObjectPool<NetworkObject>> _PooledObjects = new Dictionary<GameObject, ObjectPool<NetworkObject>>();

   public void Awake()
   {
      if (Singleton != null && Singleton != this)
      {
         Destroy(gameObject);
      }
      else
      {
         Singleton = this;
      }
   }

   public override void OnNetworkSpawn()
   {
      //register all objects in pooled prefab list
      foreach (var configObject in PooledSeagullPrefabList)
      {
         RegisterPrefabInternal(configObject.Prefab, configObject.PrewarmCount);
      }
   }
   
   public override void OnNetworkDespawn()
   {
      // Unregisters all objects in PooledPrefabsList from the cache.
      foreach (var prefab in _Prefabs)
      {
         // Unregister Netcode Spawn handlers
         NetworkManager.Singleton.PrefabHandler.RemoveHandler(prefab);
         _PooledObjects[prefab].Clear();
      }
      _PooledObjects.Clear();
      _Prefabs.Clear();
   }
   public void OnValidate()
   {
      for (var i = 0; i < PooledSeagullPrefabList.Count; i++)
      {
         var prefab = PooledSeagullPrefabList[i].Prefab;
         if (prefab != null)
         {
            Assert.IsNotNull(prefab.GetComponent<NetworkObject>(), $"{nameof(NetworkPoolingSeagulls)}: Pooled prefab \"{prefab.name}\" at index {i.ToString()} has no {nameof(NetworkObject)} component.");
         }
      }
   }

   void RegisterPrefabInternal(GameObject prefab, int preWarmCount)
   {
      NetworkObject CreateFunc()
      {
         return Instantiate(prefab).GetComponent<NetworkObject>();
      }

      void ActionOnGet(NetworkObject networkObject)
      {
         networkObject.gameObject.SetActive(true);
      }

      void ActionOnRelease(NetworkObject networkObject)
      {
         networkObject.gameObject.SetActive(false);
      }

      void ActionOnDestroy(NetworkObject networkObject)
      {
         Destroy(networkObject.gameObject);
      }

      _Prefabs.Add(prefab);

      // Create the pool
      _PooledObjects[prefab] = new ObjectPool<NetworkObject>(CreateFunc, ActionOnGet, ActionOnRelease, ActionOnDestroy, defaultCapacity: preWarmCount);

      // Populate the pool
      var prewarmNetworkObjects = new List<NetworkObject>();
      for (var i = 0; i < preWarmCount; i++)
      {
         prewarmNetworkObjects.Add(_PooledObjects[prefab].Get());
      }
      foreach (var networkObject in prewarmNetworkObjects)
      {
         _PooledObjects[prefab].Release(networkObject);
      }

      // Register Netcode Spawn handlers
      NetworkManager.Singleton.PrefabHandler.AddHandler(prefab, new PooledPrefabInstanceHandler(prefab, this));
   }
   public NetworkObject GetNetworkObject(GameObject prefab, Vector3 position, Quaternion rotation)
   {
      var networkObject = _PooledObjects[prefab].Get();

      var noTransform = networkObject.transform;
      noTransform.position = position;
      noTransform.rotation = rotation;

      return networkObject;
   }
   public void ReturnNetworkObject(NetworkObject networkObject, GameObject prefab)
   {
      _PooledObjects[prefab].Release(networkObject);
   }

   [Serializable]
   struct PoolConfigObject
   {
      public GameObject Prefab;
      public int PrewarmCount;
   }
   class PooledPrefabInstanceHandler : INetworkPrefabInstanceHandler
   {
      GameObject _Prefab;
      NetworkPoolingSeagulls _Pool;

      public PooledPrefabInstanceHandler(GameObject prefab, NetworkPoolingSeagulls pool)
      {
         _Prefab = prefab;
         _Pool = pool;
      }

      NetworkObject INetworkPrefabInstanceHandler.Instantiate(ulong ownerClientId, Vector3 position, Quaternion rotation)
      {
         return _Pool.GetNetworkObject(_Prefab, position, rotation);
      }

      void INetworkPrefabInstanceHandler.Destroy(NetworkObject networkObject)
      {
         _Pool.ReturnNetworkObject(networkObject, _Prefab);
      }
   }

}
