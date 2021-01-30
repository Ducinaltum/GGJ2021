using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform obj;
    public float offX;
    public float offY;
    void Start()
    {
        transform.position = new Vector3(obj.position.x, obj.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(obj.position.x > offX || obj.position.y > offY) {
            Vector3 target = new Vector3(obj.position.x, obj.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime);
        }
    }


}
