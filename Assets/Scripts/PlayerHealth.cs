using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;
    private PlayerRespawn respawnScript;

    void Start()
    {
        health = maxHealth;
        respawnScript = GetComponent<PlayerRespawn>();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            health = 0;
            if (respawnScript != null)
            {
                respawnScript.Die();
            }
            else
            {
                Debug.LogWarning("Pas de script PlayerRespawn trouvé !");
            }
        }
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > maxHealth) health = maxHealth;
    }
}
