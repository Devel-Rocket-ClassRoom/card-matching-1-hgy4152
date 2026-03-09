using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
class Easy : IGameLevel
{
    public string[,] CardDeck(CardGame card)
    {
        Console.WriteLine("카드를 섞는 중. . .\n");
        // j는 고정 2번
        string[,] cardDeck = new string[2, 4];
 
        Random random = new Random();

        for (int i = 1; i <= 4; i++)
        {
            for (int j = 0; j <= 1; j++)
            {
                bool isCard = false;
                while (!isCard)
                {
                    int k = random.Next(0, 2);
                    int l = random.Next(0, 4);
                    if (cardDeck[k, l] == null)
                    {
                        isCard = true;
                        cardDeck[k, l] = $"{i}";
                    }
                }
            }
        }
        // 조건 설정
        card.SetGame(10, 4, 5);



        return cardDeck;
    }
}