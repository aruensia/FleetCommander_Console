﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetComander_Console
{
    partial class BattleSetting
    {
        public void FleetBattle() //5번 동안 양측 함대가 한 번 씩 공격을 주고 받음.
        {
            int trun = 1;
            bool battleOverCheck = false;

            for (int i = 1; i < 6; i++)
            {
                battleInfo.userFirst = true;
                BattleEngage(battleInfo.userFirst);
                battleOverCheck = GameInfo.battleFleets.FleetAttack(battleInfo);
                SaveBattleResult(battleInfo.userFirst);

                battleInfo.userFirst = false;
                BattleEngage(battleInfo.userFirst);
                battleOverCheck = GameInfo.battleFleets.FleetAttack(battleInfo);
                SaveBattleResult(battleInfo.userFirst);

                EndBattleResult();

                if (GameInfo.playerFleet[0].UnitCount == 0 && GameInfo.playerFleet[1].UnitCount == 0 && GameInfo.playerFleet[2].UnitCount == 0)
                {
                    GameOverCodition();
                }

                trun++;
                if (battleOverCheck == true)
                {
                    break;
                }
            }
        }

        public void BattleResult()
        {
            GameInfo.consoleUiSetting.BettleResultPrint();

            ConsoleKeyInfo setkey;
            setkey = Console.ReadKey();

            if (setkey.Key == ConsoleKey.Enter)
            {
                Console.Clear();  // 100줄 이상 넘어가는 전투 로그를 전부 지우기 위해 콘솔 클리어 사용.
            }
        }

        public void GameOverCodition()
        {
            if(GameInfo.playerFleet[0].UnitCount == 0 && GameInfo.playerFleet[1].UnitCount == 0 && GameInfo.playerFleet[2].UnitCount == 0)
            {
                Console.WriteLine();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("패배 했습니다!");
                Console.WriteLine("계속 하시려면 1을 눌러주세요.");

                int inputNumber = GameInfo.InputNumberMethod();
                if( inputNumber == 1)
                {
                    Console.Clear();
                    GameInfo.mainMenu.GameStart();
                }
            }
        }
    }

    partial class BattleFleets
    {
        public void UseSkill(bool userFirst)
        {
            if (userFirst == true)
            {
                GameInfo.playerFleet[0].Skill(GameInfo.playerFleet[0].Attack, GameInfo.playerFleet[0].Defence);
                GameInfo.playerFleet[1].Skill(GameInfo.playerFleet[1].Attack, GameInfo.playerFleet[1].Defence);
                GameInfo.playerFleet[2].Skill(GameInfo.playerFleet[2].Attack, GameInfo.playerFleet[2].Defence);
            }
            else if (userFirst == false)
            {
                GameInfo.enemyFleet[0].Skill(GameInfo.enemyFleet[0].Attack, GameInfo.enemyFleet[0].Defence);
                GameInfo.enemyFleet[1].Skill(GameInfo.enemyFleet[1].Attack, GameInfo.enemyFleet[1].Defence);
                GameInfo.enemyFleet[2].Skill(GameInfo.enemyFleet[2].Attack, GameInfo.enemyFleet[2].Defence);
            }
            
        }
    }

    
}
