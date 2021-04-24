using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivesScript : MonoBehaviour
{
    // The distance in which the player can interact with this object 
    public float interactableDistance = 5;
    // the player's transform component
    public Transform playerTransform;
    public static bool hasObjectives = false;
    public AudioClip notifyObjective;

    void Start()
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance < interactableDistance)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                AudioSource.PlayClipAtPoint(notifyObjective, Camera.main.transform.position);
                hasObjectives = true;
            }
        }
    }
}
