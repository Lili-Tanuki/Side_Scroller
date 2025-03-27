using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCinteract : MonoBehaviour
{
    public GameObject Player;
    public GameObject DialogueBox;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;

    public float textSpeed;
    public bool playerIsClose;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (DialogueBox.activeInHierarchy)
            {
                zeroText();
                Player.GetComponent<PlayerController>().enabled = true;
            }
            else
            {
                DialogueBox.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (dialogueText.text == dialogue[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogue[index];
            }
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        DialogueBox.SetActive(false);
    }

    IEnumerator Typing()
    {
        Player.GetComponent<PlayerController>().enabled = false;
        foreach (char c in dialogue[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());

        }
        else
        {
            zeroText();
            Player.GetComponent<PlayerController>().enabled = true;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            zeroText();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;

        }
    }
}