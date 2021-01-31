using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeiserMainController : MonoBehaviour
{
    HeiserGroupController[] groups;
    GameObject[] fog;
    int actual;
    void Start(){
        groups[0].enabled = true;
    }

    public void ClearClearanceInAll(){
        actual = 0;
        foreach (HeiserGroupController heiserGroup in groups)
        {
            heiserGroup.hasBeenCleared = false;
        }
    }

    public void NextChallenge(){
        groups[actual].enabled = false;
        fog[actual].SetActive(false);
        actual++;
        if(actual < groups.Length){
            groups[actual].enabled = true;
        }
        else this.enabled = false;
    }
}
