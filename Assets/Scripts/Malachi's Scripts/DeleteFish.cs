using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFish : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(15);
        Object.Destroy(this.gameObject);
        {

        }
    }
}
