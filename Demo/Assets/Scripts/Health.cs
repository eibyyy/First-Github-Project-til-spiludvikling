using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatEvent : UnityEvent<float> { }

public class Health : MonoBehaviour
{
    //Hvad er det nu den grønne tekst betyder?
    public UnityEvent deathEvent;
    public FloatEvent healEvent;
    public FloatEvent damageEvent;

    [SerializeField] //Hvad gør denne linje?
    [Range(20, 200)] //Hvad gør denne linje?
    private int health = 100;

    /* Immunity */

    //Formålet med denne variabel er at man kan lave et flueben man kan tænde eller slukke for på enemies eller spillere, for at de kan blive immune.
    [SerializeField]
    private bool EnableImmunity = false;

    [SerializeField]
    private float immunityTime = 1.0f;

    private bool _curImmune = false;
    /* </Immunity */

    // Start is called before the first frame update
    void Awake()
    {
        deathEvent = new UnityEvent();
        healEvent = new FloatEvent();
        damageEvent = new FloatEvent();

        damageEvent.AddListener(TakeDamage);

    }

    /// <summary>
    /// Hvad gør denne funktion?
    /// </summary>
    /// <param name="damageRecieved">Hvad gør denne parameter?</param>
    private void TakeDamage(float damageRecieved)
    {
        //Check om vi er immune:
        if (!EnableImmunity ||(EnableImmunity &&!_curImmune) )
        {
            health -= (int)damageRecieved;
            if (health <= 0)
            {
                deathEvent.Invoke();
            }
            if (EnableImmunity)
            {
                StartCoroutine(ImmunityTimer(immunityTime));
            }
        }
        //Slå immune til her:

    }
    IEnumerator ImmunityTimer(float seconds)
    {
        _curImmune = true;
        yield return new WaitForSeconds(seconds);
        _curImmune = false;
    }
}
