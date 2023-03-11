using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

using static Cell;
using static GridSystem;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private List<GridSystem> systems;
    private List<List<GameObject>> cells;

    [SerializeField]
    private int gridWidth;
    [SerializeField]
    private int gridHeight;

    // Start is called before the first frame update
    void Start()
    {
        this.buildGrid();
        this.mountSystems();
        
    }

    // Update is called once per frame
    void Update()
    {
        this.checkForMouseClicks();
    }

    public List<Cell> getCells(){
        return this.cells.SelectMany(x=>x).ToList().ConvertAll<Cell>(x=>x.GetComponent<Cell>());
    }

    public void mountSystems(){
        foreach(GridSystem system in this.systems){
            system.mount(this);
        }
    }

    private void buildGrid(){
       
        this.cells = new List<List<GameObject>>();
        for (int x = 0; x < this.gridWidth; x++){
            List<GameObject> column = new List<GameObject>();
            for (int y = 0; y < this.gridHeight; y++){
                column.Add(this.buildCell(new Vector2(x, y)));
            }
            this.cells.Add(column);
        }
    }

    private GameObject buildCell(Vector2 position){
        GameObject cell = new GameObject(); 
        cell.transform.parent = this.transform;
        BoxCollider2D collider = cell.AddComponent<BoxCollider2D>();
        collider.size = Vector2.one;
        cell.AddComponent<Cell>();
        cell.transform.position = position;
        return cell;
    }

    private void checkForMouseClicks(){
        if(Input.GetMouseButtonDown(0)){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            foreach(GameObject cell in this.cells.SelectMany(x=>x).ToList()){
                if(cell.GetComponent<BoxCollider2D>().OverlapPoint(mousePosition)){
                    cell.GetComponent<Cell>().invokeClicked();
                    break;
                }
            }
        }
    }
}
