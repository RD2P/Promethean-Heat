using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float _impact_flash_duration = 0.3f;
    DamageDealer dealdamage;
    [SerializeField] Material _impactMat;
    [SerializeField] Material _originalMat;
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
            // if you had a projectile
            // Destroy(gameObject);
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
