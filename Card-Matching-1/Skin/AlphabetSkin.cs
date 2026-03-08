using System;
using System.Collections.Generic;
using System.Text;

class AlphabetSkin : ICardSkin
{
    private int Value;
    public ConsoleColor color;
    public string Mark { get; private set; }

    public AlphabetSkin(int value)
    {
        Value = value;
        Mark = GetDisplay(value);
    }


    public ConsoleColor GetColor(string cardValue)
    {
        switch (cardValue)
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
            default:
                return ConsoleColor.White;
        }
    }

    public string GetDisplay(int cardValue)
    {
        switch (cardValue)
        {
            case 1:
                return "A";
            case 2:
                return "B";
            case 3:
                return "C";
            case 4:
                return "D";
            case 5:
                return "E";
            case 6:
                return "F";
            case 7:
                return "G";
            case 8:
                return "H";
            default:
                return "None";
        }
    }
}