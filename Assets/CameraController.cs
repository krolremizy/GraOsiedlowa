using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Camera LocalCamera;
    private Vector3 prevMouse;
    private Vector2 cameraOrientation;
    public float CameraSpeed;
    public float Radius;
    // Start is called before the first frame update
    void Start()
    {
        LocalCamera = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        

        if(Input.GetMouseButton(1))
        {
            var mouseDelta = (mousePos - prevMouse) * CameraSpeed;
            cameraOrientation.x += mouseDelta.x;
            cameraOrientation.y += mouseDelta.y;
            Vector3 position = new Vector3(0, 0, -Radius);
            var orientation = Quaternion.AngleAxis(cameraOrientation.x, new Vector3(0, 1, 0)) * Quaternion.AngleAxis(cameraOrientation.y, new Vector3(-1, 0, 0));
            gameObject.transform.localRotation = orientation;
            position = orientation * position;
            gameObject.transform.position = position;

        }
        prevMouse = Input.mousePosition;
    }
}
