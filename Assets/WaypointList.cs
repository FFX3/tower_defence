using System;
using System.Collections.Generic;

using UnityEngine;

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

    public void AddWaypoint(int x, int y){
        if(x!=0 && y!=0){
            throw new Exception("A Waypoint's x and y are both non-null");
        }
        if(x==0 && y==0){
            throw new Exception("A Waypoint's x and y are both null");
        }
        bool is_x_axis = x!=0;
        var currentAxis = is_x_axis ? "x" : "y";
        var perpendicularAxis = is_x_axis ? "y" : "x";
        int movement_on_axis = is_x_axis ? x : y;

        var deadend = this.deadends[0];
        var past_position_on_axis = (int) deadend.coordinate.GetType().GetProperty(currentAxis).GetValue(deadend.coordinate, null);
        var new_position_on_axis = past_position_on_axis+movement_on_axis;
        if(this.deadends[0].previousnodes.Count != 0){
            var deadendsPreviousNode = deadend.previousnodes[0];
            var deadend_previous_node_position_on_axis = (int) deadendsPreviousNode.coordinate.GetType().GetProperty(currentAxis).GetValue(deadendsPreviousNode.coordinate, null);
            if(past_position_on_axis != deadend_previous_node_position_on_axis){
                if(Mathf.Clamp(new_position_on_axis - past_position_on_axis, 0, 1) 
                   == Mathf.Clamp(deadend_previous_node_position_on_axis - past_position_on_axis, 0, 1)) {
                    throw new Exception("Cannot backtrack");
                }
            }
        }

        WaypointNode newWaypointNode; 
        if(is_x_axis) {
            newWaypointNode = new WaypointNode(new_position_on_axis, (int) deadends[0].coordinate.y);
        } else {
            newWaypointNode = new WaypointNode((int) deadends[0].coordinate.x, new_position_on_axis);
        }

        newWaypointNode.previousnodes.Add(deadend);
        deadend.forwardnodes.Add(newWaypointNode);
        this.deadends[0] = newWaypointNode;
    }

}