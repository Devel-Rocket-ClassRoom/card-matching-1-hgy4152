using System;
using System.Collections.Generic;
using System.Text;

class GameBase
{


    //난이도 모음
    public Easy easy;
    public Normal normal;
    public Hard hard;


    // 스킨 모음
    public Basic basic;
    public MarkSkin markskin;
    public AlphabetSkin alphabetskin;

    //모드 모음
    public Classic classic;
    public Survival survival;
    public TimeAttack timeAttack;

    public string GetLevel()
    {
        Console.WriteLine("\n난이도를 선택하세요:");
        Console.WriteLine("1. 쉬움 (2x4)");
        Console.WriteLine("2. 보통 (4x4)");
        Console.WriteLine("3. 어려움 (4x6)");
        Console.Write("선택: ");
        return Console.ReadLine();

    }

    public string GetSkin()
    {
        Console.WriteLine("\n카드 스킨을 선택하세요:");
        Console.WriteLine("1. 숫자 (기본)");
        Console.WriteLine("2. 알파벳 (컬러)");
        Console.WriteLine("3. 기호 (컬러)");
        Console.Write("선택: ");
        return Console.ReadLine();

    }


    public string GetMod()
    {
        Console.WriteLine("\n게임 모드를 선택하세요:");
        Console.WriteLine("1. 클래식 ");
        Console.WriteLine("2. 타임어택");
        Console.WriteLine("3. 서바이벌");
        Console.Write("선택: ");
        return Console.ReadLine();
    }

}