using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [Header("Mana")]
    [SerializeField] public int maxMana = 3;
    public int currentMana { get; private set; }
    public ManaBar manaBar;
    private Animator anim;
    private float time;
    private float timer;
    public float delayAmount;

    void Start()
    {
        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (currentMana < maxMana)
        {
            timer += Time.deltaTime;

            if (timer >= delayAmount) 
            { 
                timer = 0f;
                currentMana++;
                manaBar.slider.value = currentMana;
            }
        }
    }

    public void DecreaseMana(int amount)
    {
        currentMana = Mathf.Clamp(currentMana, 0, maxMana);
        manaBar.SetMana(currentMana);
        if (amount <= currentMana)
        {
            currentMana -= amount;
            manaBar.slider.value -= amount;
        }
    }
}
