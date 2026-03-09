using System;
using System.Collections.Generic;
using System.Text;
class Survival : IGameMod
{
    public void GameOver(CardGame card)
    {
        if (card.survivalCount >= card.maxCount)
        {
            Console.WriteLine("=== 게임 오버! ===");
            Console.WriteLine($"연속으로 3번 틀렸습니다.");
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
        return card.survivalCount >= card.maxCount || card.cardPairCount == card.correct;
    }

    public void GameRule(CardGame card)
    {
        Console.WriteLine($"연속 실패: {card.survivalCount}/{card.maxCount} | 찾은 쌍: {card.correct}/{card.cardPairCount}");
    }
}