using System;
using System.Collections.Generic;
using System.Text;

interface IGameMod
{
    public void GameOver(CardGame card);
    public void GameRule(CardGame card);
    public bool GameJudge(CardGame card);
}