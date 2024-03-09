using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class enemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 direction;

    // Set the direction of the projectile when it's instantiated
    public void SetDirection(Vector3 _direction)
    {
        direction = _direction;
    }

    void Update()
    {
        // Move the projectile in the set direction
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();

        if (collision.gameObject.CompareTag("Player"))
            health.TakeDamage(1);

        Destroy(gameObject);
    }
}