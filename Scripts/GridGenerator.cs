using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    //Line Object(just to organize)
    public GameObject emptyGameObject;
    //Cell Object
    public GameObject cell;
    //Counter of X cells (Used to name them)
    private int iCell;
    //Counter of Y cells (Used to name them)
    private int jCell;
    //size of the cell
    public float objectSize;
    //Size of screen
    public float screenSizeWidth;
    public float screenSizeHeight;
    
    void Start()
    {
        //create a matrix based on cell and screen size
        for (float i = objectSize/2; i <= screenSizeWidth - objectSize/2; i+=objectSize)
        {
            //Instantiate the column
            var newEmpty = Instantiate(emptyGameObject, transform);
            //Name the column
            newEmpty.name = "X: " + iCell;
            for (float j = objectSize/2; j <= screenSizeHeight - objectSize/2 ; j+=objectSize)
            {
                //Instantiate cell
                var newCell = Instantiate(cell, newEmpty.transform);
                //Set cell position
                newCell.transform.position = new Vector2(i, j);
                //Name the cell
                newCell.name = "Y: " + jCell;
                //Defines position variables inside the cell
                newCell.GetComponent<CellComportament>().xPos = iCell;
                newCell.GetComponent<CellComportament>().yPos = jCell;
                //Randomize the cell that will be alive with 10% chance to be
                var ran = Random.Range(0, 10);
                if (ran == 0)
                {
                    newCell.GetComponent<CellComportament>().alive = true;
                }
                //Add one number to the name generator indicating that a new cell in the line will be created
                jCell += 1;
            }
            //Resets the coloumn counter that names the cells
            jCell = 0;
            //Add one number to the line name generator indicating that a new line will be created
            iCell += 1;
        }
    }
    
}
