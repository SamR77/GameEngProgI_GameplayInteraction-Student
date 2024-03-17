using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionObject : MonoBehaviour
{
    [Header("Used for objects that give simple info about themselves")]
    public bool info;
    public string message;
    private Text infoText;


    [Header("This Object can be picked up")]
    [Space]
    public bool pickup;

    [Header("Used for NPC Dialogue, With multiple screens")]
    [Space]
    public bool talks;                          // If this is true then our object can talk to the plyer, and have multiple lines of text
    [TextArea]
    public string[] sentences;



    public void Start()
    {
        infoText = GameObject.Find("InfoText").GetComponent<Text>();
    }


    public void Info()
    {
        //Debug.Log(message);
        StartCoroutine(ShowInfo(message, 2.5f));
    }


    public void Pickup()
    {
        //Debug.Log("You Picked " + this.gameObject.name);
        this.gameObject.SetActive(false);      
    }

    public void Talks()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(sentences);
        //Debug.Log(gameObject.name + " has nothing to say.");
    }


    IEnumerator ShowInfo(string message, float delay)
    {
        infoText.text = message;
        yield return new WaitForSeconds(delay);
        infoText.text = null;

    }




}
