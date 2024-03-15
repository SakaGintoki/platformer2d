using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliff : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();

        if (collision.gameObject.CompareTag("Player"))
            health.TakeDamage(4);

        if (collision.gameObject.CompareTag("Enemy"))
            health.TakeDamage(4);
    }
}
