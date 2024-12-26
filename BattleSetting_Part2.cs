using System;
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
                userFirst = true;
                BattleEngage(userFirst);
                Console.WriteLine($"현재 턴 {trun}");
                Console.WriteLine("----- 유저 차례-----");
                Console.WriteLine(userFirst);
                battleOverCheck = GameInfo.battleFleets.FleetAttack(attackerFleetCount, defenderFleetCount, defenderFleetHp, originFleetHp, fleetType, attackerFleetName, defenderFleetName);
                SaveBattleResult(userFirst);

                Console.WriteLine();
                Console.WriteLine("----- 적 차례-----");
                userFirst = false;
                BattleEngage(userFirst);
                Console.WriteLine(userFirst);
                battleOverCheck = GameInfo.battleFleets.FleetAttack(attackerFleetCount, defenderFleetCount, defenderFleetHp, originFleetHp, fleetType, attackerFleetName, defenderFleetName);
                SaveBattleResult(userFirst);

                EndBattleResult();
                trun++;
                Console.WriteLine("ㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁ턴 종료ㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁ");
                if (battleOverCheck == true)
                {
                    break;
                }
            }
        }

        public void BattleResult()
        {
            Console.WriteLine();
            Console.WriteLine("전투 종료!");
            Console.WriteLine();
            Console.WriteLine($"전투 결과는 다음과 같습니다.");
            Console.WriteLine($"유저 : ");
            Console.WriteLine($"{GameInfo.playerFleet[0].Name} : {GameInfo.playerFleet[0].UnitCount}");
            Console.WriteLine($"{GameInfo.playerFleet[1].Name} : {GameInfo.playerFleet[1].UnitCount}");
            Console.WriteLine($"{GameInfo.playerFleet[2].Name} : {GameInfo.playerFleet[2].UnitCount}");

            Console.WriteLine();
            Console.WriteLine($"적 : ");
            Console.WriteLine($"{GameInfo.enemyFleet[0].Name} : {GameInfo.enemyFleet[0].UnitCount}");
            Console.WriteLine($"{GameInfo.enemyFleet[1].Name} : {GameInfo.enemyFleet[1].UnitCount}");
            Console.WriteLine($"{GameInfo.enemyFleet[2].Name} : {GameInfo.enemyFleet[2].UnitCount}");

            ConsoleKeyInfo setkey;
            setkey = Console.ReadKey();

            if (setkey.Key == ConsoleKey.Enter)
            {
                Console.Clear();  // 100줄 이상 넘어가는 전투 로그를 전부 지우기 위해 콘솔 클리어 사용.
            }
        }
    }

    partial class BattleFleets
    {
        public void UseSkill()
        {
            //GameInfo.playerFleet[0].Skill(GameInfo.playerFleet[0].Attack);
        }
    }
}
