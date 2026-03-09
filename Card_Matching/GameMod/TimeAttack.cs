using System;
using System.Collections.Generic;
using System.Text;

class TimeAttack : IGameMod
{
    public void GameOver(CardGame card)
    {
        if (card.timer >= card.maxTimer)
        {
            card.sw.Stop();
            Console.WriteLine("=== 게임 오버! ===");
            Console.WriteLine($"제한 시간이 지났습니다!");
            Console.WriteLine($"찾은 쌍: {card.correct}/{card.cardPairCount}\n");
        }
        else
        {
            Console.WriteLine("=== 게임 클리어! ===");
            Console.WriteLine($"총 시도 횟수: {card.tryCount}");
        }
    }

    public bool GameJudge(CardGame card)
    {
        return card.timer >= card.maxTimer || card.cardPairCount == card.correct;
    }

    public void GameRule(CardGame card)
    {
        Console.WriteLine($"경과 시간: {card.timer}초 / {card.maxTimer}초 | 찾은 쌍: {card.correct}/{card.cardPairCount}");

        
    }
}