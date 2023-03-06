using System;
using UnityEngine;
using UnityEngine.Events;

using static GridSystem;
using static GridManager;
using static Cell;

public class MakeCellRed: GridSystem {
    public override void mount(GridManager gridManager){
        foreach(Cell cell in gridManager.getCells()){
            cell.subscribeToClicked(this.makeCellRed);
        }
    }

    public override void unmount(){

    }

    private void makeCellRed(Cell cell){
        Debug.Log(cell.gameObject.transform.position);
        // TODO change cell color to red
    }
}