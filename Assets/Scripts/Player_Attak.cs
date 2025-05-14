using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attak : MonoBehaviour
{
    public GameObject normalHitbox;
    public float normalAttackDelay = 0.3f;
    private bool isAttacking = false;



    private void Start()
    {
        normalHitbox.SetActive(false);

    }

    void Update()
    {
        if (isAttacking) return;

        if (Input.GetKeyDown(KeyCode.F) || (Input.GetKeyDown(KeyCode.JoystickButton2)))
        {
            StartCoroutine(DoAttack(normalHitbox, normalAttackDelay));
        }
    }
        IEnumerator DoAttack(GameObject hitboxGO, float delay)
    {
        isAttacking = true;

        hitboxGO.SetActive(true);
        PlayerMeleeHitbox hitbox = hitboxGO.GetComponent<PlayerMeleeHitbox>();
        yield return new WaitForSeconds(0.1f);

        hitbox.EnableDamageWindow();
        hitbox.TriggerDamage();
        hitbox.DisableDamageWindow();
        yield return new WaitForSeconds(delay);

        isAttacking = false;

        hitboxGO.SetActive(false);
    }
}
