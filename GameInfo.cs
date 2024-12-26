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
        public static ConsoleUiSetting consoleUiSetting = new ConsoleUiSetting();
        public static int _nextenemylevel = 0;

        public static Random attackChance = new Random(); // 적 스크린을 뚫고 공격할 확률
        
        public static int InputNumberMethod()
        {
            int inputNumber = 0;
            bool isBoolCodition = false;

            //isBoolCodition = int.TryParse(Console.ReadLine(), out inputNumber);
            while (isBoolCodition == false)
            {
                Console.WriteLine("");
                Console.WriteLine("숫자를 입력해주세요");
                isBoolCodition = int.TryParse(Console.ReadLine(), out inputNumber);
                GameInfo.consoleUiSetting.ConsoleClear();
            }
            
            return inputNumber;
        }
    }
}
