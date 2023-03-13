using System;
using UnityEngine;
using UnityEngine.Events;

using static GridSystem;
using static GridManager;
using static Cell;


public class WaypointList{
private WaypointNode head;
private List<WaypointNode> deadends;
private WaypointNode currentnode;

    public WaypointList(){
    var head = new WaypointNode(0,0);
    this.head = head;
    this.deadends.Add(head);
    this.currentnode = head;
    }

    public AddWaypoint(int x, int y){
        if(x!=0 && y!=0){
            throw new Exception("A Waypoint's x and y are both non-null");
        }
        if(x==0 && y==0){
            throw new Exception("A Waypoint's x and y are both null");
        }
        bool is_x_axis = x!=0;

        var pastx = deadend.nodecoordinate.x;
        var newx = pastx+x;

        if(this.deadends[0].previousnodes.length != 0){

            var deadend = this.deadends[0]
            
            var previousnode = deadends.previousnodes[0];
            if(deadend.nodecoordinate.x != previousnode.nodecoordinate.x){
                Math.Abs(deadend.nodecoordinate.x + previousnode.nodecoordinate.x) < Math.Abs(deadend.nodecoordinate.x + newx);
            }
        }
        
    }

}