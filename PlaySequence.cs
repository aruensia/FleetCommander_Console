using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetComander_Console
{
    internal class PlaySequence //난이도를 관리하고 및 전투를 불러오는 클래스
    {
        int _nextenemylevel = 0; //유저의 진행 사항에 따라 적 함대의 레벨을 증가시키는 함수.

        public int NextEnemyLevel
        {
            get { return _nextenemylevel; }
            set {  _nextenemylevel = value; }
        }

        public void PlayMode()
        {
            NextEnemyLevel = GameInfo.battleSetting.BattleFleid(NextEnemyLevel); //전투를 세팅하고 승패에 따라 돈을 얻는 클래스 및 함수.
            EnemyFleetLevelSetting(NextEnemyLevel);
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

        public void EnemyFleetLevelSetting(int NextEnemyLevel)
        {
            //첫 게임을 진행한 후, 적 함대 배열에 유닛수를 초기화 및 대입함
            //초기화 및 대입을 할 때 그룹을 3개로 나뉘어 선택할 수 있게 결정
            //결정하는 순간 적 함대 배열에 적을 넣음.

            

            GameInfo.enemyFleet[0].UnitCount = (NextEnemyLevel * 10) + SetupEnemyGameLevel();
            GameInfo.enemyFleet[1].UnitCount = (NextEnemyLevel * 5) + SetupEnemyGameLevel();
            GameInfo.enemyFleet[2].UnitCount = (NextEnemyLevel * 2) + SetupEnemyGameLevel();
        }
    }
}
