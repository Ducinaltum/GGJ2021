using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMovement : MonoBehaviour
{
    public float amplitude, freq;
    float elapsedTime = 0;
    Vector3 startPos;
    void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Mathf.Sin((2*Mathf.PI/freq) * elapsedTime) * amplitude;
        transform.localPosition = new Vector3(startPos.x, startPos.y + move, startPos.z);
        elapsedTime += Time.deltaTime;
    }
}
