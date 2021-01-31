using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeiserGroupController : MonoBehaviour
{
    HeiserHole[] heisers;
    AudioClip[] clips;
    AudioClip wrongClip;
    int indexForWrong;

    public bool hasBeenCleared;
    void Start()
    {
        indexForWrong = Random.Range(0, heisers.Length);
        List<HeiserHole> lHeisers = new List<HeiserHole>(heisers);
        lHeisers[indexForWrong].SetClip(wrongClip);
        lHeisers[indexForWrong].isWrong = true;
        lHeisers.Remove(lHeisers[indexForWrong]);
        for(int i = lHeisers.Count; i > 0; i--){
            int element = Random.Range(0, lHeisers.Count-1);
            lHeisers[element].SetClip(clips[i-1]);
            lHeisers.Remove(lHeisers[element]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToNext(){
        //transform.parent.gameObject.GetComponent<HeiserMainController>.ClearClearanceInAll();
        hasBeenCleared = true;
    }
    public void GoToStart(){
        //transform.parent.gameObject.GetComponent<HeiserMainController>.ClearClearanceInAll();
    }
    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.name == "Player"){

        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.name == "Player"){

        }
    }
}
