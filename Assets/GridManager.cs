using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using static Cell;

public class GridManager : MonoBehaviour
{
    private List<List<GameObject>> cells;

    // Start is called before the first frame update
    void Start()
    {
        this.buildGrid();
    }

    // Update is called once per frame
    void Update()
    {
        this.checkForMouseClicks();
    }

    private void buildGrid(){
       
        this.cells = new List<List<GameObject>>();
        for (int x = 0; x < 5; x++){
            List<GameObject> column = new List<GameObject>();
            for (int y = 0; y < 5; y++){
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
