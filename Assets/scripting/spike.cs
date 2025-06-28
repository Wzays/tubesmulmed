using UnityEngine;

public class spike : MonoBehaviour
{
    Karakter komponengerak;
    
    // Start is called before the first frame update
    void Start()
    {
        komponengerak = GameObject.Find("player (1)").GetComponent <Karakter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){

    
        if (other.transform.tag == "Player")
        {
            komponengerak.nyawa--;
        }
    }
}