using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetComander_Console
{
    internal class ConsoleUiSetting
    {
        public void ConsoleShowList()
        {
            Console.WriteLine($"플레이어 함대 : {GameInfo.playerFleet[0].Name} / {GameInfo.playerFleet[1].Name} / {GameInfo.playerFleet[2].Name}");
            Console.WriteLine($"플레이어 함대 : {GameInfo.playerFleet[0].UnitCount} / {GameInfo.playerFleet[1].UnitCount} / {GameInfo.playerFleet[2].UnitCount}");
            Console.WriteLine("");
            Console.WriteLine($"적 함대 : {GameInfo.enemyFleet[0].Name} / {GameInfo.enemyFleet[1].Name} / {GameInfo.enemyFleet[2].Name}");
            Console.WriteLine($"적 함대 : {GameInfo.enemyFleet[0].UnitCount} / {GameInfo.enemyFleet[1].UnitCount} / {GameInfo.enemyFleet[2].UnitCount}");
            Console.WriteLine("종료 하시려면 엔터를 누르시오.");

            ConsoleKeyInfo setkey;
            setkey = Console.ReadKey();

            if (setkey.Key == ConsoleKey.Enter)
            {
                Console.Clear();
            }
        }
    }
}
