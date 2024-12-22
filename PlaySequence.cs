using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetComander_Console
{
    static class GameInfo
    {
        public static Ship[] playerFleet = new Ship[3];
        public static Ship[] enemyFleet = new Ship[3];
        public static BattleFleets battleFleets = new BattleFleets();
        public static MainMenu mainMenu = new MainMenu();
        public static UserInfo user = new UserInfo();
        public static ShopSetting shopSetting = new ShopSetting();
        public static PlaySequence playSequence = new PlaySequence();
        public static FleetSetting fleetSetting = new FleetSetting();
        public static BattleSetting battleSetting = new BattleSetting();


        public static Random attackChance = new Random();
    }

    internal class PlaySequence
    {
        public void PlayMode()
        {
            GameInfo.battleSetting.BattleFleid();

            Console.WriteLine("a를 눌러 종료하세요.");
            var a = Console.ReadKey();

            switch (a.Key)
            {
                case ConsoleKey.A:
                    Console.Clear();
                    break;
            }

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
            Console.WriteLine("a를 눌러 종료하세요.");



            a = Console.ReadKey();

            switch (a.Key)
            {
                case ConsoleKey.A:
                    Console.Clear();
                    GameInfo.mainMenu.SelectListMenu();
                    break;
            }
        }
    }
}
