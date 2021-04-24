using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will be attached to "loot" objects and allows the player to steal this object for money
public class LootScript : MonoBehaviour
{
    // This is the dollar amount the object is worth
    public float amount = 10;
    // The distance in which the player can interact with this object 
    public float interactableDistance = 5;
    // the player's transform component
    public Transform playerTransform;

    // Sound of money when player loots
    public AudioClip lootSound;
    // Start is called before the first frame update

    public static bool isStealing;

    void Start()
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        isStealing = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance < interactableDistance)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                isStealing = true;
                LevelManager.dayWealth += amount;
                GameManager.DepositMoney(amount);
                GameManager.numberOfItemsStolen += 1;
                AudioSource.PlayClipAtPoint(lootSound, Camera.main.transform.position);
                Destroy(gameObject, 1);
            }
        }
        else
        {
            isStealing = false;
        }
    }


}
