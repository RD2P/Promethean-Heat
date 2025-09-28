using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    DamageDealer dealdamage;
    void Start()
    {
        dealdamage = GetComponent<DamageDealer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            Health enemyHealth = collision.gameObject.GetComponent<Health>();
            enemyHealth.DealDamage(dealdamage.DamageDealt());
            // if you had a projectile
           // Destroy(gameObject);
        }
    }
}
