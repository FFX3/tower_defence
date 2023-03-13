using System;
using UnityEngine;
using UnityEngine.Events;

using static GridSystem;
using static GridManager;
using static Cell;

[CreateAssetMenu(fileName = "Path Builder", menuName = "ScriptableObjects/GridSystems/PathBuilder", order = 1)]
public class PathBuilder: GridSystem {

    [SerializeField]
    private GameObject pathblock;

    [SerializeField]
    private List<Vector2> waypoints;


    public override void mount(GridManager gridManager){
    //Dire au gridManager que le pathbuilder a priorite
    //On va avoir besoin des dimensions, peut pas mettre du path outside du grid
    //Draw roads
            
    
    }

    public override void unmount(){

    }

    private void makeCellRed(Cell cell){
        Debug.Log(cell.gameObject.transform.position);
        GameObject ballista = Instantiate(this.redCircle);
        ballista.transform.position = cell.gameObject.transform.position;
    }
}