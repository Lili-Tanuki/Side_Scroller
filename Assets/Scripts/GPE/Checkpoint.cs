using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CheckpointManager.instance.SetCheckpoint(transform.position);
            gameObject.SetActive(false);
        }
    }
}
