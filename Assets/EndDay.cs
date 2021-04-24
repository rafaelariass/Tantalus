using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDay : MonoBehaviour
{
    GameObject manager;

    // The distance in which the player can interact with this object 
    public float interactableDistance = 5;
    // the player's transform component
    public Transform playerTransform;
    public static bool hasObjectives = false;
    public AudioClip notifyObjective;

    // Start is called before the first frame update
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
        manager = GameObject.FindGameObjectWithTag("LevelManager");
        LevelManager lvlmanager = manager.GetComponent<LevelManager>();

        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance < interactableDistance)
        {
            if (Input.GetKeyDown(KeyCode.E) && lvlmanager.isLevelWon())
            {
                lvlmanager.dayDuration = 1.0f;
            }
        }
    }
}
