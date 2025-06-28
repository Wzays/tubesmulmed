using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 40f;
    public int damage = 10;
    public float maxDistance = 10f; // Jarak maksimum sebelum peluru hancur
    private Vector2 startPos;
    public Rigidbody2D rb;

    void Start()
    {
        startPos = transform.position;
        rb.linearVelocity = transform.right * speed;
    }

    void Update()
    {
        float distanceTraveled = Vector2.Distance(startPos, transform.position);
        if (distanceTraveled >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
             Destroy(gameObject);

        }
       
    }
}