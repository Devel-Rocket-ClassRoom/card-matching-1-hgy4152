using System;
using System.Collections.Generic;
using System.Text;

abstract class GameBase
{
    protected abstract bool IsGameOver();
    protected abstract void GetStatusText();
}