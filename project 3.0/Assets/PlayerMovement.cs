using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class NewBehaviourScript : MonoBehaviour {
    [SerializeField] private float xspeed;
    [SerializeField] private float yspeed;
    private Rigidbody2D body;
    private int jumpCounter;
    private Animator anim;
    private SpriteRenderer sprite;  
    private int num = 0;
    private int counter = 0;

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
        jumpCounter = 0;
        yspeed = 5;
        sprite = GetComponent<SpriteRenderer>(); 
        anim = GetComponent<Animator>();
        sprite.flipX = true;
    }

    // Update is called once per frame
    void Update() {
        counter++;
        if (counter == 100) {
            counter = 0;
            num++;
        }
        
        //moving on horizontal axis
        float h = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(h*xspeed,body.velocity.y);
        //jumping
        if (Input.GetButtonDown("Jump") && jumpCounter == 0) {
            body.velocity = new Vector2(body.velocity.x, yspeed);
            jumpCounter = 1;
        }
        else if (body.velocity.y == 0) jumpCounter = 0;
        if (h > 0) {
            sprite.flipX = true;
            num = 0;
        }
        else if (h < 0) {
            sprite.flipX = false;
            num = 0;
        }
        anim.SetInteger("Wait Time", num);
        anim.SetFloat("Speed", Mathf.Abs(h));
    }
}
