using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCinematic : MonoBehaviour
{
    public Sprite[] arrImages;
    Queue<Sprite> images;
    public Image image;

    public GameObject player;
    void Start(){
        images = new Queue<Sprite>(arrImages);
        image = GetComponent<Image>();
        StartCoroutine(NextDraw());
    }

    IEnumerator NextDraw(){
        while (images.Count != 0){
            Sprite img = images.Dequeue();
            image.sprite = img;
            yield return new WaitForSeconds(2f);
        }
        player.SetActive(true);
        image.gameObject.SetActive(false);
        GameController.InstanceGC.StartGame();
        yield return null;
    }
}
