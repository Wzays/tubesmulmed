using UnityEngine;

public class soundControl : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip sound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(sound);
    }
}
