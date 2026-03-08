using System;
using System.Collections.Generic;
using System.Text;

class AlphabetSkin : ICardSkin
{


    public ConsoleColor GetColor(string value)
    {

        switch (value)
        {
            case "A":
                return ConsoleColor.Yellow;
            case "B":
                return ConsoleColor.Blue;
            case "C":
                return ConsoleColor.Red;
            case "D":
                return ConsoleColor.Green;
            case "E":
                return ConsoleColor.Cyan;
            case "F":
                return ConsoleColor.Magenta;
            case "G":
                return ConsoleColor.White;
            case "H":
                return ConsoleColor.DarkYellow;
            case "I":
                return ConsoleColor.DarkBlue;
            case "J":
                return ConsoleColor.DarkGreen;
            case "K":
                return ConsoleColor.DarkRed;
            case "L":
                return ConsoleColor.DarkCyan;
            default:
                return ConsoleColor.White;


        }

    }

    public void GetDisplay(string[,] cardValue)
    {
        for (int i = 0; i < cardValue.GetLength(0); i++)
        {
            for (int j = 0; j < cardValue.GetLength(1); j++)
            {
                switch (cardValue[i, j])
                {
                    case "1":
                        cardValue[i, j] = "A";
                        break;
                    case "2":
                        cardValue[i, j] = "B";
                        break;
                    case "3":
                        cardValue[i, j] = "C";
                        break;
                    case "4":
                        cardValue[i, j] = "D";
                        break;
                    case "5":
                        cardValue[i, j] = "E";
                        break;
                    case "6":
                        cardValue[i, j] = "F";
                        break;
                    case "7":
                        cardValue[i, j] = "G";
                        break;
                    case "8":
                        cardValue[i, j] = "H";
                        break;
                    case "9":
                        cardValue[i, j] = "I";
                        break;
                    case "10":
                        cardValue[i, j] = "J";
                        break;
                    case "11":
                        cardValue[i, j] = "K";
                        break;
                    case "12":
                        cardValue[i, j] = "L";
                        break;
                    default:
                        cardValue[i, j] = "None";
                        break;
                }
            }

        }



    }
}