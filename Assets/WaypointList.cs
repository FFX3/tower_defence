using System;
using System.Collections.Generic;

using UnityEngine;

using static WaypointNode;
using static WaypointSegmentCrawler;

public class WaypointList{
    public WaypointNode head;
    private List<WaypointNode> deadends;

    private Dictionary<string, WaypointNode> nodeByCoordinate;

    public WaypointList(){
        var head = new WaypointNode(0,0);
        this.deadends = new List<WaypointNode>();
        this.head = head;
        this.deadends.Add(head);
        this.nodeByCoordinate = new Dictionary<string, WaypointNode>();
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
        int past_position_on_axis;
        if(is_x_axis){
            past_position_on_axis = (int) deadend.coordinate.x;
        } else {
            past_position_on_axis = (int) deadend.coordinate.y;
        }
        var new_position_on_axis = past_position_on_axis+movement_on_axis;
        if(this.deadends[0].previousnodes.Count != 0){
            var deadendsPreviousNode = deadend.previousnodes[0];
            int deadend_previous_node_position_on_axis;
            if(is_x_axis){
                deadend_previous_node_position_on_axis = (int) deadendsPreviousNode.coordinate.x;
            } else {
                deadend_previous_node_position_on_axis = (int) deadendsPreviousNode.coordinate.y;
            }
            if(past_position_on_axis != deadend_previous_node_position_on_axis){
                if(Mathf.Clamp(new_position_on_axis - past_position_on_axis, 0, 1) 
                   == Mathf.Clamp(deadend_previous_node_position_on_axis - past_position_on_axis, 0, 1)) {
                    throw new Exception("Cannot backtrack");
                }
            }
        }

        WaypointNode newWaypointNode; 
        Vector2 newCoordinate;
        if(is_x_axis) {
            newCoordinate = new Vector2(new_position_on_axis, (int) deadends[0].coordinate.y);
        } else {
            newCoordinate = new Vector2((int) deadends[0].coordinate.x, new_position_on_axis);
        }

        string dictionaryKey = newCoordinate.x + "_" + newCoordinate.y;
        if(this.nodeByCoordinate.ContainsKey(dictionaryKey)){
            newWaypointNode = this.nodeByCoordinate[dictionaryKey];
        } else {
            newWaypointNode = new WaypointNode((int) newCoordinate.x, (int) newCoordinate.y);
            this.nodeByCoordinate.Add(dictionaryKey, newWaypointNode);
        }

        newWaypointNode.previousnodes.Add(deadend);
        deadend.forwardnodes.Add(newWaypointNode);
        this.deadends[0] = newWaypointNode;
    }

    public static IEnumerable<WaypointNode> GetSegmentHeads(WaypointNode start) {
        var currentNode = start;
        while(currentNode.forwardnodes.Count > 0) {
            if(currentNode.forwardnodes.Count == 1) {
                var crawler = new WaypointSegmentCrawler(currentNode);
                foreach(var node in crawler.Crawl()){
                    currentNode = node;
                    yield return node;
                }
            } else {
                currentNode = currentNode.forwardnodes[0];
                yield return currentNode;
            }
        }
    }

    public static IEnumerable<WaypointNode> TraversePath(WaypointNode start){
        var currentNode = start;
        while(currentNode.forwardnodes.Count > 0) {
                currentNode = currentNode.forwardnodes[0];
                yield return currentNode;
            
        }
    }
}