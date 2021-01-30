using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
   public ConversationsSO conversations;
   public Sprite[] charDirecions;
   Rigidbody2D body;
   float horizontal;
   float vertical;
   public float runSpeed = 20.0f;

   int lastX;
   int lastY;

   void Start()
   {
      body = GetComponent<Rigidbody2D>();
      UIController.InstanceUI.SetSimpleText("Hola!");
   }

   void Update()
   {
      horizontal = Input.GetAxisRaw("Horizontal");
      vertical = Input.GetAxisRaw("Vertical");
      //0= DR 1=UR 2=UL 3=DL

   }

   private void FixedUpdate()
   {
        Vector2 dir = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        body.velocity = dir.normalized;
   }

   void OnTriggerEnter2D(Collider2D col)
   {
      string text = conversations.randomPhrases.phrases[Random.Range(0, conversations.randomPhrases.phrases.Count-1)];
   }
}