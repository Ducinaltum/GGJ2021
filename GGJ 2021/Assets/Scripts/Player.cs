using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    public ConversationsSO conversations;
    public Sprite[] charDirecions;
    Rigidbody2D body;
    float horizontal;
    float vertical;
    public float runSpeed = 20.0f;
    public AudioClip[] clips;
    float accumulatedTime;
    float nextScream;
    AudioSource auso;

    int lastX;
    int lastY;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        auso = GetComponent<AudioSource>();
        nextScream = Random.Range(1f, 5f);
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        //0= DR 1=UR 2=UL 3=DL      
        if (accumulatedTime > nextScream)
        {
            accumulatedTime = 0;
            auso.PlayOneShot(clips[Random.Range(0, clips.Length - 1)]);
        }
        accumulatedTime += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Vector2 dir = new Vector2(horizontal, vertical);
        body.velocity = dir.normalized * runSpeed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        string text = conversations.randomPhrases.phrases[Random.Range(0, conversations.randomPhrases.phrases.Count - 1)];
    }
}