using System;
using System.Diagnostics;

Console.WriteLine("=== 카드 짝 맞추기 게임 ===");
Console.WriteLine();

bool isEnd = false;
Card card = new Card();

while (!isEnd)
{
    card.Init();

    card.CardShuffle();

    card.Preview();

    while (!isEnd) 
    {
        card.GetCard();

        // 결과 및 게임판단
        if (card.IsGameOver())
        {
            card.GameEnd();
            break;
            
        }
    }


    Console.WriteLine("새 게임을 하시겠습니까? (Y/N): ");
    string input = Console.ReadLine().ToUpper();

    if (input != "Y")
    {
        isEnd = true;
    }

}

Console.WriteLine("게임을 종료합니다.");