using System;
using System.Collections.Generic;
using System.Text;

class Basic : ICardSkin
{
    public ConsoleColor GetColor(string value)
    {
        return ConsoleColor.White;
    }

    public void GetDisplay(string[,] cardValue)
    {
        
    }
}
