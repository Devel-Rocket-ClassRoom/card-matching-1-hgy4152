using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Timers;



class CardGame
{
    // 난이도, 스킨, 모드 선택 필드
    private string level;
    private string skin;
    private string mod;


    // 카드 덱 관련 필드
    private string[,] deck;
    protected string[,] playBoard;
    private int column;
    private int row;

    // 게임 종료 조건 필드
    public int tryCount { get; private set; } // 시도횟수
    public int correct { get; private set; } // 맞춘 쌍
    public int cardPairCount { get; private set; } // 전체 쌍
    public int limitCount { get; private set; } // 최대 시도횟수
    public int previewCount { get; private set; } // 미리 보여주기 시간

    // 모드 카운트
    public int survivalCount { get; private set; }
    public int maxCount { get; private set; }
    public int timer { get; private set; }
    public int maxTimer { get; private set; }


    
    ConsoleColor color;
    public Stopwatch sw { get; private set; }
    int counting = 0;

    //Flag
    private bool isEnd = false;
    bool isFirst = false;


    // 싱글톤 인스턴스
    private GameManager GM => GameManager.Instance;

    public void Init()
    {
        level = GM.GetLevel();
        skin = GM.GetSkin();
        mod = GM.GetMod();

        // 기본 초기화 값
        timer = 0;
        correct = 0;
        tryCount = 0;
        survivalCount = 0;
        

        // 난이도 따라 변경하고 싶으면 여기
        maxTimer = 90;
        maxCount = 3;

        sw = new Stopwatch();

    }


    public void CardShuffle()
    {
        switch (level)
        {
            case "1": // 그냥 다 숨겨서 CardDeck 메소드에서 처리하는게 나은가? 가독성을 위해 deck은 부모클래스에서 처리함
                deck = GM.easy.CardDeck(this);
                break;
            case "2":
                deck = GM.normal.CardDeck(this);
                break;
            case "3":
                deck = GM.hard.CardDeck(this);
                break;
        }


        switch (skin)
        {
            case "1":
                GM.basic.GetDisplay(deck);
                break;
            case "2":
                GM.alphabetskin.GetDisplay(deck);
                break;
            case "3":
                GM.markskin.GetDisplay(deck);
                break;
        }


        playBoard = new string[deck.GetLength(0), deck.GetLength(1)];
        // 플레이용 판 만들기
        for (int i = 0; i < deck.GetLength(0); i++)
        {
            for (int j = 0; j < deck.GetLength(1); j++)
            {
                playBoard[i, j] = "**";
            }
        }
    }


    #region # 게임 플레이 관련 메소드

    // 카드 뽑기
    public void GetCard()
    {
        

        string firstCard;
        string secondCard;

        // 뽑은카드 구분
        isFirst = true;
        ShowBoard();
        isFirst = false;

        firstCard = FirstCard(deck);
        counting++;

        ShowBoard();
 
        secondCard = SecondCard(deck);
        counting--;

        ShowBoard();

        Judge(firstCard, secondCard);
    }

    public string FirstCard(string[,] deck)
    {

        string str = CardCheck(deck);
        // 카드 검사 및 등록
        playBoard[column, row] = str;

        return deck[column, row];
    }

    public string SecondCard(string[,] deck)
    {
 

        string str = CardCheck(deck);
        // 카드 검사 및 등록
        playBoard[column, row] = str;

        return deck[column, row];

    }

    public string CardCheck(string[,] deck)
    {

        while (true)
        {
            Console.Write($"{(counting > 0 ? "두 번째": "첫 번째")} 카드를 선택하세요 (행 열): ");
            string[] selectCard1 = Console.ReadLine().Split(" ");
            

            // 잘못받으면 재실행
            if (selectCard1.Length != 2 || !int.TryParse(selectCard1[0], out column) || !int.TryParse(selectCard1[1], out row))
            {
                Console.WriteLine("잘못된 입력입니다. 숫자 두 개를 띄워쓰기로 구분해 입력해 주세요.");
                continue;
            }
            // 범위 벗어날 시 재실행
            else if (column > deck.GetLength(0) || row > deck.GetLength(1))
            {
                Console.WriteLine("범위를 벗어납니다. 다시 선택해주세요.");
                continue;
            }
            // 중복 선택 시 재실행
            else if (playBoard[column-1, row-1] != "**")
            {
                Console.WriteLine("이미 선택된 카드입니다. 다른 카드를 골라주세요");
                continue;
            }


            break;
        }

        // 인덱스이므로 -1
        column -= 1;
        row -= 1;


        return deck[column, row];
    }

