using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetComander_Console
{
    internal class PlaySequence //난이도를 관리하고 및 전투를 불러오는 클래스
    {
        public void PlayMode()
        {
            int setRewardRate = 0;

            setRewardRate = EnemyFleetLevelSetting();
            GameInfo.battleSetting.BattleFleid(setRewardRate); //전투를 세팅하고 승패에 따라 돈을 얻는 클래스 및 함수.
            //Console.WriteLine($"게임 단계 값 : {GameInfo._nextenemylevel}");
            Console.WriteLine("1을 눌러 종료하세요.");

            while(true)
            {
                if(GameInfo.InputNumberMethod() == 1)
                {
                    GameInfo.consoleUiSetting.ConsoleClear();
                    GameInfo.mainMenu.SelectListMenu();           // 전투 종료 후 메뉴 선택으로 돌아옴.
                    break;
                }
            }
        }

        public int SetupEnemyGameLevel()
        {
            int gameLevel = 1;

            return gameLevel;
        }

        public int EnemyFleetLevelSetting()
        {
            //첫 게임을 진행한 후, 적 함대 배열에 유닛수를 초기화 및 대입함
            //초기화 및 대입을 할 때 그룹을 3개로 나뉘어 선택할 수 있게 결정
            //결정하는 순간 적 함대 배열에 적을 넣음.
            //난이도가 높을 수록 승리 보상 배율이 늘어남

            int rewardRate = 0;

            Console.WriteLine("난이도를 선택해주세요");
            Console.WriteLine("1 : 쉬움 | 2 : 보통 | 3: 어려움");
            int inputNumber = GameInfo.InputNumberMethod();

            if (inputNumber == 1)
            {
                GameInfo.enemyFleet[0].UnitCount = (GameInfo._nextenemylevel * 10) + SetupEnemyGameLevel();
                GameInfo.enemyFleet[1].UnitCount = (GameInfo._nextenemylevel * 5) + SetupEnemyGameLevel();
                GameInfo.enemyFleet[2].UnitCount = (GameInfo._nextenemylevel * 1) + SetupEnemyGameLevel();
                
                return rewardRate = 2;
            }
            else if (inputNumber == 2)
            {
                GameInfo.enemyFleet[0].UnitCount = (GameInfo._nextenemylevel * 15) + SetupEnemyGameLevel();
                GameInfo.enemyFleet[1].UnitCount = (GameInfo._nextenemylevel * 7) + SetupEnemyGameLevel();
                GameInfo.enemyFleet[2].UnitCount = (GameInfo._nextenemylevel * 1) + SetupEnemyGameLevel();
                
                return rewardRate = 3;
            }
            else if (inputNumber == 3)
            {
                GameInfo.enemyFleet[0].UnitCount = (GameInfo._nextenemylevel * 20) + SetupEnemyGameLevel();
                GameInfo.enemyFleet[1].UnitCount = (GameInfo._nextenemylevel * 9) + SetupEnemyGameLevel();
                GameInfo.enemyFleet[2].UnitCount = (GameInfo._nextenemylevel * 3) + SetupEnemyGameLevel();
             
                return rewardRate = 4;
            }
            else if ( inputNumber >= 4)
            {
                Console.WriteLine("1~4까지 숫자를 입력해주세요");
                GameInfo.InputNumberMethod();
            }

            return rewardRate;
        }
    }
}
