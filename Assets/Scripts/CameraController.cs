using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField] float minZoom, maxZoom;
    [SerializeField] Slider zoomSlider;
    [SerializeField] Camera camera;

    public void OnValueChange()
    {
        camera.orthographicSize = Mathf.Lerp(minZoom, maxZoom, zoomSlider.value);
    }
}
