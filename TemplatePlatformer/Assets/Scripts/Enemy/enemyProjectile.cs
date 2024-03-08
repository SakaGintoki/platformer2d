using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class enemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();

        if (collision.gameObject.tag == "Player")
            health.TakeDamage(1);

        //How to Damage playerrrrr
        Destroy(gameObject);
    }
}
