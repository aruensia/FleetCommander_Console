﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetComander_Console
{
    class ConsoleUiSetting
    {
        public void ConsoleShowList()
        {
            Console.WriteLine($"플레이어 함대 : {GameInfo.playerFleet[0].Name} / {GameInfo.playerFleet[1].Name} / {GameInfo.playerFleet[2].Name}");
            Console.WriteLine($"플레이어 함대 : {GameInfo.playerFleet[0].UnitCount} / {GameInfo.playerFleet[1].UnitCount} / {GameInfo.playerFleet[2].UnitCount}");
            Console.WriteLine("");
            Console.WriteLine("종료 하시려면 엔터를 누르시오.");

            ConsoleKeyInfo setkey;
            setkey = Console.ReadKey();

            if (setkey.Key == ConsoleKey.Enter)
            {
                ConsoleClear();
                GameInfo.mainMenu.SelectListMenu();
            }
        }

        public void ConsoleClear()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("                                                                                                                                                        " +
                "                                                                                                                                                                      " +
                "                                                                                                                                                                      " +
                "                                                                                                                                                                      " +
                "                                                                                                                                                                      " +
                "                                                                                                                                                                      " +
                "                                                                                                                                                                      " +
                "                                                                                                                                                                      " +
                "                                                                                                                                                                      " +
                "                                                                                                                                                                      " +
                "                                                                                                                                                                      " +
                "                                                                                                                                                                      " +
                "                                                                                                                                                                      ");
            Console.SetCursorPosition(0, 0);

        }
    }
}
