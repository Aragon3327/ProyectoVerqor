using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class changeAnimation : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animador;
    private SpriteRenderer spriteRen;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
        spriteRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        animador.SetFloat("speed", math.abs(rb.velocity.x)+math.abs(rb.velocity.y));
        if(moveInput < 0 ){
            spriteRen.flipX = true;
        } else if (moveInput > 0){
            spriteRen.flipX = false;
        }
    }
}
