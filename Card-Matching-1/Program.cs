using System;

Console.WriteLine("Hello, Card Matching");


Console.WriteLine("=== 카드 짝 맞추기 게임 ===");
Console.WriteLine();

bool isEnd = false;
string num  = null;

while(!isEnd)
{
    Console.WriteLine("\n난이도를 선택하세요:");
    Console.WriteLine("1. 쉬움 (2x4)");
    Console.WriteLine("2. 보통 (4x4)");
    Console.WriteLine("3. 어려움 (4x6)");
    Console.Write("선택: ");
    num = Console.ReadLine();
    Console.WriteLine();


    Card card = new Card(num);

    while (card.correct != 8)
    {
        card.ShowBoard();
        card.ShowCount();
        card.getCard();
        if (card.limitCount == card.tryCount)
        {
            break;
        }

        Console.Clear();

    }


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

    Console.WriteLine("새 게임을 하시겠습니까? (Y/N): ");
    string input = Console.ReadLine().ToUpper();

    if(input != "Y")
    {
        isEnd = true;
    }
}

Console.WriteLine("게임을 종료합니다.");