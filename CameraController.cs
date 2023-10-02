using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera PlayerCamera;
    public bool isLocked;
    public Vector3 OffSet;
    public float Zoom;

    public float moveSpeed = 10f;
    public float boundaryDistance = 25f;

    public float minFOV;
    public float maxFOV;
    public float scrollSpeed;

    void Start()
    {
        PlayerCamera = Camera.main;
    }

    void Update()
    {
        ToggleMode();
        AdjustFOV();

        if (isLocked)
        {
            FollowPlayer();
        }
        else
        {
            MoveCameraOnScreenEdge();
        }
    }

    void FollowPlayer()
    {
        PlayerCamera.transform.position = transform.position + OffSet;
    }

    void ToggleMode()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            isLocked = !isLocked;
        }
    }

    void MoveCameraOnScreenEdge()
    {
        Vector3 cursorPosition = Input.mousePosition;

        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        if (cursorPosition.x < boundaryDistance)
        {
            PlayerCamera.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
        }
        else if (cursorPosition.x > screenWidth - boundaryDistance)
        {
            PlayerCamera.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
        }
        if (cursorPosition.y < boundaryDistance)
        {
            PlayerCamera.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
        }
        else if (cursorPosition.y > screenHeight - boundaryDistance)
        {
            PlayerCamera.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        }
    }

    void AdjustFOV()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        float newFOV = PlayerCamera.fieldOfView - scrollInput * scrollSpeed;

        newFOV = Mathf.Clamp(newFOV, minFOV, maxFOV);

        PlayerCamera.fieldOfView = newFOV;
    }
}