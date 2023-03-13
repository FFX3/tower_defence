using System;
using UnityEngine;
using UnityEngine.Events;

using static GridSystem;
using static GridManager;
using static Cell;

public class WaypointNode{
public Vector2 nodecoordinate;
public List<WaypointNode> forwardnodes;
public List<WaypointNode> previousnodes;

    public WaypointNode(int x, int y){
    this.nodecoordinate = new Vector2(x,y);
    this.forwardnodes = new List<WaypointNode>();
    this.previousnodes = new List<WaypointNode>();

    }

}