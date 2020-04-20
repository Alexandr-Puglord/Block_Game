using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Made by Alexandr Pokorskiy and Tyler Labelle
public class Block : MonoBehaviour
{

    public Vector3 Rotation_Point;

    public static int Height = 20;
    public static int Width = 10;

    private float Previous_Time;
    private float Fall_Time = 1f;

    private static Transform[,] Grid = new Transform[Width, Height];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) //Contoll to move block Left
        {
            transform.position += new Vector3(-1,0,0);//this is a check to see if the move is legal
            if (!Valid())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }else if (Input.GetKeyDown(KeyCode.RightArrow)) //Control to move block right
        {
            transform.position += new Vector3(1, 0, 0);//this is a check to see if the move is legal
            if (!Valid())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) //this is where it rotates the block 90 degrees
        {
            transform.RotateAround(transform.TransformPoint(Rotation_Point), new Vector3(0,0,1), 90);//this is a check to see if the move is legal
            if (!Valid())
            {
                transform.RotateAround(transform.TransformPoint(Rotation_Point), new Vector3(0, 0, 1), -90);
            }
        }
        
        if (Time.time - Previous_Time >(Input.GetKey(KeyCode.DownArrow) ? Fall_Time / 10 : Fall_Time)) //this is a combination, it is both a control to move block down and a timer that mves the block down 
            //with the help of one grid move down per frame (that is basically what it does but there are other ways)
        {
            transform.position += new Vector3(0, -1, 0);
            if (!Valid())
            {
                transform.position -= new Vector3(0, -1, 0); //this is a check to see if the move is legal
                Add(); //the following only happens is Valid returns true. 
                Check();
                this.enabled = false; //this will stop the block from all movement when it hits the botom of the grid
                FindObjectOfType<Spawn>().NewBlock();
            }
            Previous_Time = Time.time; //this is just a small aspect that helps the block not fall into infinity 
            //basically prevents the game from doing 60 frames per second (its really technical but it helps to save the block from oblivion)
        }
    }

    void Add()
    {
        foreach(Transform mino in transform) 
        {
            int xRound = Mathf.RoundToInt(mino.transform.position.x);
            int yRound = Mathf.RoundToInt(mino.transform.position.y);

            Grid[xRound, yRound] = mino;

        }
    }

    void Check()
    {
        for (int i = Height -1; i >= 0; i--) //this checks every grid level in the Y axis aka Height
        {
            if (Line(i))//this will check if a grid width line is full if true then the following methods execute
            {
                Delete(i);
                MoveDown(i);
            }
        }
    }

    bool Line(int i) //scans the Grid Line to see if its full 
    {
        for (int j = 0; j < Width; j++) //goes over width of the grid
        {
            if (Grid[j, i] == null) //if the grid incomplete or empty it returns false
            {
                return false;
            }
        }
        return true;//otherwise return true and that means it is full 
    }

    void Delete(int i)//this deletes a line 
    {
        for (int j = 0; j < Width; j++) //this go through the whole grid line one block at a time
        {
            Destroy(Grid[j, i].gameObject); //this destroys the block game objects on that grid line
            Grid[j, i] = null; //this sets the line as null
        }
    }

    void MoveDown(int i)//Moves down the block down whena  line is cleared 
    {
        for(int y = i; y < Height; y++) //goes through each hieght
        {
            for(int j = 0; j < Width; j++)//goes through each width level
            {
                if(Grid[j,y] != null) //if the grid is not null it does the following
                {
                    Grid[j, y - 1] = Grid[j, y]; //this sets that the current grid level and goes down by one and turns into the new current grid level
                    Grid[j, y] = null; //now it is null
                    Grid[j, y - 1].transform.position -= new Vector3(0, 1, 0); //this allowos all the grid levels to move down wia a transform.position 
                }
            }
        }
    }

    bool Valid() //checks the validity of the move
    {
        foreach(Transform child in transform)
        {
            int xRound = Mathf.RoundToInt(child.transform.position.x); //this is meant to round up the position of the current block in the X axis 
            int yRound = Mathf.RoundToInt(child.transform.position.y); //this is meant to round up the position of the current block in the Y axis 

            if (xRound < 0 || xRound >= Width || yRound < 0 || yRound >= Height) //this makes sure that the block doesn't go out of the set up grid of 10 X 20
            {
                return false;
            }
            if(Grid[xRound,yRound] != null) 
            {
                return false;
            }
        }

        return true;
    }
}
