using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed = 1;
    [SerializeField] private int pindahKanan = 3; //test
    [SerializeField] private int pindahKiri = 3; //test

    private Vector3 initPosition; //test
    private Vector3 leftBound; //test
    private Vector3 rightBound; //test
    private Vector3 initScale; //test
    private bool movingRight = true; // Mulai dengan bergerak ke kanan

    private void Awake()
    {
        initPosition = enemy.position;
        initScale = enemy.localScale;

        leftBound = initPosition - new Vector3(pindahKiri, 0, 0);
        rightBound = initPosition + new Vector3(pindahKanan, 0, 0);
    }

    private void Update()
    {
        if (movingRight)
        {
            if (enemy.position.x <= rightBound.x)
                MoveInDirection(Vector3.right, pindahKanan);
            else
                DirectionChange();
        }
        else
        {
            if (enemy.position.x >= leftBound.x)
                MoveInDirection(Vector3.left, pindahKiri);
            else
                DirectionChange();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            Health health = collision.gameObject.GetComponent<Health>();

            if (collision.gameObject.CompareTag("Player"))
                health.TakeDamage(1);
    }

    private void DirectionChange()
    {
        movingRight = !movingRight;
    }

    private void MoveInDirection(Vector3 direction, int distance)
    {
        // Mengatur skala untuk menghadap arah yang benar
        enemy.localScale = new Vector3(initScale.x * -(movingRight ? 1 : -1),
            initScale.y, initScale.z);

        // Bergerak ke arah yang ditentukan sejauh 'distance'
        enemy.position += direction * Time.deltaTime * speed * distance;
    }

    public int GetCurrentDirection() //untuk mengetahui menghadap mana yang akan digunakan pada script enemyAttack -> enemyProjectile
    {
        return movingRight ? 1 : -1;
    }
}
