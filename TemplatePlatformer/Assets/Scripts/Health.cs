using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 4;
    public int currentHealth;

    public HealthBar healthBar;
    private Animator anim;
    private bool dead;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(1);
        }
    }

    //awalnya void takedamage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");

                //Deactivate all attached component classes
                foreach (Behaviour component in components)
                    component.enabled = false;

                dead = true;
            }
        }
    }
}
