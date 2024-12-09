using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    float velocidad=3f; 
    Animator walk;

    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        sr=GetComponent<SpriteRenderer>();
        walk=GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        bool isMoving=false;
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x<Screen.width /2)
            {
                rb.velocity=Vector2.left*velocidad;
                sr.flipX=true;
                isMoving=true;
            }
            else
            {
                rb.velocity=Vector2.right*velocidad;
                sr.flipX=false;
                isMoving=true;
            }
        }
        walk.SetBool("isWalking", isMoving);
    }
}