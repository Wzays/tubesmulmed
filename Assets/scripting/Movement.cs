using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Karakter : MonoBehaviour
{

public static Karakter Instance;
    [Header("Gerakan")]
    public float kecepatan = 5f;
    public int kecepatanLompat = 10;
    public Rigidbody2D lompat;
    public Animator anim;

    [Header("Arah & Kondisi")]
    private bool balik = false;
    private bool crouch = false;
    private float arah = 0f;

    [Header("Deteksi Tanah")]
    public bool tanah;
    public Transform deteksitanah;
    public float jangkauan;
    public LayerMask targetlayer;
    private bool prevTanah;

    [Header("Status")]
    public int nyawa = 0;
    public GameOverScreen GameOverScreen;
    public void GameOver()
    {
        GameOverScreen.Setup(nyawa);
    }
    private bool mati = false;
    public GemsManager GM;


    void Start()
    {
        lompat = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Deteksi tanah
        prevTanah = tanah;
        tanah = Physics2D.OverlapCircle(deteksitanah.position, jangkauan, targetlayer);

        if (!prevTanah && tanah)
            anim.SetBool("isJumping", false);

        // Input horizontal
        arah = Input.GetAxisRaw("Horizontal");

        // Input crouch
        crouch = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.LeftControl);
        anim.SetBool("isCrouching", crouch);

        // Lompat
        if (tanah && !crouch && Input.GetKeyDown(KeyCode.W))
        {
            lompat.linearVelocity = new Vector2(lompat.linearVelocity.x, kecepatanLompat);
            anim.SetBool("isJumping", true);
        }

        // Animasi jalan
        anim.SetBool("isWalking", arah != 0 && !crouch);

        // Balik arah visual
        if (arah > 0 && balik) balikbadan();
        else if (arah < 0 && !balik) balikbadan();

        // Cek nyawa


        if (nyawa <= 0 && !mati)
        {
            mati = true;

            lompat.linearVelocity = Vector2.zero;
            lompat.bodyType = RigidbodyType2D.Kinematic; // Biar nggak gerak lagi
            GetComponent<Collider2D>().enabled = false;  // Opsional, biar nggak kena collider lain
            GameManager.Instance.GameOver();
            Destroy(gameObject);


            // Hancurkan karakter setelah animasi selesai, misalnya 1.5 detik

        }

    }

    void FixedUpdate()
    {
        // Gerakan karakter di physics step
        if (!crouch)
            lompat.linearVelocity = new Vector2(arah * kecepatan, lompat.linearVelocity.y);
        else
            lompat.linearVelocity = new Vector2(0, lompat.linearVelocity.y);
    }

    void balikbadan()
    {
        balik = !balik;
        transform.Rotate(0f, 180f, 0f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gems"))
        {
            Destroy(other.gameObject);
            GM.gemscount++;
        }
    }
}