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
            GameInfo.consoleUiSetting.StartTitle();
            GameInfo.fleetSetting.FleetDefaltSetting();

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
                GameInfo.consoleUiSetting.MenuListPrint();

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
