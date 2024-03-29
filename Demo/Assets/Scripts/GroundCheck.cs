﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    Animator Animator;
    public bool Grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Col er bare et navn for collider
    // Når jeg rammer min collider, som i dette tilfælde bliver kaldt "ground".
    // Der er altid en type hvilket er collider2D, men der er også et navn til collideren fx "Hanne".
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Ground"))
        {
            Grounded = true;
            Animator.SetBool("Jump", false);
        }
    }
    //Når du så trykker mellemrum skal du exit din trigger.
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            Grounded = false;
            Animator.SetBool("Jump", true);
        }
    }
    //Når du lander på jorden skal din trigger blive på.
    void OnTriggerStay2D(Collider2D col)
    {
        
        OnTriggerEnter2D(col);
    }
    

}
