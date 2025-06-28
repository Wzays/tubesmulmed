using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    Karakter KomponenGerak;
    public Transform player;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        KomponenGerak = GameObject.Find("player (1)").GetComponent<Karakter>();
    
    }

    // Update is called once per frame
    void Update()
    {
        if(KomponenGerak.nyawa !> 0)
        {
            transform.position = new Vector3(player.position.x + offset.x,player.position.y + offset.y, offset.z );
        }
    }
}
