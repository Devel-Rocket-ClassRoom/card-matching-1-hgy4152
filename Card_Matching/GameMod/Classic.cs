using System;
using System.Collections.Generic;
using System.Text;

class Classic : Card, IGameMod
{
    public void GameOver(Card card)
    {
        if (card.limitCount == card.tryCount)
        {
            Console.WriteLine("=== 게임 오버! ===");
            Console.WriteLine($"시도 횟수를 모두 사용 했습니다.");
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
        return card.tryCount >= card.limitCount || card.cardCount == card.correct;
    }

    public void GameRule(Card card)
    {
        Console.WriteLine($"시도 횟수: {card.tryCount} | 찾은 쌍: {card.correct}/{card.cardCount}");
    }
}