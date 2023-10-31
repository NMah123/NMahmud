// See https://aka.ms/new-console-template for more information

using BoardLogic;
using System;



    //Rules
    Console.WriteLine("Welcome to TicTacToe");
    Console.WriteLine("The rules are simple get 3 in a row to win the game");
    Console.WriteLine("You are player 1 and will be defined as X the computer is player 2 and will be defined as O");


// board is the data store for the game
 Board game = new Board();


{
     

    int userTurn = -1;
    int computerTurn = -1;
    Random rand = new Random();

    while (game.checkForWinner() == 0) {

        // don't allow the human to choose an already occupied square
        while (userTurn == -1 || game.Grid[userTurn] != 0)
        {
            Console.WriteLine("Please enter a number from 0 to 8 ");
            userTurn = int.Parse(Console.ReadLine());
            Console.WriteLine("You Typed " + userTurn);
        }
        game.Grid[userTurn] = 1;

        if (game.isBoardFull())
            break;

        //don't allow the computer to choose an already occupied square
        while(computerTurn == -1 || game.Grid[computerTurn] != 0)
        {
            computerTurn = rand.Next(9);
            
            Console.WriteLine("Computer Chooses " + computerTurn);
        }
        game.Grid[computerTurn] = 2;

        if (game.isBoardFull())
            break;

        //show the board
        printboard();

    }
    //while is done
    Console.WriteLine("Player " + game.checkForWinner() + " won the game congratulations!!");
    Console.ReadLine();
    
    void printboard()
{
        for (int i = 0; i < game.Grid.Length; i++)
        {
            // print the board
            //Console.WriteLine("Squre " + i + " contains " + board[i]);

            // put an x or o for each square
            // 0 means unoccupied. 1 = plater 1 (X) 2 = player 2 (O)
            if (i % 3 == 0)
            if (game.Grid[i] == 0)
            {
                Console.Write(".");
            }
            if (game.Grid[i] == 1)
            {
                Console.Write("X");
            }
            if (game.Grid[i] == 2)
            {
                Console.Write("O");
            }

            // print a new line every 3rd character
            if (i == 2 || i == 5 || i == 8)
            {
                Console.WriteLine();
            }


        }
    }
}