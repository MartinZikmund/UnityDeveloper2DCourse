using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float health = 100;

    [Header("Player movement")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float padding = 1f;

    [Header("Projectile")]
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileFiringPeriod = 0.1f;

    [Header("Death")]
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] private float deathSoundVolume = 0.7f;
    [SerializeField] private AudioClip shootSFX;
    [SerializeField] [Range(0, 1)] private float shootSoundVolume = 0.25f;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;
    private Coroutine _firingCoroutine;
    


    // Use this for initialization
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame

    void Update()
    {
        Move();
        Fire();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _firingCoroutine = StartCoroutine(FireContinously());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(_firingCoroutine);
        }
    }

    private IEnumerator FireContinously()
    {
        while (true)
        {
            var laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position, shootSoundVolume);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector2(0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector2(1, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector2(0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector2(0, 1)).y - padding;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageDealer = other.gameObject.GetComponent<DamageDealer>();
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
        FindObjectOfType<Level>().LoadGameOver();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSoundVolume);
    }
}
