using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

using static GridSystem;
using static GridManager;
using static Cell;
using static WaypointList;

[CreateAssetMenu(fileName = "Path Builder", menuName = "ScriptableObjects/GridSystems/PathBuilder", order = 1)]
public class PathBuilder: GridSystem {

    [SerializeField]
    private GameObject pathblock;
    [SerializeField]
    private List<Vector2> pathbuilderinputs;
    private WaypointList waypoints;


    public override void mount(GridManager gridManager){
        //Dire au gridManager que le pathbuilder a priorite
        //On va avoir besoin des dimensions, peut pas mettre du path outside du grid
        //Draw roads

        var waypoints = new WaypointList();
        this.waypoints = waypoints;

        foreach(var coordinate in this.pathbuilderinputs){
            waypoints.AddWaypoint((int)coordinate.x, (int)coordinate.y);
        }


        //DEBUG TEST
        foreach(var waypoint in WaypointList.GetSegmentHeads(waypoints.head)) {
            Debug.Log(waypoint.coordinate);
        }
        this.BuildPath(gridManager);
    }

    private void BuildPath(GridManager gridManager){
        var previouscoordinate = this.waypoints.coordinate;
        foreach(var waypoint in WaypointList.TraversePath(this.waypoints.head)) {
            var direction = (waypoint.coordinate - previouscoordinate).Normalised();
            do while()
           GameObject path = Instantiate(this.pathblock);
        path.transform.position = waypoint.coordinate;
        }
    }

    public override void unmount(){

    }
}