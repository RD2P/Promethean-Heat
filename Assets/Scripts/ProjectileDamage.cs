using UnityEngine;

public class ProjectileLogic : MonoBehaviour
{
    DamageDealer dealdamage;
    [SerializeField] float knockback = 4f; // this can be moved somehwere else in the future
    [SerializeField] float verticalKnockback = 1.5f; // this can be moved somehwere else in the future
    [SerializeField] float fireballLifetime = 4f;
    // Ability idea : projectiles that can bounce across environment picking up speed, leaves 'fire zone' where it hits and on final impact explodes into smaller fireballs? fast ball
    private void Start()
    {
        dealdamage = GetComponent<DamageDealer>();
    }

    private void Update()
    {
        fireballLifetime -= Time.deltaTime;
        if(fireballLifetime < 0) // cleanup the fireball after sometime assuming it didn't hit an enemy. 
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO: Separate this because this doesn't make any sense if you put this script on an enemy it won't work they can
        // hurt themselves, right now the assumption is that the player is the only one with a weapon damage script. 
        // ideally should grab a reference to the parent object to avoid collision with self. 
        if (collision.gameObject.tag != "Enemy") { return; }
        else
        {
            if (collision.gameObject.GetComponent<Health>() != null)
            {
                Health enemyHealth = collision.gameObject.GetComponent<Health>();
                Debug.Log("Name of thing I just his is " + enemyHealth.gameObject.name);
                enemyHealth.DealDamage(dealdamage.DamageDealt());
                KnockbackAdjustment(collision);
                // to prevent double damage, ideally there should be a check to see if collision has already happened once. 

                Destroy(gameObject);
            }
        }
    }
    private void KnockbackAdjustment(Collider2D other)
    {
        Vector2 direction = (other.transform.position - this.transform.position).normalized;
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
