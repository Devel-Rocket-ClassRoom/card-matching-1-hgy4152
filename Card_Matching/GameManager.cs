using System;
using System.Collections.Generic;
using System.Text;

class GameManager : GameBase
{

    private static GameManager instance;

   
    public static GameManager Instance
    {
        get
        {
            // 만약 만들어진 적이 없다면 (최초 1회만 실행됨)
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    public GameManager()
    {
        //난이도 모음
        easy = new Easy();
        normal = new Normal();
        hard = new Hard();

        // 스킨 모음
        basic = new Basic();
        markskin = new MarkSkin();
        alphabetskin = new AlphabetSkin();

        //모드 모음
        classic = new Classic();
        survival = new Survival();
        timeAttack = new TimeAttack();
    }
}
