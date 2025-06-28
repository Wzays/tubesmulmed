using UnityEngine;

public class GemPickup : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D collider)
{
    if (collider.CompareTag("Player"))
    {
        Debug.Log("Gem triggered by: " + collider.name);
        GemsManager.Instance.AddGem(1);
        Destroy(gameObject);
    }
}
}