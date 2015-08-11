﻿using System;
using System.Collections.Generic;

public class GameLogic
{
    private const int FIELD_ROWS = 4;
    private const int FIELD_COLS = 9;

    public static byte[,] GenerateField()
    {
        byte[,] temp = new byte[GameLogic.FIELD_ROWS + 1, GameLogic.FIELD_COLS + 1];
        Random randNumber = new Random();
        for (byte row = 0; row <= GameLogic.FIELD_ROWS; row++)
        {
            for (byte column = 0; column <= GameLogic.FIELD_COLS; column++)
            {
                byte tempByte = (byte)randNumber.Next(1, 5);
                temp[row, column] = tempByte;
            }
        }
        return temp;
    }

    public static void printMatrix(byte[,] matrix)
    {
        Console.Write("    ");
        for (byte column = 0; column < matrix.GetLongLength(1); column++)
        {
            Console.Write(column + " ");
        }


        Console.Write("\n   ");
        for (byte column = 0; column < matrix.GetLongLength(1) * 2 + 1; column++)
        {
            Console.Write("-");



        }

        Console.WriteLine();

        for (byte i = 0; i < matrix.GetLongLength(0); i++)
        {
            Console.Write(i + " | ");
            for (byte j = 0; j < matrix.GetLongLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    Console.Write("  ");
                    continue;
                }



                Console.Write(matrix[i, j] + " ");
            }
            Console.Write("| ");
            Console.WriteLine();
        }

        Console.Write("   ");
        for (byte column = 0; column < matrix.GetLongLength(1) * 2 + 1; column++)
        {
            Console.Write("-");
        }
        Console.WriteLine();

    }

    public static void checkLeft(byte[,] matrix, int row, int column, int searchedItem)
    {
        int newRow = row;
        int newColumn = column - 1;
        try
        {
            if (matrix[newRow, newColumn] == searchedItem)
            {
                matrix[newRow, newColumn] = 0; checkLeft(matrix, newRow, newColumn, searchedItem);
            }
            else return;
        }
        catch (IndexOutOfRangeException)
        { return; }

    }

    public static void checkRight(byte[,] matrix, int row, int column, int searchedItem)
    {
        int newRow = row;
        int newColumn = column + 1;
        try
        {
            if (matrix[newRow, newColumn] == searchedItem)
            {
                matrix[newRow, newColumn] = 0;
                checkRight(matrix, newRow, newColumn, searchedItem);
            }
            else return;
        }
        catch (IndexOutOfRangeException)
        { return; }

    }

    public static void checkUp(byte[,] matrix, int row, int column, int searchedItem)
    {
        int newRow = row + 1;
        int newColumn = column;
        try
        {
            if (matrix[newRow, newColumn] == searchedItem)
            {
                matrix[newRow, newColumn] = 0;
                checkUp(matrix, newRow, newColumn, searchedItem);
            }
            else return;
        }
        catch (IndexOutOfRangeException)
        { return; }
    }

    public static void checkDown(byte[,] matrix, int row, int column, int searchedItem)
    {
        int newRow = row - 1;
        int newColumn = column;
        try
        {
            if (matrix[newRow, newColumn] == searchedItem)
            {
                matrix[newRow, newColumn] = 0;
                checkDown(matrix, newRow, newColumn, searchedItem);
            }
            else return;
        }
        catch (IndexOutOfRangeException)
        { return; }

    }

    public static bool change(byte[,] matrixToModify, int rowAtm, int columnAtm)
    {
        if (matrixToModify[rowAtm, columnAtm] == 0)
        {
            return true;
        }
        byte searchedTarget = matrixToModify[rowAtm, columnAtm];
        matrixToModify[rowAtm, columnAtm] = 0;
        checkLeft(matrixToModify, rowAtm, columnAtm, searchedTarget);
        checkRight(matrixToModify, rowAtm, columnAtm, searchedTarget);


        checkUp(matrixToModify, rowAtm, columnAtm, searchedTarget);
        checkDown(matrixToModify, rowAtm, columnAtm, searchedTarget);
        return false;
    }

    public static bool doit(byte[,] matrix)
    {
        bool isWinner = true;
        Stack<byte> stek = new Stack<byte>();
        int columnLenght = matrix.GetLength(0);
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int i = 0; i < columnLenght; i++)
            {
                if (matrix[i, j] != 0)
                {
                    isWinner = false;
                    stek.Push(matrix[i, j]);
                }
            }
            for (int k = columnLenght - 1; (k >= 0); k--)
            {
                try
                {
                    matrix[k, j] = stek.Pop();
                }
                catch (Exception)
                {
                    matrix[k, j] = 0;
                }
            }
        }
        return isWinner;
    }
}