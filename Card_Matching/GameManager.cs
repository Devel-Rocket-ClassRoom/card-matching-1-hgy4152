using System;
using System.Collections.Generic;
using System.Text;

class GameManager : GameBase
{
    // 1. instance 앞에 반드시 'static'을 붙여야 합니다.
    // 'static'이 없으면 객체마다 별도의 instance 변수를 가지게 되어 의미가 없어져요.
    private static GameManager instance;

    // 2. 외부에서 GameManager.Instance 라고 부를 수 있게 프로퍼티를 만듭니다.
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

    // 3. 생성자는 비워두거나 필요한 초기화만 하세요. 
    // 생성자 안에서 'new GameManager()'를 하면 절대로 안 됩니다!
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
