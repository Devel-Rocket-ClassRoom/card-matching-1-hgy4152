using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


class Card
{
    private string[,] cardShuffle;
    public string [,] playBoard;
    public int tryCount = 0;
    public int correct = 0;
    // 보드 생성 : 난이도 조절 시 여기다가 matrix 받기
    public Card()
    {
        Console.WriteLine("카드를 섞는 중. . .\n");

        // 행렬 받을 시 곱하고 2나눠서 갯수 설정
        // j는 고정 2번
        cardShuffle = new string[4, 4];

        Random random = new Random();

        for(int i = 1; i <= 8; i++)
        {
            for(int j = 0; j <= 1; j++)
            {
                bool isCard = false;
                while(!isCard)
                {
                    int k = random.Next(0,4);
                    int l = random.Next(0,4);
                    if (cardShuffle[k,l] == null)
                    {
                        isCard = true;
                        cardShuffle[k, l] = $" [{i}]";
                    }
                }
            }
        }




        // 보이는 판 만들기
        playBoard = new string[4, 4];
        for (int i = 0; i < playBoard.GetLength(0); i++)
        {
            for (int j = 0; j < playBoard.GetLength(1); j++)
            {
                playBoard[i, j] = " ** ";
            }
        }



    }


    public void getCard()
    {
        // 첫번째 카드 선택
        Console.Write("첫 번째 카드를 선택하세요 (행 열): ");
        string[] selectCard1 = new string[2];
        selectCard1 = Console.ReadLine().Split(" ");
        // 인덱스로 쓸거니까 -1 하기
        int c1 = int.Parse(selectCard1[0]) - 1;
        int r1 = int.Parse(selectCard1[1]) - 1;

        string firstCard = cardShuffle[c1, r1];

        playBoard[c1, r1] = cardShuffle[c1, r1];

        ShowBoard();
        ShowCount();


        // 두 번째 카드 선택
        Console.Write("두 번째 카드를 선택하세요 (행 열): ");
        string[] selectCard2 = new string[2];
        selectCard2 = Console.ReadLine().Split(" ");
        int c2 = int.Parse(selectCard2[0]) - 1;
        int r2 = int.Parse(selectCard2[1]) - 1;

        string secondCard = cardShuffle[c2, r2];

        playBoard[c2, r2] = cardShuffle[c2, r2];
        tryCount++;

        ShowBoard();

        if (firstCard == secondCard)
        {
            correct++;
            Console.WriteLine("짝을 찾았습니다!");

        }
        else
        {
            Console.WriteLine("짝이 맞지 않습니다!");
            playBoard[c2, r2] = playBoard[c1, r1] = " ** ";
        }

        Thread.Sleep(1000);
    }


    public void ShowBoard()
    {
        Console.WriteLine("    1열 2열 3열 4열");

        for (int i = 0; i < playBoard.GetLength(0); i++)
        {
            Console.Write($"{i + 1}행 ");
            for (int j = 0; j < playBoard.GetLength(1); j++)
            {
                Console.Write($"{playBoard[i, j]}");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }

    public void ShowCount()
    {

        // 덱 크기에 따른 쌍
        Console.WriteLine($"시도 횟수: {tryCount} | 찾은 쌍: {correct}/{cardShuffle.GetLength(0) * cardShuffle.GetLength(1) / 2}");

    }
}

