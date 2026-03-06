using System;
using System.Collections.Generic;
using System.Text;
static class GameManager
{
    public static string SelectLevel()
    {
        Console.WriteLine("\n난이도를 선택하세요:");
        Console.WriteLine("1. 쉬움 (2x4)");
        Console.WriteLine("2. 보통 (4x4)");
        Console.WriteLine("3. 어려움 (4x6)");
        Console.Write("선택: ");
        return Console.ReadLine();
        
    }

    public static string SkinType()
    {
        Console.WriteLine("\n카드 스킨을 선택하세요:");
        Console.WriteLine("1. 숫자 (기본)");
        Console.WriteLine("2. 알파벳 (컬러)");
        Console.WriteLine("3. 기호 (컬러)");
        Console.Write("선택: ");
        return Console.ReadLine();
 
    }


    public static string GameMod()
    {
        Console.WriteLine("\n게임 모드를 선택하세요:");
        Console.WriteLine("1. 클래식 ");
        Console.WriteLine("2. 타임어택");
        Console.WriteLine("3. 서바이벌");
        Console.Write("선택: ");
        return Console.ReadLine();
    }
}