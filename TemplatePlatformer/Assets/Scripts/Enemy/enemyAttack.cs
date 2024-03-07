using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float damage;
    [SerializeField] private BoxCollider2D boxCollider;
    private float cooldownTimer = Mathf.Infinity;

    private void Update()
    {
        cooldownTimer = Time.deltaTime;

        //Attack only when player in sight?
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                //attack
            }
        }

    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 
            0, Vector2.left);
        return false;
    }
}
