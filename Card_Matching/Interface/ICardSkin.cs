using System;
using System.Collections.Generic;
using System.Text;
interface ICardSkin
{
    void GetDisplay(string[,] cardValue);
    ConsoleColor GetColor(string value);
}
