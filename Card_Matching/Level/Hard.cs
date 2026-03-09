using System;
using System.Collections.Generic;
using System.Text;

class Hard : IGameLevel
{
    public string[,] CardDeck(CardGame card)
    {
        Console.WriteLine("카드를 섞는 중. . .\n");
        // j는 고정 2번
        string[,] cardDeck = new string[4, 6];

        Random random = new Random();

        for (int i = 1; i <= 12; i++)
        {
            for (int j = 0; j <= 1; j++)
            {
                bool isCard = false;
                while (!isCard)
                {
                    int k = random.Next(0, 4);
                    int l = random.Next(0, 6);
                    if (cardDeck[k, l] == null)
                    {
                        isCard = true;
                        cardDeck[k, l] = $"{i}";
                    }
                }
            }
        }

        // 조건 설정
        card.SetGame(30, 12, 2);



        return cardDeck;
    }
}
