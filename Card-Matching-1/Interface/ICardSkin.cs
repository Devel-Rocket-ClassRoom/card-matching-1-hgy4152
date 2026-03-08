using System;
using System.Collections.Generic;
using System.Text;
interface ICardSkin
{
    string GetDisplay(int cardValue);
    ConsoleColor GetColor(string cardValue);
}
