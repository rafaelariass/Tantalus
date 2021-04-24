using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedicineTwo : MonoBehaviour
{
    // The boolean value if the player is adminstering medicine
    public static bool isAdminstering = false;
    private bool hasAdministered = false;
    // The boolean value if the player has stolen the medicine
    public static bool stoleMeds = false;
    public Transform playerTransform;
    public GameObject player;
    public GameObject medicineChoice;
    public RaycastHit hit;
    public Button stealShot, giveShot, moreShot;
    public AudioClip buttonClick;
    public LevelManager lv;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        medicineChoice.SetActive(false);
        stealShot.onClick.AddListener(StealClicked);
        giveShot.onClick.AddListener(GiveClicked);
        moreShot.onClick.AddListener(MoreClicked);
        SetButtonVisibility(false);
    }

    void Update()
    {
        if (!hasAdministered)
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5.0f))
            {
                if (hit.collider.tag == "MedicineTwo")
                {
                    if (medicineChoice != null)
                    {
                        medicineChoice.SetActive(true);
                    }

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Destroy(medicineChoice);

                        isAdminstering = true;
                        PlayButtonNoise();
                        SetButtonVisibility(true);

                        lv.CompletedObjectives(gameObject.name);
                    }
                }
            }
            else
            {
                medicineChoice.SetActive(false);
            }
        }
    }

    void StealClicked()
    {

        SetButtonVisibility(false);
        isAdminstering = false;
        stoleMeds = true;
        GlobalControl.Instance.stoleMedsToday = true;
        hasAdministered = true;
    }

    void GiveClicked()
    {
        SetButtonVisibility(false);
        isAdminstering = false;
        hasAdministered = true;
        GlobalControl.Instance.stoleMedsToday = true;
    }

    void MoreClicked()
    {
        SetButtonVisibility(false);
        isAdminstering = false;
        hasAdministered = true;
        GlobalControl.Instance.stoleMedsToday = true;
    }

    void SetButtonVisibility(bool isVisible)
    {
        stealShot.gameObject.SetActive(isVisible);
        giveShot.gameObject.SetActive(isVisible);
        moreShot.gameObject.SetActive(isVisible);
    }

    void PlayButtonNoise()
    {
        AudioSource.PlayClipAtPoint(buttonClick, Camera.main.transform.position);
    }
}
