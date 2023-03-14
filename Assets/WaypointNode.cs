using System;
using System.Collections.Generic;

using UnityEngine;


public class WaypointNode{
public Vector2 coordinate;
public List<WaypointNode> forwardnodes;
public List<WaypointNode> previousnodes;

    public WaypointNode(int x, int y){
    this.coordinate = new Vector2(x,y);
    this.forwardnodes = new List<WaypointNode>();
    this.previousnodes = new List<WaypointNode>();

    }

}