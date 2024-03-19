using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Transform currentCheckpoint;
    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint.position; //move player to checkpoint pos
        health.respawn(); //restore health and reset anim
    }

    //Activate checkpoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform; //Store checkpoint activated as the current 
            collision.GetComponent<Collider2D>().enabled = false; //Deactivate checkpoint collider
        }
    }
}

