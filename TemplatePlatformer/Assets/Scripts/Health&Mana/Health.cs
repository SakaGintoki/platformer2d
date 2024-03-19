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
    private bool hurt;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    private float timer;
    public float delayAmount;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        anim = GetComponent<Animator>();
    }

    //awalnya void takedamage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            hurt = true;
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

    public void backToIdle()
    {
        hurt = false;
        anim.SetBool("hurt", false);
    }

    public void generateHealth()
    {
        while (currentHealth != maxHealth)
        {
            currentHealth++;
            healthBar.slider.value = currentHealth;
        }
    }

    public void destroy()
    {
        Destroy(gameObject);
    }

    public void respawn() //test
    {
        dead = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        anim.ResetTrigger("die");
        anim.Play("Idle");
        foreach (Behaviour component in components)
            component.enabled = true;
    }
}