    // 난이도 클래스에서 실행
    public void SetGame(int limit, int cardCount, int previewTime)
    {
        limitCount = limit;
        this.cardPairCount = cardCount;
        previewCount = previewTime;
    }

    // 정답 체크
    public void Judge(string firstCard, string secondCard)
    {
        // 판단
        if (firstCard == secondCard)
        {
            correct++;
            tryCount++;
            Console.WriteLine("짝을 찾았습니다!");

            Console.WriteLine();
            survivalCount = 0;
        }
        else
        {
            Console.WriteLine("짝이 맞지 않습니다!");

            // 전역변수 column 과 row 를 1,2 로 나눠서 인덱스로 등록하는 방법도 있긴한데..
            // 하드 코딩 느낌이라 일단 피해봤다.
            for (int i = 0; i < playBoard.GetLength(0); i++)
            {
                for (int j = 0; j < playBoard.GetLength(1); j++)
                {
                    if (playBoard[i, j] == firstCard || playBoard[i, j] == secondCard)
                    {
                        playBoard[i, j] = "**";
                    }
                }
            }

            tryCount++;

            Console.WriteLine();
            survivalCount++;
            
        }

        Thread.Sleep(1000);
        Console.Clear();

    }

    public void GameEnd()
    {
        switch (mod)
        {
            case "1":
                GM.classic.GameOver(this);
                break;
            case "2":
                GM.timeAttack.GameOver(this);
                break;
            case "3":
                GM.survival.GameOver(this);
                break;
        }

    }
    #endregion


    #region # 콘솔화면 출력 관련 메소드
    
    public void Preview()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        for (int i = 0; i < deck.GetLength(1); i++)
        {
            Console.Write($"\t{i + 1}열");
        }
        Console.ResetColor();
        Console.WriteLine();

        for (int i = 0; i < deck.GetLength(0); i++)
        {
            Console.Write($"{i + 1}행");
            for (int j = 0; j < deck.GetLength(1); j++)
            {
                // 색
                color = TextColor(deck[i, j]);

                // 숫자 출력
                Console.ForegroundColor = color;
                Console.Write($"\t{deck[i, j]}");
                Console.ResetColor();
                

            }
            Console.WriteLine();
        }
        Console.WriteLine();

        Console.WriteLine($"잘 기억하세요! ({previewCount}초 후 뒤집힙니다!)");
        Thread.Sleep(previewCount * 1000);
        Console.Clear();

        sw.Start();

    }

    public void ShowBoard()
    {
        timer = (int)sw.Elapsed.TotalSeconds;
        Console.ForegroundColor = ConsoleColor.Cyan;
        for (int i = 0; i < playBoard.GetLength(1); i++)
        {
            Console.Write($"\t{i + 1}열");
        }
        Console.ResetColor();
        Console.WriteLine();

        for (int i = 0; i < playBoard.GetLength(0); i++)
        {
            Console.Write($"{i + 1}행");
            for (int j = 0; j < playBoard.GetLength(1); j++)
            {
                // ** 은 회색 출력
                if (playBoard[i, j] == "**")
                {
                    Console.Write($"\t{playBoard[i, j]}");
                }
                else
                {
                    // 색
                    color = TextColor(deck[i, j]);

                    // 숫자 출력
                    Console.ForegroundColor = color;
                    if(isFirst)
                    {
                        Console.Write($"\t{playBoard[i, j]}");

                    }
                    else
                    {
                        Console.Write($"\t[{playBoard[i, j]}]");
                    }

                    Console.ResetColor();
                }

            }
            Console.WriteLine();
        }
        Console.WriteLine();
        GetText();
    }

    // 스킨별 색깔
    public ConsoleColor TextColor(string value)
    {
        switch (skin)
        {
            case "2":
                return GM.alphabetskin.GetColor(value);
            case "3":
                return GM.markskin.GetColor(value);
        }

        return ConsoleColor.White;
    }

    // 게임 모드에 따른 텍스트 및 룰
    public void GetText()
    {
        switch (mod)
        {
            case "1":
                GM.classic.GameRule(this);
                break;
            case "2":
                GM.timeAttack.GameRule(this);
                break;
            case "3":
                GM.survival.GameRule(this);
                break;
        }

    }

    public bool IsGameOver()
    {
        switch (mod)
        {
            case "1":
                return GM.classic.GameJudge(this);
            case "2":
                return GM.timeAttack.GameJudge(this);
            case "3":
                return GM.survival.GameJudge(this);
        }

        return false;
    }

    #endregion

}