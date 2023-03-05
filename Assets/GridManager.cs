using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       GameObject manager = this.transform.gameObject; 
       
        
        for (int x = 0; x < 5; x++){
            for (int y = 0; y < 5; y++){
                GameObject newCell = new GameObject(); 
                newCell.transform.parent = manager.transform;
                BoxCollider2D collider = newCell.AddComponent<BoxCollider2D>();
                collider.size = Vector2.one;
                newCell.transform.position = new Vector2(x,y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
