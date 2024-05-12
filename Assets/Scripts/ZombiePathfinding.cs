using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiePathfinding : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    private Transform Waypointlist;
    private Transform currWaypoint;
    private GameObject player;
    public float DamageDealt;

    int m_CurrentWaypointIndex;
    int m_MaxWaypointIndex;

    // used assignment 2 ghost pathfinding script as a base
    void Start()
    {
        // sets first destination to the first waypoint
        Waypointlist = GameObject.Find("Waypoints").transform;
        currWaypoint = Waypointlist.GetChild(0).gameObject.transform;
        m_MaxWaypointIndex = Waypointlist.childCount;

        navMeshAgent.SetDestination(currWaypoint.position);
    }

    void Update()
    {
        // checks if the remaining distance is less than that of the given stopping distance and checks that the current index will not go above the max distance of the transform array
        if ((navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance))
        {
            if (m_CurrentWaypointIndex + 1 == m_MaxWaypointIndex)
            {
                // Finds the player GameObject and decreases health
                GameObject player = GameObject.Find("Player");
                player.GetComponent<playerdata>().currHealth -= DamageDealt;
                gameObject.SetActive(false);
            }
            else
            {
                m_CurrentWaypointIndex = m_CurrentWaypointIndex + 1;
                currWaypoint = Waypointlist.GetChild(m_CurrentWaypointIndex).gameObject.transform;
                navMeshAgent.SetDestination(currWaypoint.position);
            }
        }
    }
}
