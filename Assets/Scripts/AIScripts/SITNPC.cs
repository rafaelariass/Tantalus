using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SITNPC : MonoBehaviour
{
    public enum FSMStates
    {
        Idle
    }

    public FSMStates currentState;

    public GameObject player;

    Animator[] anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponentsInChildren<Animator>();
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case FSMStates.Idle:
                UpdateIdle();
                break;
        }

    }

    void UpdateIdle()
    {
        foreach (Animator a in anim)
        {
            a.SetInteger("animState", 0);
        }
    }

    void Initialize()
    {
        currentState = FSMStates.Idle;
    }
}
 