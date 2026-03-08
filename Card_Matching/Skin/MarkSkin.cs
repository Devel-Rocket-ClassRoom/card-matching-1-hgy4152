using System;
using System.Collections.Generic;
using System.Text;

class MarkSkin : ICardSkin
{


    public ConsoleColor GetColor(string value)
    {
        switch (value)
        {
            case "★":
                return ConsoleColor.Yellow;
            case "♠":
                return ConsoleColor.Blue;
            case "♥":
                return ConsoleColor.Red;
            case "♦":
                return ConsoleColor.Green;
            case "♣":
                return ConsoleColor.Cyan;
            case "●":
                return ConsoleColor.Magenta;
            case "■":
                return ConsoleColor.White;
            case "▲":
                return ConsoleColor.DarkYellow;
            case "♛":
                return ConsoleColor.DarkBlue;
            case "♜":
                return ConsoleColor.DarkGreen;
            case "♚":
                return ConsoleColor.DarkRed;
            case "♝":
                return ConsoleColor.DarkCyan;
            default:
                return ConsoleColor.White;

        }
    }

    public void GetDisplay(string[,] cardValue)
    {

        for(int i = 0; i < cardValue.GetLength(0);i++) 
        {
            for(int j = 0; j < cardValue.GetLength(1);j++)
            {
                switch (cardValue[i,j])
                {
                    case "1":
                        cardValue[i, j] = "★";
                        break;
                    case "2":
                        cardValue[i, j] = "♠";
                        break;
                    case "3":
                        cardValue[i, j] = "♥";
                        break;
                    case "4":
                        cardValue[i, j] = "♦";
                        break;
                    case "5":
                        cardValue[i, j] = "♣";
                        break;
                    case "6":
                        cardValue[i, j] = "●";
                        break;
                    case "7":
                        cardValue[i, j] = "■";
                        break;
                    case "8":
                        cardValue[i, j] = "▲";
                        break;
                    case "9":
                        cardValue[i, j] = "♛";
                        break;
                    case "10":
                        cardValue[i, j] = "♜";
                        break;
                    case "11":
                        cardValue[i, j] = "♚";
                        break;
                    case "12":
                        cardValue[i, j] = "♝";
                        break;
                    default:
                        cardValue[i, j] = "None";
                        break;
                }
            }

        }


    }
}