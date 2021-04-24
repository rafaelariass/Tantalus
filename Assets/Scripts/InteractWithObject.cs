using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// When player is within a certain disance UI pops onto the screen letting the player 
// know they can interact with an object
public class InteractWithObject : MonoBehaviour
{
    // if the player is within an interactable distance of this object
    bool withinDistance = false;
    // the type of interaction a player should have with this object: talk, steal etc
    public string interactionType = "Steal";

    public string interactionButton = "E";
    // the basic UI line 
    string interacitonLine = "Press ";
    // the distance at which the player can interact
    public float interactableDistance = 5;

    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance < interactableDistance)
        {
            withinDistance = true;
        }
        else
        {
            withinDistance = false;
        }
    }

    private void OnGUI()
    {
        if (withinDistance)
        {
            Vector2 position = new Vector2(Screen.width/2, Screen.height/2);
            Vector2 size = new Vector2(150, 30);
            Rect rect = new Rect(position, size);
            GUI.Box(rect, interacitonLine + interactionButton + " to " + interactionType);
        }
    }
}
