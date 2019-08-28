using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]
    private float forceMod = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Hvis space bar er trykket ned denne frame...
        if (Input.GetKeyDown(KeyCode.Space))
        {
        // Unity får fat i figuren, og får giver den krafter til at kunne håbe impulst.s
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * forceMod, ForceMode2D.Impulse);
        }
    }
}
