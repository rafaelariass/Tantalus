using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMNPC : MonoBehaviour
{
    public enum FSMStates
    {
        Idle, Patrol, Talk
    }

    public FSMStates currentState;
    public float speed = 3;
    public float talkDistance = 8;
    public GameObject player;

    GameObject[] wanderPoints;
    Animator[] anim;
    Vector3 nextDestination;

    int currentDestinationIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        wanderPoints = GameObject.FindGameObjectsWithTag(gameObject.name + "Waypoints");
        anim = gameObject.GetComponentsInChildren<Animator>();
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case FSMStates.Patrol:
                UpdatePatrol();
                break;
            case FSMStates.Talk:
                UpdateTalk();
                break;
        }

    }

    void UpdatePatrol()
    {
        foreach(Animator a in anim)
        {
            a.SetInteger("animState", 1);
        }
       

        if (Vector3.Distance(transform.position, nextDestination) < 1)
        {
            FindNextPoint();
        }
        else if (Vector3.Distance(transform.position, player.transform.position) <= talkDistance)
        {
            currentState = FSMStates.Talk;
        }

        FaceTarget(nextDestination);

        transform.position = Vector3.MoveTowards(transform.position, nextDestination, speed * Time.deltaTime);
    }

    void UpdateTalk()
    {
        foreach (Animator a in anim)
        {
            a.SetInteger("animState", 0);
        }

        if (Vector3.Distance(transform.position, player.transform.position) > talkDistance)
        {
            currentState = FSMStates.Patrol;
        }

        FaceTarget(player.transform.position);
    }

    void Initialize()
    {
        currentState = FSMStates.Patrol;
        FindNextPoint();
    }

    void FindNextPoint()
    {
        nextDestination = wanderPoints[currentDestinationIndex].transform.position;

        currentDestinationIndex = (currentDestinationIndex + 1) % wanderPoints.Length;
    }

    void FaceTarget(Vector3 target)
    {
        Vector3 directionToTarget = (target - transform.position).normalized;
        directionToTarget.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 10 * Time.deltaTime);
    }
}
