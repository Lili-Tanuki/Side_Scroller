using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [Header("Type d'objet")]
    public string itemName = "Gem";

    [Header("Effets")]
    public AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (pickupSound != null)
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);

            Debug.Log("Objet ramassé : " + itemName);

            Destroy(gameObject);
        }
    }
}
