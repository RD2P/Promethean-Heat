using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] private Collider2D myCollider;
    DamageDealer dealdamage;
    [SerializeField] float knockback = 4f; // this can be moved somehwere else in the future
    [SerializeField] float verticalKnockback = 1.5f; // this can be moved somehwere else in the future

    private void Start()
    {
        dealdamage = GetComponent<DamageDealer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO: Separate this because this doesn't make any sense if you put this script on an enemy it won't work they can
        // hurt themselves, right now the assumption is that the player is the only one with a weapon damage script. 
        // ideally should grab a reference to the parent object to avoid collision with self. 
        if (collision.gameObject.GetComponent<Health>() != null && collision.gameObject.tag != "Player")
        {
            Health enemyHealth = collision.gameObject.GetComponent<Health>();
            enemyHealth.DealDamage(dealdamage.DamageDealt());
            KnockbackAdjustment(collision);
             // to prevent double damage, ideally there should be a check to see if collision has already happened once. 


            // if you had a projectile
            // Destroy(gameObject);
        }
    }
    private void KnockbackAdjustment(Collider2D other)
    {
            Vector2 direction = (other.transform.position - myCollider.transform.position).normalized;
            Vector2 Updirection = (other.transform.position).normalized;

            if (other.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                //TODO if statement here to check trigger/flag on animation event to see if attack launches or not for vertical knockback
                Rigidbody2D receiver = other.gameObject.GetComponent<Rigidbody2D>();
                direction.y = verticalKnockback;
                receiver.AddForce(direction * knockback, ForceMode2D.Impulse /*+ weaponProperties.SetKnockback())*/);
                //   Debug.Log("current sitting value is " + weaponProperties.AddedKnockbackValue);
            }
        
    }

}
