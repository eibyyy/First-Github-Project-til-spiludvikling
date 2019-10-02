using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField]
    [Range(0.5f, 10f)]
    private float forceMod;

    Rigidbody2D rb2d;
    // Start is called before the first frame update
    Animator Animator;
    SpriteRenderer sr;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalForce = Input.GetAxis("Horizontal");

        if (Mathf.Abs(rb2d.velocity.x) > 5)
        {
            Debug.Log("Du kører alt for hurtigt!");
            rb2d.velocity *= 0.95f;
        }

        if (horizontalForce != 0)
        {
            rb2d.AddForce(Vector2.right *forceMod* horizontalForce);

        }


        Animator.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        if (rb2d.velocity.x!=0)
        {
            sr.flipX = rb2d.velocity.x < 0f;
        }
    }
}
