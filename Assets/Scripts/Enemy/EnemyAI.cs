using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        private NavMeshAgent agent;
        //private Transform[] waypoints;
        private int waypointIndex = 0;
        private Transform target;
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            UpdateDestination();
        }

        // Update is called once per frame
        void Update()
        {
            if (Vector3.Distance(transform.position, target.position) < 1)
            {
                IterateWaypointIndex();
                UpdateDestination();
            }
        
        }

        void UpdateDestination()
        {
            target = Waypoints.points[waypointIndex];
            agent.SetDestination(target.position);
        }

        void IterateWaypointIndex()
        {
            waypointIndex++;
            if (waypointIndex == Waypoints.points.Length)
                waypointIndex--;
        }
    }
}
