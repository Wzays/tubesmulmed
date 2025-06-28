using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    public Animator animator; // Ganti nama variabel agar lebih sesuai

    private bool isDead = false;

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("Die"); // Trigger animasi mati
        GetComponent<Collider2D>().enabled = false; // Opsional: agar tidak kena peluru lagi
        Destroy(gameObject, 1.5f); // Tunggu animasi selesai
    }
}