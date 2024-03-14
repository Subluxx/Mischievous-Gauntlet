using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed = 5f;
    public float zoomFactor = 2f;
    public float defaultCameraSize = 0f;

    private Camera currentCamera;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject centerPoint;

    public int currentCharacterZoomed = 5;
    public float switchSpeed = 2f;



    void Start()
    {
        currentCamera = GetComponent<Camera>();
        defaultCameraSize = currentCamera.orthographicSize;
    }


    void Update()
    {


        if (Input.GetKeyDown(KeyCode.A))
        {
            currentCharacterZoomed = 0;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            currentCharacterZoomed = 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            currentCharacterZoomed = 2;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            currentCharacterZoomed = 3;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            currentCharacterZoomed = 5;
        }


        if (currentCharacterZoomed == 0)
        {
            ZoomOnCharacter(player1);
        }
        if (currentCharacterZoomed == 1)
        {
            ZoomOnCharacter(player2);
        }
        if (currentCharacterZoomed == 2)
        {
            ZoomOnCharacter(player3);
        }
        if (currentCharacterZoomed == 3)
        {
            ZoomOnCharacter(player4);
        }
        if (currentCharacterZoomed == 5)
        {
            ZoomOut(centerPoint);
        }




    }

    void ZoomOnCharacter(GameObject character)
    {
        float targetSize = defaultCameraSize * zoomFactor;
        if (targetSize != currentCamera.orthographicSize)
        {

            currentCamera.orthographicSize = Mathf.Lerp(currentCamera.orthographicSize,
    targetSize, Time.deltaTime * cameraSpeed);
            currentCamera.transform.position = Vector3.Lerp(currentCamera.transform.position, new Vector3(character.transform.position.x, character.transform.position.y, -10f), Time.deltaTime * switchSpeed);
        }
    }

    void ZoomOut(GameObject character)
    {
        float targetSize = defaultCameraSize;
        if (targetSize != currentCamera.orthographicSize)
        {

            currentCamera.orthographicSize = Mathf.Lerp(currentCamera.orthographicSize,
    targetSize, Time.deltaTime * cameraSpeed);
            currentCamera.transform.position = Vector3.Lerp(currentCamera.transform.position, new Vector3(character.transform.position.x, character.transform.position.y, -10f), Time.deltaTime * switchSpeed);
        }
    }





}



