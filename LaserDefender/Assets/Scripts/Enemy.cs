using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private float health = 100;
    [SerializeField] private int scoreValue = 150;

    [Header("Shooting")]
    [SerializeField] private float minTimeBetweenShots = 0.2f;
    [SerializeField] private float maxTimeBetweenShots = 3f;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileSpeed = 10f;

    [Header("Effects")]
    [SerializeField] private GameObject explosionParticles;
    [SerializeField] private float particleDestruction = 1f;
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] [Range(0,1)] private float deathSoundVolume = 0.7f;
    [SerializeField] private AudioClip shootSFX;
    [SerializeField] [Range(0, 1)] private float shootSoundVolume = 0.5f;


    private float shotCounter;

    private void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        var laser = Instantiate(projectile, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position, shootSoundVolume);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) return;
        if (damageDealer != null)
        {
            ProcessHit(damageDealer);
        }
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.Damage;
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameSession.Instance.AddToScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(explosionParticles, transform.position, transform.rotation);
        Destroy(explosion, particleDestruction);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSoundVolume);
    }
}
