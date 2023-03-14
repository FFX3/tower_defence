using System;
using UnityEngine;
using UnityEngine.Events;

using static GridSystem;
using static GridManager;
using static Cell;
using static WaypointList;

[CreateAssetMenu(fileName = "Path Builder", menuName = "ScriptableObjects/GridSystems/PathBuilder", order = 1)]
public class PathBuilder: GridSystem {

    [SerializeField]
    private GameObject pathblock;

    [SerializeField]
    private WaypointList waypoints;


    public override void mount(GridManager gridManager){
    //Dire au gridManager que le pathbuilder a priorite
    //On va avoir besoin des dimensions, peut pas mettre du path outside du grid
    //Draw roads
            
    
    }

    public override void unmount(){

    }
}