using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FleetComander_Console
{
    internal class MainMenu
    {
        public void GameStart()
        {
            GameInfo.consoleUiSetting.ConsoleClear();
            GameInfo.fleetSetting.FleetDefaltSetting();

            Console.WriteLine("1 : 게임을 시작하기");
            Console.WriteLine("2 : 나가기");
            int inputNumber = GameInfo.InputNumberMethod();
            
            if (inputNumber == 1)
            {
                GameInfo.consoleUiSetting.ConsoleClear();
                SelectListMenu();
                
            }
            else if (inputNumber == 2)
            {
                Environment.Exit(0);
            }
        }

        public void SelectListMenu()
        {
           
            while(true)
            {
                Console.WriteLine("----[메뉴]----");
                Console.WriteLine("1. 상점");
                Console.WriteLine("2. 함대 정보");
                Console.WriteLine("3. 전투 개시");
                Console.WriteLine("4. 게임 종료");

                int inputNumber = GameInfo.InputNumberMethod();

                if (inputNumber == 1)
                {
                    GameInfo.consoleUiSetting.ConsoleClear();
                    GameInfo.shopSetting.ShopList();
                }
                else if (inputNumber == 2)
                {
                    GameInfo.consoleUiSetting.ConsoleClear();
                    GameInfo.consoleUiSetting.ConsoleShowList();
                }
                else if (inputNumber == 3)
                {
                    GameInfo.consoleUiSetting.ConsoleClear();
                    GameInfo.playSequence.PlayMode();
                }
                else if (inputNumber == 4)
                {
                    Environment.Exit(0);
                }
            }    
        }
    }
}
