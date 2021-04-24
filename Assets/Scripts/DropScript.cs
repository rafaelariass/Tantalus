using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropScript : MonoBehaviour
{
    // This is the dollar amount the object is worth
    public float amount = 50;
    // The distance in which the player can interact with this object 
    public float interactableDistance = 5;
    // the player's transform component
    public Transform playerTransform;
    // Player has dropped medicine
    private bool droppedMeds = false;
    // audio for when the player has dropped the medication
    public AudioClip moneyObtained;

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
        if (Medicine.stoleMeds)
        {
            float distance = Vector3.Distance(playerTransform.position, transform.position);
            if (distance < interactableDistance)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    AudioSource.PlayClipAtPoint(moneyObtained, Camera.main.transform.position);
                    GameManager.DepositMoney(amount);
                    LevelManager.dayWealth += amount;
                    GameManager.numberOfMedicineStolen += 1;
                    droppedMeds = true;
                    Medicine.stoleMeds = false;
                    Destroy(GetComponent<InteractWithObject>());
                }
            }
        }
    }

    private void OnGUI()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if (droppedMeds && distance < interactableDistance)
        {
            Vector2 position = new Vector2(Screen.width / 2, Screen.height / 2);
            Vector2 size = new Vector2(250, 50);
            Rect rect = new Rect(position, size);
            GUI.Box(rect, "Medicine has been placed securely.");
        }
    }
}
