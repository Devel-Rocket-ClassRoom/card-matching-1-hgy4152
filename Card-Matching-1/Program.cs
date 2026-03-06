using System;
using System.Diagnostics;

Console.WriteLine("Hello, Card Matching");


Console.WriteLine("=== 카드 짝 맞추기 게임 ===");
Console.WriteLine();

bool isEnd = false;
string num  = null;
string skinNum = null;
string modNum = null;


while (!isEnd)
{

    num = GameManager.SelectLevel();
    Console.WriteLine();

    skinNum = GameManager.SkinType();
    Console.WriteLine();

    modNum = GameManager.GameMod();
    Console.WriteLine();

    Card card = new Card(num, skinNum, modNum);

    

    while (card.correct != card.cardCount && !isEnd)
    {
        card.ShowBoard();
        card.getCard();
        

        isEnd = card.isEnd;
        Console.Clear();

    }

    card.EndText();
    
    Console.WriteLine("새 게임을 하시겠습니까? (Y/N): ");
    string input = Console.ReadLine().ToUpper();

    if(input != "Y")
    {
        isEnd = true;
    }
}

Console.WriteLine("게임을 종료합니다.");