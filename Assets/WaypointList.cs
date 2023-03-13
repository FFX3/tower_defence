using System;
using UnityEngine;
using UnityEngine.Events;

using static GridSystem;
using static GridManager;
using static Cell;
using static WaypointNode;


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
        var deadend = this.deadends[0];
        if(this.deadends[0].previousnodes.length != 0){

            
            var deadendsPreviousNode = deadends.previousnodes[0];
            if(deadend.nodecoordinate.x != deadendsPreviousNode.nodecoordinate.x){
                if(Math.Clamp(newx - deadend.nodecoordinate.x) == Math.Clamp(deadendsPreviousNode.nodecoordinate.x - deadend.nodecoordinate.x)) {
                    throw new Exception("Cannot backtrack");
                }
            }
        }

        WaypointNode newWaypointNode = new WaypointNode(newx, deadends.nodecoordinate.y);
        newWaypointNode.previousnodes.Add(deadend);
        deadend.forwardnodes.Add(newWaypointNode);
        this.deadends[0] = newWaypointNode;
    }

}