using System;
using System.Collections.Generic;
using System.Text;

interface IGameMod
{
    public void GameOver(Card card);
    public void GameRule(Card card);
    public bool GameJudge(Card card);
}