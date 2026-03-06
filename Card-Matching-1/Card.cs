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
    public int cardCount;

    public int limitCount = 0;

    // 행렬 받기
    int column = 4;
    int row = 4;
    // 보드 생성 : 난이도 조절 시 여기다가 matrix 받기
    public Card(string num) // string num
    {
        switch(num)
        {
            case "1":
                column = 2;
                row = 4;
                limitCount = 10;
                break;

            case "2":
                column = 4;
                row = 4;
                limitCount = 20;
                break;

            case "3":
                column = 4;
                row = 6;
                limitCount = 30;
                break;


        }
        
        Console.WriteLine("카드를 섞는 중. . .\n");

        // 행렬 받을 시 곱하고 2나눠서 갯수 설정
        // j는 고정 2번
        cardShuffle = new string[column, row];
        cardCount = (column * row) / 2;
        Random random = new Random();

        for(int i = 1; i <= cardCount; i++)
        {
            for(int j = 0; j <= 1; j++)
            {
                bool isCard = false;
                while(!isCard)
                {
                    int k = random.Next(0,column);
                    int l = random.Next(0,row);
                    if (cardShuffle[k,l] == null)
                    {
                        isCard = true;
                        cardShuffle[k, l] = $" [{i}]";
                    }
                }
            }
        }




        // 보이는 판 만들기
        playBoard = new string[column, row];
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
        int c1 = 0;
        int r1 = 0;
        int c2 = 0;
        int r2 = 0;

        string firstCard = null;
        string secondCard = null;

        while (true)
        {
            // 첫번째 카드 선택
            Console.Write("첫 번째 카드를 선택하세요 (행 열): ");
            string[] selectCard1 = new string[2];
            selectCard1 = Console.ReadLine().Split(" ");

            // 인덱스로 쓸거니까 -1 하기
            c1 = int.Parse(selectCard1[0]) - 1;
            r1 = int.Parse(selectCard1[1]) - 1;

            if (c1 >= column || r1 >= row)
            {
                Console.WriteLine("범위를 벗어납니다. 다시 선택해주세요.");
            }

            else
            {
                firstCard = cardShuffle[c1, r1];
                playBoard[c1, r1] = cardShuffle[c1, r1];
                break;
            }
        }



        ShowBoard();
        ShowCount();

        while (true)
        {
            // 두 번째 카드 선택
            Console.Write("두 번째 카드를 선택하세요 (행 열): ");
            string[] selectCard2 = new string[2];
            selectCard2 = Console.ReadLine().Split(" ");

            c2 = int.Parse(selectCard2[0]) - 1;
            r2 = int.Parse(selectCard2[1]) - 1;


            // 중복 선택 시 재선택 요청
            if (c1 == c2 && r1 == r2)
            {
                Console.WriteLine($"첫 번째 카드와 중복입니다! ({c1}, {r1})");
            }
            else if (c2 >= column || r2 >= row)
            {
                Console.WriteLine("범위를 벗어납니다. 다시 선택해주세요.");
            }
            else
            {
                secondCard = cardShuffle[c2, r2];
                playBoard[c2, r2] = cardShuffle[c2, r2];
                tryCount++;
                break;
            }

        }

        ShowBoard();

        if (firstCard == secondCard)
        {
            correct++;
            Console.WriteLine("짝을 찾았습니다!");
            Console.WriteLine();

        }
        else
        {
            Console.WriteLine("짝이 맞지 않습니다!");
            playBoard[c2, r2] = playBoard[c1, r1] = " ** ";
            Console.WriteLine();

        }

        Thread.Sleep(1000);

       
    }


    public void ShowBoard()
    {


        Console.Write("    ");

        for (int i = 0; i < playBoard.GetLength(1); i++)
        {
            Console.Write($"{i + 1}열 ");
        }
        Console.WriteLine();

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
        Console.WriteLine($"시도 횟수: {tryCount} | 찾은 쌍: {correct}/{cardCount}");

    }
}

