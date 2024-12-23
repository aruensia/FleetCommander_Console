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
            Console.Clear();
            GameInfo.fleetSetting.FleetDefaltSetting();

            Console.WriteLine("1 : 게임을 시작하기");
            Console.WriteLine("2 : 나가기");
            int inputNumber = GameInfo.InputNumberMethod();
            while (true)
            {
                if (inputNumber == 1)
                {
                    switch (inputNumber)
                    {
                        case 1:
                            Console.Clear();
                            SelectListMenu();
                            break;
                        case 2:
                            Environment.Exit(0);
                            break;
                    }
                }
                else if (inputNumber > 2)
                {
                    Console.WriteLine("1~2의 숫자를 입력해주세요.");
                    GameInfo.InputNumberMethod();
                }
            }
        }

        public void SelectListMenu()
        {
            Console.WriteLine("1. 상점"); //GameInfo.shopSetting.ShopList();
            Console.WriteLine("2. 함대 정보"); //GameInfo.shopSetting.ShopList();
            Console.WriteLine("3. 전투 개시"); //GameInfo.playSequence.PlayMode();
            Console.WriteLine("4. 게임 종료");

            int inputNumber = GameInfo.InputNumberMethod();

            while (true)
            {
                if (inputNumber == 1)
                {
                    Console.Clear();
                    //GameInfo.shopSetting.ShopList();
                    GameInfo.shopmenu.ShopSequence();
                }
                else if (inputNumber == 2)
                {
                    Console.Clear();
                    GameInfo.consoleUiSetting.ConsoleShowList();
                }
                else if (inputNumber == 3)
                {
                    Console.Clear();
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
