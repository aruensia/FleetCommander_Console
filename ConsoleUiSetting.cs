using System;
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
                return;
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

        public void StartCursorPosition()
        {

        }

        public void StartTitle()
        {
            Console.SetCursorPosition(0, 0);

            Console.WriteLine("┌ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┐");
            Console.WriteLine("│          ..######..########.....###.....######..########.....######..##.....##.####.########.            │");
            Console.WriteLine("│          .##....##.##.....##...##.##...##....##.##..........##....##.##.....##..##..##.....##            │");
            Console.WriteLine("│          .##.......##.....##..##...##..##.......##..........##.......##.....##..##..##.....##            │");
            Console.WriteLine("│          ..######..########..##.....##.##.......######.......######..#########..##..########.            │");
            Console.WriteLine("│          .......##.##........#########.##.......##................##.##.....##..##..##.......            │");  
            Console.WriteLine("│          .##....##.##........##.....##.##....##.##..........##....##.##.....##..##..##.......            │");
            Console.WriteLine("│          ..######..##........##.....##..######..########.....######..##.....##.####.##.......            │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                           1 : 게임을 시작하기                                            │");
            Console.WriteLine("│                                           2 : 나가기                                    　               │");
            Console.WriteLine("│                                                                                         　               │");
            Console.WriteLine("└ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┘");
        }

        public void ShipInfoPrint()
        {
            Console.WriteLine("┌ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┐");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                               　                         │");
            Console.WriteLine("│                                                                                        　                │");
            Console.WriteLine("└ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┘");
        }
    }
}
