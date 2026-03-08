using System;
using System.Collections.Generic;
using System.Text;

class MarkSkin : ICardSkin
{

    private int Value;
    public ConsoleColor color;
    public string Mark { get; private set; }
    public int number;




    public MarkSkin(int value)
    {
        Value = value;
        Mark = GetDisplay(value);
    }


    public ConsoleColor GetColor(string cardValue)
    {
        switch (cardValue)
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
            default:
                return ConsoleColor.White;
        }
    }

    public string GetDisplay(int cardValue)
    {
        switch (cardValue)
        {
            case 1:
                return "★";
            case 2:
                return "♠";
            case 3:
                return "♥";
            case 4:
                return "♦";
            case 5:
                return "♣";
            case 6:
                return "●";
            case 7:
                return "■";
            case 8:
                return "▲";
            default:
                return "None";
        }
    }
}