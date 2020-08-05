using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CellComportament : MonoBehaviour
{
    
    //Cell is alive
    public bool alive;
    //Cell Position
    public int xPos;
    public int yPos;
    
    private Transform cellContainer;
    private Transform yLine;
    //List with the neighbours scripts
    //0 right 1 left 2 up 3 down 4RightUp 5LeftUp 6RightDown 7LeftDown
    public List<CellComportament> vizinhos = new List<CellComportament>();
    private bool setedAliveColor;
    //Image component of the object
    private SpriteRenderer _image;
    //Says the number of neighbours alive
    private int numberOfVizinhosVivos;
    //Says if neighbours was checked
    private bool checkVizinhos;

    //check if upper cell is alive
    private bool aliveUp;
    //Make the upper cell alive
    private bool addedUp;
    //Same for the others booleans
    private bool aliveDown;
    private bool addedDown;
    private bool aliveRight;
    private bool addedRight;
    private bool aliveLeft;
    private bool addedLeft;
    private bool aliveUpRight;
    private bool addedUpRight;
    private bool aliveUpLeft;
    private bool addedUpLeft;
    private bool aliveDownRight;
    private bool addedDownRight;
    private bool aliveDownLeft;
    private bool addedDownLeft;
    

    //If this cell is alive this will be true
    public bool aliveBool;

    //If the cells will move for some direction one of these will be true
    private bool moveRight;
    private bool moveUp;
    private bool moveDown;
    private bool moveLeft;

    private void Start()
    {
        //Get the image component
        _image = GetComponent<SpriteRenderer>();
        //Get the GameObject that is container of all cells and lines
        cellContainer = transform.parent.parent;
        //Get the line container that this cell is in
        yLine = transform.parent;
        //Initialize number of neighbours
        numberOfVizinhosVivos = 0;
        //Calls the function that set number of neighbours
        SetVizinhos();
    }
    
    

    private void Update()
    {
        //make borders for the world
        if(xPos == 0 || yPos == 0 || yPos == 39 || xPos == 63)
        {
            _image.color = Color.cyan;
            return;
        }
        //Passes between all Vizinhos(list) components.
        //Make the alive ones that isn't showing that are alive shows it.
        for(int i = 0; i < vizinhos.Count; i++)
        {
            //If neighbour in question is alive
            if (vizinhos[i].alive)
            {
                //check the position by the number and check if the neighbour position cell is alive, if isn't...
                if (i == 0 && !aliveRight)
                {
                    //... than make it alive
                    aliveRight = true;
                }
                //And goes on for each check who is this neighbour...
                else if (i == 1 && !aliveLeft)
                {
                    aliveLeft = true;
                }
                else if (i == 2 && !aliveUp)
                {
                    aliveUp = true;
                }
                else if (i == 3 && !aliveDown)
                {
                    aliveDown = true;
                }
                else if (i == 4 && !aliveUpRight)
                {
                    aliveUpRight = true;
                }
                else if (i == 5 && !aliveUpLeft)
                {
                    aliveUpLeft = true;
                }
                else if (i == 6 && !aliveDownRight)
                {
                    aliveDownRight = true;
                }
                else if (i == 7 && !aliveDownLeft)
                {
                    aliveDownLeft = true;
                }
            }
            //If isn't alive
            else
            {
                //Check if the cell in question is with alive status, if is...
                if (i == 0 && aliveRight)
                {
                    //...than make it dead
                    aliveRight = false;
                }
                //And goes on for each check who is this neighbour...
                else if (i == 1 && aliveLeft)
                {
                    aliveLeft = false;
                }
                else if (i == 2 && aliveUp)
                {
                    aliveUp = false;
                }
                else if (i == 3 && aliveDown)
                {
                    aliveDown = false;
                }
                else if (i == 4 && aliveUpRight)
                {
                    aliveUpRight = false;
                }
                else if (i == 5 && aliveUpLeft)
                {
                    aliveUpLeft = false;
                }
                else if (i == 6 && aliveDownRight)
                {
                    aliveDownRight = false;
                }
                else if (i == 7 && aliveDownLeft)
                {
                    aliveDownLeft = false;
                }
            }
        }
        
        //Make the count of neighbours
        //if neighbour is alive
        if (aliveUp)
        {
            //check if already added the alive neighbour
            if (!addedUp)
            {
                //if don't added...
                //...add one to the neighbour cont
                numberOfVizinhosVivos += 1;
                addedUp = true;
            }
        }
        //if is dead
        else
        {
            //check if already removed the alive neighbour
            if (addedUp)
            {
                //if don't removed...
                //...remove one in the neighbour count
                numberOfVizinhosVivos -= 1;
                addedUp = false;
            }
        }

        //and do the same for the others neighbours
        if (aliveDown)
        {
            if (!addedDown)
            {
                numberOfVizinhosVivos += 1;
                addedDown = true;
            }
        }
        else
        {
            if (addedDown)
            {
                numberOfVizinhosVivos -= 1;
                addedDown = false;
            }
        }
        
        if (aliveRight)
        {
            if (!addedRight)
            {
                numberOfVizinhosVivos += 1;
                addedRight = true;
            }
        }
        else
        {
            if (addedRight)
            {
                numberOfVizinhosVivos -= 1;
                addedRight = false;
            }
        }
        
        if (aliveLeft)
        {
            if (!addedLeft)
            {
                numberOfVizinhosVivos += 1;
                addedLeft = true;
            }
        }
        else
        {
            if (addedLeft)
            {
                numberOfVizinhosVivos -= 1;
                addedLeft = false;
            }
        }
        
        if (aliveUpLeft)
        {
            if (!addedUpLeft)
            {
                numberOfVizinhosVivos += 1;
                addedUpLeft = true;
            }
        }
        else
        {
            if (addedUpLeft)
            {
                numberOfVizinhosVivos -= 1;
                addedUpLeft = false;
            }
        }
        
        if (aliveUpRight)
        {
            if (!addedUpRight)
            {
                numberOfVizinhosVivos += 1;
                addedUpRight = true;
            }
        }
        else
        {
            if (addedUpRight)
            {
                numberOfVizinhosVivos -= 1;
                addedUpRight = false;
            }
        }
        
        if (aliveDownLeft)
        {
            if (!addedDownLeft)
            {
                numberOfVizinhosVivos += 1;
                addedDownLeft = true;
            }
        }
        else
        {
            if (addedDownLeft)
            {
                numberOfVizinhosVivos -= 1;
                addedDownLeft = false;
            }
        }
        
        if (aliveDownRight)
        {
            if (!addedDownRight)
            {
                numberOfVizinhosVivos += 1;
                addedDownRight = true;
            }
        }
        else
        {
            if (addedDownRight)
            {
                numberOfVizinhosVivos -= 1;
                addedDownRight = false;
            }
        }
        
        //If J keyboard button was pressed, changes the geration(hereditary) of cells
        if (Input.GetKeyDown(KeyCode.J))
        {
            GenerateCells();
        }

        //Set randomly one bool that moves the alives cells;
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (aliveBool)
            {
                alive = true;
                var ran = Random.Range(0, 5);
                if(ran == 0)
                {
                    moveUp = true;
                }
                else if (ran == 1)
                {
                    moveDown = true;
                }
                else if (ran == 2)
                {
                    moveRight = true;
                }
                else if (ran == 3)
                {
                    moveLeft = true;
                }
                else if (ran == 4)
                {
            
                }
            }

            if (!aliveBool)
            {
                alive = false;
            }
        }

        //Paint the cells that died with white
        //Paint the cells that born with black
        //Change position from cells that moved
        if (Input.GetKeyDown(KeyCode.L))
        {
            //If the cell will move right
            if (moveRight)
            {
                //If the cell in right is occupied
                if (vizinhos[0].alive)
                {
                    //Cancel movement
                    return;
                }
                //If isn't occupied
                else
                {
                    //Make the right cell alive
                    vizinhos[0].alive = true;
                    //Set this cell dead
                    alive = false;
                }
            }
            //Does the same for different directions
            else if (moveLeft)
            {
                if (vizinhos[1].alive)
                {
                    return;
                }
                else
                {
                    vizinhos[1].alive = true;
                    alive = false;
                }
            }
            else if (moveUp)
            {
                if (vizinhos[2].alive)
                {
                    return;
                }
                else
                {
                    vizinhos[2].alive = true;
                    alive = false;
                }
            }
            else if (moveDown)
            {
                if (vizinhos[2].alive)
                {
                    return;
                }
                else
                {
                    vizinhos[2].alive = true;
                    alive = false;
                }
            }
        }
        //If the cell is alive
        if (alive)
        {
            //If the cell wasn't colored like an alive cell..
            if (!setedAliveColor)
            {
                //...Colorize the cell
                _image.color = Color.black;
                setedAliveColor = true;
            }
            else
            {
                //If already was, does nothing
            }
        }
        else
        {
            //Same here, but inverted
            if (setedAliveColor)
            {
                _image.color = Color.white;
                setedAliveColor = false;
            }
        }
    }

    private void GenerateCells()
    {
        //If cell is alive
        if(alive)
        {
            //If cell has less than 2 neighbours...
            if (numberOfVizinhosVivos < 2)
            {
                //...Cell will die in the next generation
                aliveBool = false;
            }
            //Else if has 2 or 3 neighbours...
            else if (numberOfVizinhosVivos == 2 || numberOfVizinhosVivos == 3)
            {
                //...Cell stays alive in the next generation
                aliveBool = true;
            }
            //Else if has 4 or more neighbours...
            else if (numberOfVizinhosVivos >= 4)
            {
                //Cell will die in the next generation
                aliveBool = false;
            }
        }
        //If is dead
        else
        {
            //If has 3 neighbours...
            if (numberOfVizinhosVivos == 3)
            {
                //Will born in the next generation
                aliveBool = true;
            }
        }
    }

    private void SetVizinhos()
    {
        //For each object in the master container
        foreach (Transform column in cellContainer)
        {
            //Variable to check the name of right side column that object is
            float xPosCheckUp = xPos + 1;
            //If the number in the name of object is equal to the XPosCheckUp.
            if (column.name == "X: " + xPosCheckUp)
            {
                //For each object in the containers inside master container
                foreach (Transform line in column)
                {
                    //Get right neighbour component
                    if (line.name == "Y: " + yPos)
                    {
                        vizinhos[0] = (line.GetComponent<CellComportament>());
                    }

                    //Get right+up neighbour component
                    else if (line.name == "Y: " + (yPos + 1))
                    {
                        vizinhos[4] = (line.GetComponent<CellComportament>());
                    }
                    //Get right+down neighbour component
                    else if (line.name == "Y: " + (yPos - 1))
                    {
                        vizinhos[5] = (line.GetComponent<CellComportament>());
                    }
                }
            }
            //Variable to check the name of left side column that object is
            float xPosCheckLeft = xPos - 1;
            if (column.name == "X: " + xPosCheckLeft)
            {
                foreach (Transform line in column)
                {
                    //Get left neighbour component
                    if (line.name == "Y: " + yPos)
                    {
                        vizinhos[1] = (line.GetComponent<CellComportament>());
                    }
                    //Get left+up neighbour component
                    else if (line.name == "Y: " + (yPos + 1))
                    {
                        vizinhos[6] = (line.GetComponent<CellComportament>());
                    }
                    //Get left+down neighbour component
                    else if (line.name == "Y: " + (yPos - 1))
                    {
                        vizinhos[7] = (line.GetComponent<CellComportament>());
                    }
                }
            }
        }

        //Check for the same column
        foreach (Transform line in yLine)
        {
            //Get upper neighbour component
            float yPosCheckUp = yPos + 1;
            if (line.name == "Y: " + yPosCheckUp)
            {
                vizinhos[2] = (line.GetComponent<CellComportament>());
            }
            //Get bottom neighbour component
            float yPosCheckDown = yPos - 1;
            if (line.name == "Y: " + yPosCheckDown)
            {
                vizinhos[3] = (line.GetComponent<CellComportament>());
            }
        }
    }
}
