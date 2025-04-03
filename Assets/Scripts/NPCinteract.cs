using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class NPCinteract : MonoBehaviour
{
    public GameObject Player;
    public GameObject DialogueBox;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;

    public float textSpeed;
    private bool playerIsClose;

    public Sprite AizenLeGoat;
    public SpriteRenderer Receptionniste;
    public GameObject NPCRecep;
    public AudioSource Yokoso;
    public float scale = 2.0f;

    private void Start()
    {
            Yokoso.Stop();
    }
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
        if (index >= 4)
        {
            Yokoso.Play();
            Receptionniste.sprite = AizenLeGoat;
            NPCRecep.transform.localScale = new Vector3(scale, scale, scale);
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