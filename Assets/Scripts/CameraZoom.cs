using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    private float ScrollSpeed;

    float minZoom = 100, maxZoom = 1000;

    private Camera ZoomCamera;

    
    private void Start(){
        ZoomCamera = Camera.main;
    }

    void Update(){
        if (ZoomCamera.orthographic){
            ZoomCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
            ZoomCamera.orthographicSize = Mathf.Clamp(ZoomCamera.orthographicSize, minZoom, maxZoom);
        }
        else {
            ZoomCamera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        }
    }
}
