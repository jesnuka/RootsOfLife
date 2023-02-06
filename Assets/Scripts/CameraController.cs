using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField] float minZoom, maxZoom;
    [SerializeField] Slider zoomSlider;
    [SerializeField] Camera camera;
    [SerializeField] float border = 50f;
    [SerializeField] float xRightLimit = 0.76f; // depends on the size of the UI screen. Original was 230 of the total canvas size 960. (960-230)/960
    [SerializeField] private float movementTreshold = 5;

    [SerializeField] float _cameraSpeed;

    private float mouseOldX, mouseOldY;


    [field: SerializeField] private bool _canMove;
    public bool CanMove { get { return _canMove; } set { _canMove = value; } }

    public void OnValueChange()
    {
        camera.orthographicSize = Mathf.Lerp(minZoom, maxZoom, zoomSlider.value);
    }

    private async void Update()
    {
        if (CanMove)
            GetPlayerInput();

        mouseOldX = Input.mousePosition.x;
        mouseOldY = Input.mousePosition.y;
    }

    private void GetPlayerInput()
    {
        if (Input.mousePosition.x >= Screen.width * xRightLimit || Input.mousePosition.x < 0f || Input.mousePosition.y >= Screen.height || Input.mousePosition.y >= Screen.height)
            return;

        if (Input.mousePosition.x >= Screen.width*xRightLimit - border)
        {
            if (Mathf.Abs(Input.mousePosition.x - mouseOldX) <= movementTreshold) MoveCamera(new Vector2(_cameraSpeed, 0.0f));
        }

        if (Input.mousePosition.x <= (0 + border))
        {
            if (Mathf.Abs(Input.mousePosition.x - mouseOldX) <= movementTreshold) MoveCamera(new Vector2(-_cameraSpeed, 0.0f));
        }

        if (Input.mousePosition.y >= (Screen.height - border))
        {
            if (Mathf.Abs(Input.mousePosition.y - mouseOldY) <= movementTreshold) MoveCamera(new Vector2(0.0f, _cameraSpeed));
        }

        if (Input.mousePosition.y <= (0 + border))
        {
            if (Mathf.Abs(Input.mousePosition.x - mouseOldX) <= movementTreshold) MoveCamera(new Vector2(0.0f, -_cameraSpeed));
        }
            
    }

    private void MoveCamera(Vector2 newPosition)
    {
        // Ortho 1000 => x = 1000
        // ortho 500 => x = 1500
        // Ortho 100 => x = 2000

        // Should be Ortho  1000 = X = 800,
        // And Ortho 100 = X = 2160
        // for Y, Ortho  1000 = Y = 106
        // and Ortho 100 = Y = 1060

        // xOffset = 
        float xOffset = 1000.0f - (camera.orthographicSize) + ((1.0f - (camera.orthographicSize / 1000.0f)) * (Screen.width / 2.0f));
        // float yOffset = 1000.0f / camera.orthographicSize;
        //  float yOffset = 100.0f - ((1.0f - (camera.orthographicSize / 1000.0f)) * (Screen.height / 2.0f));
        float yOffset = 1000.0f - (camera.orthographicSize);

        float xPos = Mathf.Clamp((transform.position.x + newPosition.x), -900-xOffset, 900+xOffset);
        float yPos = Mathf.Clamp((transform.position.y + newPosition.y), -60 - yOffset, 60 + yOffset);
        Debug.Log("X val: " + 1000.0f / camera.orthographicSize);
      //  transform.position = new Vector3(xPos * ((1000.0f / camera.orthographicSize) / 2), yPos * (1000.0f / camera.orthographicSize), transform.position.z);
        transform.position = new Vector3(xPos , yPos, transform.position.z);
    }
}
