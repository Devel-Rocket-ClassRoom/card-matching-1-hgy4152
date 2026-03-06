using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;


class Card : GameBase
{
    private string[,] cardShuffle;
    public string [,] playBoard;
    public int tryCount = 0;
    public int correct = 0;
    public int cardCount;

    public int limitCount = 0;
    public int previewCount = 0;

    public string skinNumber;
    public string modNumber;

    Stopwatch sw;

    //게임 종료 여부
    public bool isEnd { get; private set; }


    // 행렬 받기
    int column = 4;
    int row = 4;

    //텍스트 색
    public ConsoleColor color = ConsoleColor.White;
    public MarkSkin markSkin;
    public AlphabetSkin alphabetSkin;


    // 모드 카운트
    public int survival = 0;
    public int maxCount = 3;

    public int timer = 0;
    public int maxTimer = 0;



    // 보드 생성 : 난이도 조절 시 여기다가 matrix 받기
    public Card(string num = "2", string skinNum = "1", string modNum = "1")
    {
        skinNumber = skinNum;
        modNumber = modNum;


        // 난이도에 따른 셋팅
        switch(num)
        {
            case "1":
                column = 2;
                row = 4;
                limitCount = 10;
                previewCount = 5;
                maxTimer = 60;
                break;

            case "2":
                column = 4;
                row = 4;
                limitCount = 20;
                previewCount = 3;
                maxTimer = 90;
                break;

            case "3":
                column = 4;
                row = 6;
                limitCount = 30;
                previewCount = 2;
                maxTimer = 120;
                break;
            default:
                Console.WriteLine("잘못된 값을 선택했습니다.");
                break;
        }


        Console.WriteLine("카드를 섞는 중. . .\n");

        
        // j는 고정 2번
        cardShuffle = new string[column, row];
        cardCount = (column * row) / 2; // 쌍 갯수

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

                        // 스킨 있으면 추가
                        string str = SelectSkin(skinNum, i);

                        cardShuffle[k, l] = $"{str}";
                    }
                }
            }
        }

        Preview(num, previewCount);



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

        // 첫번째 카드 선택
        while (true)
        {
            Console.Write("첫 번째 카드를 선택하세요 (행 열): ");
            string[] selectCard1 = new string[2];
            selectCard1 = Console.ReadLine().Split(" ");

            // 잘못받으면 재실행
            if (selectCard1.Length < 2 || !int.TryParse(selectCard1[0], out int card1) || !int.TryParse(selectCard1[1], out int card2))
            {
                Console.WriteLine("잘못된 입력입니다. 숫자 두 개를 띄워쓰기로 구분해 입력해 주세요.");
                continue;
            }


            // 인덱스로 쓸거니까 -1 하기
            c1 = card1 - 1;
            r1 = card2 - 1;




            if (c1 >= column || r1 >= row)
            {
                Console.WriteLine("범위를 벗어납니다. 다시 선택해주세요.");
            }

            else
            {
                firstCard = cardShuffle[c1, r1];
                playBoard[c1, r1] = $"[{cardShuffle[c1, r1]}]";
                break;
            }
        }

        timer = (int)sw.Elapsed.TotalSeconds;
        ShowBoard();
        // 두 번째 카드 선택
        while (true)
        {
            Console.Write("두 번째 카드를 선택하세요 (행 열): ");
            string[] selectCard2 = new string[5];
            selectCard2 = Console.ReadLine().Split(" ");


            if (selectCard2.Length < 2 || !int.TryParse(selectCard2[0], out int card1) || !int.TryParse(selectCard2[1], out int card2))
            {
                Console.WriteLine("잘못된 입력입니다. 숫자 두 개를 띄워쓰기로 구분해 입력해 주세요.");
                continue;
            }

            c2 = card1 - 1;
            r2 = card2 - 1;


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
                playBoard[c2, r2] = $"[{cardShuffle[c2, r2]}]";
                tryCount++;
                break;
            }

        }
        timer = (int)sw.Elapsed.TotalSeconds;
        ShowBoard();

        // 판단
        if (firstCard == secondCard)
        {
            correct++;
            Console.WriteLine("짝을 찾았습니다!");
            playBoard[c1, r1] = cardShuffle[c1, r1];
            playBoard[c2, r2] = cardShuffle[c2, r2];

            Console.WriteLine();

            survival = 0;

        }
        else
        {
            Console.WriteLine("짝이 맞지 않습니다!");
            playBoard[c2, r2] = playBoard[c1, r1] = " ** ";
            Console.WriteLine();

            survival++;

        }

        Thread.Sleep(1000);

        isEnd = IsGameOver();

       
    }

    // 카드 미리보여주기
    public void Preview(string num, int time)
    {
        Console.Write("    ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        for (int i = 0; i < cardShuffle.GetLength(1); i++)
        {
            Console.Write($"{i + 1}열 ");
        }
        Console.ResetColor();
        Console.WriteLine();

        for (int i = 0; i < cardShuffle.GetLength(0); i++)
        {
            Console.Write($"{i + 1}행 ");
            for (int j = 0; j < cardShuffle.GetLength(1); j++)
            {

                //색 입히기, 스킨관리
                if (skinNumber == "3")
                    color = markSkin.GetColor(cardShuffle[i, j]);
                else if (skinNumber == "2")
                    color = alphabetSkin.GetColor(cardShuffle[i, j]);

                // 숫자 출력
                Console.ForegroundColor = color;
                Console.Write($"  {cardShuffle[i, j]} ");
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine($"잘 기억하세요! ({time}초 후 뒤집힙니다)");

        Thread.Sleep(time * 1000);

        sw = Stopwatch.StartNew();
        Console.Clear();
    }


    // 스킨 고르기
    public string SelectSkin(string num, int value)
    {
        // 기본값
        string result = $"{value}";

        switch(num)
        {
            case "1":
                return result;

            case "2":// 알파벳 스킨
                alphabetSkin = new AlphabetSkin(value);
                result = alphabetSkin.Mark;
                color = alphabetSkin.color;
                return result;

            case "3": // 마크 스킨
                markSkin = new MarkSkin(value);
                result = markSkin.Mark;
                color = markSkin.color;
                return result;
                
        }

        return result;
    }

    public void ShowBoard()
    {

        Console.Write("    ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        for (int i = 0; i < playBoard.GetLength(1); i++)
        {
            Console.Write($"{i + 1}열 ");
        }
        Console.ResetColor();
        Console.WriteLine();

        for (int i = 0; i < playBoard.GetLength(0); i++)
        {
            Console.Write($"{i + 1}행 ");
            for (int j = 0; j < playBoard.GetLength(1); j++)
            {
                // ** 은 회색 출력
                if(playBoard[i, j] == " ** ")
                {
                    Console.Write($"{playBoard[i, j]} ");
                }
                else 
                {
                    // 스킨 관리
                    if (skinNumber == "3")
                        color = markSkin.GetColor(cardShuffle[i, j]);
                    else if (skinNumber == "2")
                        color = alphabetSkin.GetColor(cardShuffle[i, j]);


                    // 숫자 출력
                    Console.ForegroundColor = color;
                    Console.Write($" {playBoard[i, j]} ");
                    Console.ResetColor();
                }


            }
            Console.WriteLine();
        }

        Console.WriteLine();

        // 상태 출력. string 리턴이라 콘솔로 받아서 하는게 맞지만
        // 그냥 귀찮아서 대충 void 함
        GetStatusText();
    }

    protected override bool IsGameOver()
    {
        if(modNumber == "2")
        {
            return timer >= maxTimer;
        }
        if(modNumber == "3")
        {
            return maxCount <= survival;

        }

        return limitCount == cardCount; 
    }
    protected override void GetStatusText()
    {
        // 원래는 card를 부모클래스로 받은 자식 클래스들을 모드로 만들어서 할듯?
        // 근데 그러면 애초에 클래스 생성 때 부터 인터페이스 새로 생성해줘서 할당해줘야함
        // 다음에 해보도록 하자
        if (modNumber == "2")
        {
            Console.WriteLine($"경과 시간: {timer}초 / {maxTimer}초 | 찾은 쌍: {correct}/{cardCount}");

        }
        else if (modNumber == "3")
        {
            Console.WriteLine($"연속 실패: {survival}/{maxCount} | 찾은 쌍: {correct}/{cardCount}");

        }
        else
        {
            Console.WriteLine($"시도 횟수: {tryCount} | 찾은 쌍: {correct}/{cardCount}");
        }


    }


    public void EndText()
    {
        if(modNumber == "2")
        {
            if (timer >= maxTimer)
            {
                sw.Stop();
                Console.WriteLine("=== 게임 오버! ===");
                Console.WriteLine($"제한 시간이 지났습니다!");
                Console.WriteLine($"찾은 쌍: {correct}/{cardCount}\n");
            }
            else
            {
                Console.WriteLine("=== 게임 클리어! ===");
                Console.WriteLine($"총 시도 횟수: {tryCount}");
            }
        }

        if(modNumber == "3")
        {
            if (survival >= maxCount)
            {
                Console.WriteLine("=== 게임 오버! ===");
                Console.WriteLine($"연속으로 3번 틀렸습니다.");
                Console.WriteLine($"찾은 쌍: {correct}/{cardCount}\n");
            }
            else
            {
                Console.WriteLine("=== 게임 클리어! ===");
                Console.WriteLine($"총 시도 횟수: {tryCount}");
            }
        }

        if(modNumber == "1")
        {
            if (limitCount == tryCount)
            {
                Console.WriteLine("=== 게임 오버! ===");
                Console.WriteLine($"시도 횟수를 모두 사용 했습니다.");
                Console.WriteLine($"찾은 쌍: {correct}/{cardCount}\n");
            }
            else
            {
                Console.WriteLine("=== 게임 클리어! ===");
                Console.WriteLine($"총 시도 횟수: {tryCount}");
            }
        }
    }
}

