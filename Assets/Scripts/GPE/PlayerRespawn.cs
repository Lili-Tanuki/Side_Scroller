using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PlayerRespawn : MonoBehaviour
{
    public float respawnDelay = 0.5f;

    private Vector3 initialPosition;
    private SpriteRenderer sr; // pour peut-être fade le joueur plus tard

    private void Start()
    {
        initialPosition = transform.position;
        sr = GetComponent<SpriteRenderer>();
    }

    public void Die()
    {
        StartCoroutine(RespawnWithFade());
    }

    IEnumerator RespawnWithFade()
    {
        // Fade out (on garde le joueur visible pendant le noir)
        if (ScreenFader.instance != null)
            yield return ScreenFader.instance.FadeOut().WaitForCompletion();

        // On cache le joueur PENDANT l'écran noir
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<PlayerController>().enabled = false;

        yield return new WaitForSeconds(respawnDelay);

        // Respawn
        Vector3 checkpoint = CheckpointManager.instance != null ? CheckpointManager.instance.GetCheckpoint() : initialPosition;
        transform.position = checkpoint;
        GetComponent<PlayerHealth>().health = GetComponent<PlayerHealth>().maxHealth;

        // Réaffiche le joueur AVANT le fade in
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<PlayerController>().enabled = true;

        if (ScreenFader.instance != null)
            yield return ScreenFader.instance.FadeIn().WaitForCompletion();
    }


}
