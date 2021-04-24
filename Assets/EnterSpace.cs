using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterSpace : MonoBehaviour
{
    public GameObject player;
    public string spaceName;
    public LevelManager lv;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            lv.CompletedObjectives(spaceName);
        }
    }
}
