using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float _impact_flash_duration = 0.3f;
    DamageDealer dealdamage;
    [SerializeField] Material _impactMat;
    [SerializeField] Material _originalMat;
    [SerializeField] float knockback = 4f; // this can be moved somehwere else in the future
    [SerializeField] float verticalKnockback = 1.5f; // this can be moved somehwere else in the future
    void Start()
    {

        // cache original sprite so impact effect doesn't break the visuals 
        if (TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))
        {
            _originalMat = spriteRenderer.material;
        }

        dealdamage = GetComponent<DamageDealer>();
    }

    private void OnEnable()
    {
        Health.onTakeDamage += Health_onTakeDamage;
    }



    private void OnDisable()
    {
        Health.onTakeDamage -= Health_onTakeDamage;
    }

    private void Health_onTakeDamage()
    {
        //TODO:
        // add a camera shake effect for feel, this should be a separate script so it can be applied to both enemies and player
        // add a timestop effect for emphasis on hit, this should be a separate script so it can be applied to both enemies and player
        PlayImpactEffect();
    }
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            Health enemyHealth = collision.gameObject.GetComponent<Health>();
            enemyHealth.DealDamage(dealdamage.DamageDealt());
            KnockbackAdjustment(collision);
            // if you had a projectile
            // Destroy(gameObject);
        }
    }

    private void KnockbackAdjustment(Collider2D other)
    {
        Vector2 direction = (other.transform.position - transform.position).normalized;
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

    public void PlayImpactEffect()
    {
        StartCoroutine(_playFlash());
        this.gameObject.GetComponent<SpriteRenderer>().material = _impactMat;
    }

    private IEnumerator _playFlash()
    {
        while (true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().material = _originalMat;

            yield return new WaitForSeconds(_impact_flash_duration);
        }
    }

}
