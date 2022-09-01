using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicScript : MonoBehaviour
{
    private Characters[,] GameBoard;
    private int movementsIterator;  //As there is no way to win before 4 characters (2 for each player), for better performens let's count them
    private bool somebodyWin = false; // On start nobody wins
    private void OnEnable()
    {
        EventManagerScript.buttonPressed += PlayerPressButton;
    }
    private void OnDisable()
    {
        EventManagerScript.buttonPressed -= PlayerPressButton;
    }
    private void Start()
    {
        GameBoard = new Characters[3,3];
        movementsIterator = 0;
        MakeBoardClear();
    }
    private void MakeBoardClear()
    {
        for (int i = 0; i <= 2; i++)
        {
            for (int j = 0; j <= 2; j++)
            {
                GameBoard[i, j] = Characters.N;
            }
        }
    }
    // true - o, false - x
    public void PlayerPressButton(int x, int y, bool whoIsNow)
    {
        ShowMeBoard(); //For testing, also correct by Debuging

        AddToBoard(x, y, whoIsNow);

        movementsIterator++;
        Debug.Log("This is : " + movementsIterator + " move.");
        if (movementsIterator > 4)
        {
            LookForWinner();
            LookForDraw();
   
        }

    }
    private void AddToBoard(int x, int y, bool whoIsNow)
    {
        if (whoIsNow)
        {
            GameBoard[x, y] = Characters.O;
        }
        else if (!whoIsNow)
        {
            GameBoard[x, y] = Characters.X;
        }
    }
    private void LookForWinner()
    {

        //Go diagonally from right up
        if (GameBoard[0,0] == GameBoard[1, 1] && GameBoard[1, 1] == GameBoard[2, 2] && (GameBoard[2, 2] == Characters.X || GameBoard[2, 2] == Characters.O))
        {
            ProclineTheWinner(GameBoard[2, 2]);
            somebodyWin = true;
            Debug.Log("THE WINNER IS: " + GameBoard[2, 2]);
        }

        //Diagonally from bottom right
        if (GameBoard[2, 0] == GameBoard[1, 1] && GameBoard[1, 1] == GameBoard[0, 2] && (GameBoard[0, 2] == Characters.X || GameBoard[0, 2] == Characters.O))
        {
            ProclineTheWinner(GameBoard[0, 2]);
            somebodyWin = true;
            Debug.Log("THE WINNER IS: " + GameBoard[0, 2]);
        }
        //look in rows
        for (int i = 0; i <= 2; i++)
        {
            //If there is the same character in row             AND         We have there X or O, then we have winner
            if (GameBoard[i,0] == GameBoard[i, 1] && GameBoard[i, 1] == GameBoard[i, 2] && (GameBoard[i, 2] == Characters.X || GameBoard[i, 2] == Characters.O))
            {
                ProclineTheWinner(GameBoard[i, 2]);
                somebodyWin = true;
                Debug.Log("THE WINNER IS: " + GameBoard[i,2]);
                break;

            } //If there is the same character in column             AND         We have there X or O, then we have winner
            else if (GameBoard[0,i] == GameBoard[1,i] && GameBoard[1,i] == GameBoard[2,i] && (GameBoard[2,i] == Characters.X || GameBoard[2,i] == Characters.O))
            {
                ProclineTheWinner(GameBoard[2, i]);
                somebodyWin = true;
                Debug.Log("THE WINNER IS: " + GameBoard[2,i]);
                break;
            }            
        }

    }
    private void ProclineTheWinner(Characters winner)
    {
        if (winner == Characters.O)
        {
            EventManagerScript.GetWinner(true);
        }
        else if (winner == Characters.X)
        {
            EventManagerScript.GetWinner(false);
        }
    }
    private void ShowMeBoard()
    {
        Debug.Log("1. " + GameBoard[0, 0] + " " + GameBoard[0, 1] + " " + GameBoard[0, 2]);
        Debug.Log("2. " + GameBoard[1, 0] + " " + GameBoard[1, 1] + " " + GameBoard[1, 2]);
        Debug.Log("3. " + GameBoard[2, 0] + " " + GameBoard[2, 1] + " " + GameBoard[2, 2]);
    }
    void LookForDraw()
    {

        if (!somebodyWin && movementsIterator >= 9)
        {
            EventManagerScript.SetDraw();
            Debug.Log("Nobody wins"); 
        }

    }




    

}
