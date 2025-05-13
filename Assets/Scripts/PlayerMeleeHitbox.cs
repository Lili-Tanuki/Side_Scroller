using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeHitbox : MonoBehaviour
{
    private Collider2D enemyInZone;
    private bool canDealDamage = false;

    private Collider2D col;

    public int damage = 2;

    private void Awake()
    {
        col = GetComponent<Collider2D>();

        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {

            enemyInZone = other;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyInZone = null;
        }
    }
    public void EnableDamageWindow() => canDealDamage = true;
    public void DisableDamageWindow() => canDealDamage = false;

    public void TriggerDamage()
    {
        Debug.Log(canDealDamage + " : Attaque BARK BARK");
        Debug.Log(enemyInZone + " : Hop je touche");

        if (canDealDamage && enemyInZone != null)
        {
            Debug.Log(" : Hop j'ai mal");

            Enemy e = enemyInZone.GetComponent<Enemy>();
            if (e != null)
            {
                e.Damage(damage);
                Debug.Log("Ennemi touché par attaque !");
                return;
            }
        }

    } 
}
