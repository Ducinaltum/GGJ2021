using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform obj;
    public float offX;
    public float offY;

    public float offsetY = 1f;
    public float maxCameraSize; 
    public float minCameraSize; 
    public float mouseScroll;

    public Camera cam;
    void Start()
    {
        transform.position = new Vector3(obj.position.x, obj.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(obj.position.x,  obj.position.y+ offsetY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime);
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize + (-Input.mouseScrollDelta.y * mouseScroll * Time.deltaTime), minCameraSize, maxCameraSize);
    }


}
