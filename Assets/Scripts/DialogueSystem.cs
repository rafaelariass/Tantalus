using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public float interactableDistance = 10.0f;
    private float distance;
    public GameObject player;
    public string[] sentences;
    public string[] secondarySentences; 
    public Text DialogueText;
    public Text nameText;
    public GameObject dialogueBox;
    public GameObject nameBox;
    public GameObject dialogueCanvas;
    public RaycastHit hit;
    public AudioClip buttonClick;

    public string name;
    public int count;


    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        // gets the distance between the player and another object
        distance = Vector3.Distance(player.transform.position, transform.position);
        
        if (!Medicine.isAdminstering)
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactableDistance))
            {
                if (hit.collider.tag == "Medicine" && GlobalControl.Instance.stoleMedsYesterday && hit.collider.name == name)
                {
                    DisplayDialogue(secondarySentences);
                    print("secondary");
                }
                if ((hit.collider.tag == "NPC" || hit.collider.tag == "Medicine") && hit.collider.name == name)
                {
                    DisplayDialogue(sentences);
                    print("primary");
                }
            }
            else
            {
                if (!GlobalControl.Instance.stoleMedsYesterday)
                {
                    if (count >= sentences.Length - 1)
                    {
                        count = 0;
                    }
                }
                else
                {
                    if (count >= secondarySentences.Length - 1)
                    {
                        count = 0;
                    }
                }
                dialogueBox.SetActive(false);
                nameBox.SetActive(false);
                DialogueText.text = "";
                nameText.text = "";
            }
        }
    }

    void DisplayDialogue(string[] dialogue)
    {
        nameText.text = name;
        if (count < dialogue.Length)
        {
            dialogueBox.SetActive(true);
            nameBox.SetActive(true);
            DialogueText.text = dialogue[count];
        }
        if(count >= dialogue.Length)
        {
            dialogueBox.SetActive(false);
            nameBox.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AudioSource.PlayClipAtPoint(buttonClick, Camera.main.transform.position);
            count++;
        }
    }
}
