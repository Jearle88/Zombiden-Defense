using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiePathfinding : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    int m_CurrentWaypointIndex;

    // used assignment 2 ghost pathfinding script as a base
    void Start()
    {
        // sets first destination to the first waypoint
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        // checks if the remaining distance is less than that of the given stopping distance and checks that the current index will not go above the max distance of the transform array
        if ((navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance) && (m_CurrentWaypointIndex + 1 < waypoints.Length))
        {
            m_CurrentWaypointIndex = m_CurrentWaypointIndex + 1;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}
