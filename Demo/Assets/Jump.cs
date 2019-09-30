using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private GroundCheck gc;
    [SerializeField]
    private float forceMod = 10f;
    // Start is called before the first frame update
    void Start()
    {
        gc = GetComponentInChildren<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        // Hvis space bar er trykket ned denne frame...
        if (Input.GetKeyDown(KeyCode.Space) && gc.Grounded)
        {
        // Unity får fat i figuren, og får giver den krafter til at kunne hoppe impulst.
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * forceMod, ForceMode2D.Impulse);
        }
    }
}
