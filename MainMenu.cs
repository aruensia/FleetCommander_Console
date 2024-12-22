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
            int inputNumber = 0;
            bool isBoolCodition = false;

            Console.Clear();
            GameInfo.fleetSetting.FleetDefaltSetting();

            Console.WriteLine("1 키를 눌러 게임을 시작하기");
            Console.WriteLine("게임 시작");

            isBoolCodition = int.TryParse(Console.ReadLine(), out inputNumber);

            while (true)
            {
                if (inputNumber == 1)
                {
                    Console.Clear();
                    SelectListMenu();
                }
                else if (inputNumber > 1)
                {
                    Console.WriteLine("숫자 1을 눌러 주세요.");
                    isBoolCodition = int.TryParse(Console.ReadLine(), out inputNumber);
                }
                else if (isBoolCodition == false)
                {
                    Console.WriteLine("숫자를 입력해주세요");
                    isBoolCodition = int.TryParse(Console.ReadLine(), out inputNumber);
                }
            }
        }

        public void SelectListMenu()
        {
            Console.WriteLine("1. 상점"); //GameInfo.shopSetting.ShopList();
            Console.WriteLine("2. 함대 정보"); //GameInfo.shopSetting.ShopList();
            Console.WriteLine("3. 전투 개시"); //GameInfo.playSequence.PlayMode();

            int inputNumber = 0;
            bool isBoolCodition = false;

            isBoolCodition = int.TryParse(Console.ReadLine(), out inputNumber);

            while (true)
            {
                if (inputNumber == 1)
                {
                    Console.Clear();
                    GameInfo.shopSetting.ShopList();
                }
                else if (inputNumber == 2)
                {
                    Console.Clear();
                    GameInfo.shopSetting.ShopList();
                }
                else if (inputNumber == 3)
                {
                    Console.Clear();
                    GameInfo.playSequence.PlayMode();
                }
                else if (inputNumber > 3)
                {
                    Console.WriteLine("1~3을 입력해 주세요");
                    isBoolCodition = int.TryParse(Console.ReadLine(), out inputNumber);
                }
                else if (isBoolCodition == false)
                {
                    Console.WriteLine("숫자를 입력해 주세요.");
                    isBoolCodition = int.TryParse(Console.ReadLine(), out inputNumber);
                }
            }
        }
    }
}
