using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    private int currentDirection = 1;


    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
            {
                DirectionChange();
            }

        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
            {
                DirectionChange();
            }
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
        movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        //Membuat arah musuh 
        enemy.localScale = new Vector3(-Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        currentDirection = _direction;

        //Gerak kearah tersebut
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed
            , enemy.position.y, enemy.position.z);
    }

    public int GetCurrentDirection() //untuk mengetahui menghadap mana yang akan digunakan pada script enemyAttack -> enemyProjectile
    {
        return currentDirection;
    }
}
