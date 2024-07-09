using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]private float xspeed;
    [SerializeField]private float yspeed;
    private Rigidbody2D body;
    private int jumpCounter;
    private Animator anim;
    private SpriteRenderer sprite;  

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        jumpCounter = 0;
        yspeed = 10;
        sprite = GetComponent<SpriteRenderer>();
 
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //moving on horizontal axis
        float h = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(h*xspeed,body.velocity.y);
        //jumping
        if (Input.GetButtonDown("Jump") && jumpCounter == 0)  
        {
            body.velocity = new Vector2(body.velocity.x, yspeed);
            jumpCounter = 1;
        }
        if (h > 0)
        {
            anim.SetBool("HorizontalMovement", true);
            sprite.flipX = false;

        }
        else if (h < 0)
        {
            anim.SetBool("HorizontalMovement", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("HorizontalMovement", false);
        }
    }
}
