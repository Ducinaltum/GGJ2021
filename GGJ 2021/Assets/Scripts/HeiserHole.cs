using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HeiserHole : MonoBehaviour
{
    AudioSource auso;
    public ParticleSystem partSis;
    float accumulator;
    public float timeThreshhold;
    public bool isWrong;
    void Start()
    {
        auso = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.name == "Player"){
            auso .volume = 0;
            if(accumulator > timeThreshhold){
                if(isWrong){
                    transform.parent.gameObject.GetComponent<HeiserGroupController>().GoToNext();
                }
                else{
                    transform.parent.gameObject.GetComponent<HeiserGroupController>().GoToStart();
                }
            }
            accumulator += Time.deltaTime;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.name == "Player"){
            auso .volume = 1;
            accumulator = 0;
        }
    }

    public void SetClip(AudioClip clip){
        auso.clip = clip;
        auso.Play();
    }
}
