using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private bool isShieldActive = false;
    [SerializeField] private bool hasShield = true;
    [SerializeField] private float shieldDuration = 30f;
    [SerializeField] private Collider2D shieldCollider;
    [SerializeField] private SpriteRenderer shieldSprite;
    // Start is called before the first frame update
    void Start()
    {
        isShieldActive = false;
        shieldCollider.enabled = false;
        shieldSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ActivateShield();
        }

    }

    public void AddShield()
    {
        hasShield = true;
    }

    private void ActivateShield()
    {
        if (hasShield && !isShieldActive)
        {
            Debug.Log("activate shield");
            isShieldActive = true;
            shieldCollider.enabled = true;
            shieldSprite.enabled = true;
            Invoke("DeactivateShield", shieldDuration);
        }
    }

    private void DeactivateShield()
    {
        isShieldActive = false;
        shieldCollider.enabled = false;
        shieldSprite.enabled = false;
        hasShield = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (isShieldActive)
        {
            enemyProjectile enemyProjectile = collision.GetComponent<enemyProjectile>();
            if (enemyProjectile != null)
            {
                Destroy(enemyProjectile.gameObject);
            }
        }
    }


}
