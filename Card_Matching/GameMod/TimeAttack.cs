using System;
using System.Collections.Generic;
using System.Text;

class TimeAttack : Card, IGameMod
{
    public void GameOver(Card card)
    {
        if (card.timer >= card.maxTimer)
        {
            card.sw.Stop();
            Console.WriteLine("=== 게임 오버! ===");
            Console.WriteLine($"제한 시간이 지났습니다!");
            Console.WriteLine($"찾은 쌍: {card.correct}/{card.cardCount}\n");
        }
        else
        {
            Console.WriteLine("=== 게임 클리어! ===");
            Console.WriteLine($"총 시도 횟수: {card.tryCount}");
        }
    }

    public bool GameJudge(Card card)
    {
        return card.timer >= card.maxTimer || card.cardCount == card.correct;
    }

    public void GameRule(Card card)
    {
        Console.WriteLine($"경과 시간: {card.timer}초 / {card.maxTimer}초 | 찾은 쌍: {card.correct}/{card.cardCount}");

        
    }
}