using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform player;

    private Vector3 offset;

    private Vector3 speed = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {

       player = GameObject.FindGameObjectWithTag("Player").transform;
        //Vi finder gameobjectet som vi har kaldt Player, også tager vi transformen.
        offset = transform.position - player.position;
        // Det er afstanden mellem kameraet og spilleren. 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Når vi bruger smoothdamp til kameraets position er det en slags elastik vi bruger, så kameraet ikke bare fuldstændig følger med.
        transform.position = Vector3.SmoothDamp(transform.position, offset + player.position, ref speed, 0.5f);      
    }
}
