using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Vie du champignon")]
    [SerializeField] private int health = 100;

    [Header("Effet de recul")]
    public float knockbackForce = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Damage(int amount)
    {
        health -= amount;
        Debug.Log($"{gameObject.name} a pris {amount} dégâts. Vie restante : {health}");

        Vector2 knockDirection = ((Vector2)transform.position - PlayerPosition()).normalized;
        rb.AddForce(knockDirection * knockbackForce, ForceMode2D.Impulse);


        if (health <= 0)
            Die();
    }
    void Die()
    {
        Debug.Log($"{gameObject.name} est mort !");
        Destroy(gameObject);
    }

    Vector2 PlayerPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            return player.transform.position;
        return transform.position;
    }
}