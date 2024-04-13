using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Board : MonoBehaviour
{
    public Transform board;
    public GridLayoutGroup GridLayoutGroup;
    public GameObject cell;
    public int boardsize = 10;
    public string currenturn = "x";
    public string[,] matrix;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        matrix=new string[boardsize+1,boardsize+1];
        GridLayoutGroup.constraintCount = boardsize;
        createboard();
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
    private void createboard()
    {
        for (int i = 0; i < boardsize; i++) 
        {
            for(int j = 0; j < boardsize; j++)
            {
              GameObject celltranform= Instantiate(cell,board);
              Cell cell1=celltranform.GetComponent<Cell>(); 
                cell1.row = i;
                cell1.col = j;
              matrix[i, j] = "";
            }
        }
    }
    public bool Check(int row,int col)
    {
        bool result = false;
        int count = 0;
        matrix[row, col] = currenturn;

        // Check vertically
        for (int i = row - 1; i >= 0; i--) // up
        {
            if (matrix[i, col] == currenturn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = row + 1; i < boardsize; i++) // down
        {
            if (matrix[i, col] == currenturn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        if (count + 1 >= 5)
        {
            if (IsBlockedAtBothEnds(row, col))
            {
                result = false; // If the move is blocked at both ends, set result to false
            }
            else
            {
                result = true;
            }

        }

        // Check horizontally
        count = 0;
        for (int i = col - 1; i >= 0; i--) // left
        {
            if (matrix[row, i] == currenturn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = col + 1; i < boardsize; i++) // right
        {
            if (matrix[row, i] == currenturn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        if (count + 1 >= 5)
        {
            if (IsBlockedAtBothEnds(row, col))
            {
                result = false; // If the move is blocked at both ends, set result to false
            }else
            {
                result = true;
            }
          
        }

        // Check diagonally (both directions)
        count = 0;
        for (int i = 1; row - i >= 0 && col - i >= 0; i++) // up-left
        {
            if (matrix[row - i, col - i] == currenturn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        if (IsBlockedAtBothEnds(row, col))
        {
            result = false; // If the move is blocked at both ends, set result to false
        }
        for (int i = 1; row + i < boardsize && col + i < boardsize; i++) // down-right
        {
            if (matrix[row + i, col + i] == currenturn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        if (count + 1 >= 5)
        {
            if (IsBlockedAtBothEnds(row, col))
            {
                result = false; // If the move is blocked at both ends, set result to false
            }
            else
            {
                result = true;
            }

        }

        count = 0;
        for (int i = 1; row + i < boardsize && col - i >= 0; i++) // down-left
        {
            if (matrix[row + i, col - i] == currenturn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = 1; row - i >= 0 && col + i < boardsize; i++) // up-right
        {
            if (matrix[row - i, col + i] == currenturn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        if (count + 1 >= 5)
        {
            if (IsBlockedAtBothEnds(row, col))
            {
                result = false; // If the move is blocked at both ends, set result to false
            }
            else
            {
                result = true;
            }

        }
        return result;

    }
    private bool IsBlockedAtBothEnds(int row, int col)
    {
        bool blockedAbove = row > 0 && matrix[row - 1, col] != "";
        bool blockedBelow = row < boardsize - 1 && matrix[row + 1, col] != "";

        // Check if the move is blocked horizontally (left and right)
        bool blockedLeft = col > 0 && matrix[row, col - 1] != "";
        bool blockedRight = col < boardsize - 1 && matrix[row, col + 1] != "";

        // Check if the move is blocked diagonally (up-left and down-right)
        bool blockedUpLeft = row > 0 && col > 0 && matrix[row - 1, col - 1] != "";
        bool blockedDownRight = row < boardsize - 1 && col < boardsize - 1 && matrix[row + 1, col + 1] != "";

        // Check if the move is blocked diagonally (up-right and down-left)
        bool blockedUpRight = row > 0 && col < boardsize - 1 && matrix[row - 1, col + 1] != "";
        bool blockedDownLeft = row < boardsize - 1 && col > 0 && matrix[row + 1, col - 1] != "";

        // Check if the move is blocked at both ends
        return (blockedAbove && blockedBelow) || (blockedLeft && blockedRight) || (blockedUpLeft && blockedDownRight) || (blockedUpRight && blockedDownLeft);
    }
}
