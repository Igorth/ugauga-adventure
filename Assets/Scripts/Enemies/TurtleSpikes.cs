using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleSpikes : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("Turtle Spikes")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activateTime;

    private Animator anim;

    private bool triggered; // when the turtle gets triggered
    private bool active; // when the turtle is active and can hurt the player

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!triggered)
            {
                StartCoroutine(ActivateTurtleSpikes());
            }
            if (active)
            {
                collision.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }

    private IEnumerator ActivateTurtleSpikes()
    {
        triggered = true;

        yield return new WaitForSeconds(activationDelay);
        active = true;
        anim.SetBool("activated", true);

        yield return new WaitForSeconds(activateTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}
