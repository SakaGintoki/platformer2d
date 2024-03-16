using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ItemHealth : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        boxCollider.enabled = false;
        
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().generateHealth();
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}
