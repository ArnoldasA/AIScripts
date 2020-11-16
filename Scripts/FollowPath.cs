using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowPath : MonoBehaviour
{
    Transform goal;
    public float speed = 5f;
   public float accuracy = 1;
    float rotspeed = 2f;
    public GameObject wpMan;
    GameObject[] wps;
   // UnityEngine.AI.NavMeshAgent agent;

    GameObject currentNode;
    int Currentwp = 0;
    Graph g;
     //Start is called before the first frame update
    void Start()
    {
        wps = wpMan.GetComponent<WayPointMang>().waypoints;
        g = wpMan.GetComponent<WayPointMang>().graph;
        //agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        currentNode = wps[0];//closet waypoint for start

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GotoHeli()
    {
        //agent.SetDestination(wps[4].transform.position);
        g.AStar(currentNode, wps[11]);
        Currentwp = 0;
    }

    public void GoToRuin()
    {
       // agent.SetDestination(wps[0].transform.position);
         g.AStar(currentNode, wps[7]);
         Currentwp = 0;
    }
    private void LateUpdate()
    {
        if (g.getPathLength() == 0 || Currentwp == g.getPathLength()) // if these two are the same you are at the end
            return;

        //the node we are closet to
        currentNode = g.getPathPoint(Currentwp);//if we are moving along the path we want to get the third node

        //if we are close enough to the current waypoint move to next
        if (Vector3.Distance(g.getPathPoint(Currentwp).transform.position, this.transform.position) < accuracy) //checks distance between our point and tank
        {
            Currentwp++;//if we are close enough we increment to a new waypoint
        }

        if (Currentwp < g.getPathLength())//if the waypoints arent at the end we carry on going
        {
            goal = g.getPathPoint(Currentwp).transform;//the goal is the waypoint transform
            Vector3 lookatGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);//where our next goal is
            Vector3 direction = lookatGoal - this.transform.position;//distance between goal and tank
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotspeed);//rotates accordingly to goal
            this.transform.Translate(0, 0, speed * Time.deltaTime); 
        }
        


    }
}
