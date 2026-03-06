using System;

Console.WriteLine("Hello, Card Matching");


Console.WriteLine("=== 카드 짝 맞추기 게임 ===");
Console.WriteLine();

bool isEnd = false;

while(!isEnd)
{
    Card card = new Card();

    while (card.correct != 8)
    {
        card.ShowBoard();
        card.ShowCount();
        card.getCard();
        card.correct = 8;
    }

    Console.WriteLine("=== 게임 클리어! ===");
    Console.WriteLine($"총 시도 횟수: {card.tryCount}");

    Console.WriteLine("새 게임을 하시겠습니까? (Y/N): ");
    string input = Console.ReadLine().ToUpper();

    if(input != "Y")
    {
        isEnd = true;
    }
}

Console.WriteLine("게임을 종료합니다.");