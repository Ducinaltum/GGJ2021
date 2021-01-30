using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCaveFilter : MonoBehaviour
{
    public Transform caveIn;
    [SerializeField]
    float tinnitusAmp;
    [SerializeField]
    float maxHPFfreq = 15000;
    float maxFilterDist;

    void Start()
    {
        caveIn = GameObject.Find("Player").transform;
        maxFilterDist = Vector3.Distance(transform.position, caveIn.position);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Mathf.Clamp(Vector2.Distance(transform.position, caveIn.position), 0, maxFilterDist);
        float amount = dist / maxFilterDist * maxHPFfreq;
        AudioController.InstanceAC.SetAmbientCaveHPF(amount);
        AudioController.InstanceAC.SetTinnitusVolume(1 - dist / maxFilterDist);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            GameController.InstanceGC.UnloadCaveScene();
        }
    }
}
