using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]//help facilate data from graph
public struct Link//link is the edge defines nodes at the end of node
{
    public enum direction { UNI, BI };//this defines the direction of the node uni one way bi two
    public GameObject node1;
    public GameObject node2;
    public direction dir;
}

public class WayPointMang : MonoBehaviour
{
    //define way points and graphs
    public GameObject[] waypoints;//all the sphere placed
    public Link[] links;//array of links// eg what connects to what
    public Graph graph =new Graph();//
    // Start is called before the first frame update
    void Start()
    {
        if (waypoints.Length > 0)//if there are way points
        {
            foreach (GameObject wp in waypoints)//loop through each one
            {
                graph.AddNode(wp);//add the waypoints to graph
            }
            foreach (Link l in links)// now we go through the links and add a edge between each node // uni dire
            {
                graph.AddEdge(l.node1, l.node2);
                if (l.dir == Link.direction.BI)//if the edge is bi we add another edge and swaps the nodes around
                {
                    graph.AddEdge(l.node2, l.node1);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        graph.debugDraw();
    }
}
