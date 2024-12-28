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
            ShowMyFleetList();
            Console.WriteLine("");
            Console.WriteLine("종료 하시려면 엔터를 누르시오.");

            int inputNumber = GameInfo.InputNumberMethod();

            ConsoleClear();
            if (inputNumber == 1)
            {
                ShipInfoPrint(inputNumber);
            }
            else if (inputNumber == 2)
            {
                ShipInfoPrint(inputNumber);
            }
            else if (inputNumber == 3)
            {
                ShipInfoPrint(inputNumber);
            }
            else if (inputNumber == 4)
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
                "                                                                                                                                                                      " + "                                                                                                                                                                      " +
                "                                                                                                                                                                      " +
                "                                                                                                                                                                      " +
                "                                                                                                                                                                      " +
                "                                                                                                                                                                      " +"                                                                                                                                                                      " +
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

        public void MenuListPrint()
        {
            Console.WriteLine("┌ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┐");
            Console.WriteLine("│                                                   [메뉴]                                                 │");
            Console.WriteLine("│                                               1. 함 대 구 입                                             │");
            Console.WriteLine("│                                               2. 함 대 보 기                                             │");
            Console.WriteLine("│                                               3. 전 투 개 시                                             │");
            Console.WriteLine("│                                               4. 게 임 종 료                                             │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                               　                         │");
            Console.WriteLine("│                                                                                        　                │");
            Console.WriteLine("└ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┘");
        }

        public void ShopMenuPrint()
        {
            Console.WriteLine("┌ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┐");
            Console.WriteLine("│ 상점에서 무엇을 하실건가요?                                                                              │");
            Console.WriteLine("│ 1 : 함선 정보 보기 및 구매하기                                                                           │");
            Console.WriteLine("│ 2 : 함선 판매하기 [미구현]                                                                               │");
            Console.WriteLine("│ 3 : 나가기                                                                                               │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                               　                         │");
            Console.WriteLine("│                                                                                        　                │");
            Console.WriteLine("└ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┘");
        }

        public void ShipListPrint()
        {
            Console.WriteLine("┌ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┐");
            Console.WriteLine("│ 구매하려는 함선을 선택해 주세요                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│  1 : 구축함                                                                                              │");
            Console.WriteLine("│  2 : 순양함                                                                                              │");
            Console.WriteLine("│  3 : 전 함                                                                                               │");
            Console.WriteLine("│  4 : 나가기                                                                                              │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                               　                         │");
            Console.WriteLine("│                                                                                        　                │");
            Console.WriteLine("└ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┘");
        }

        public void ShipBuyPrint(int inputNumber, int buyFleetCount)
        {
            Console.WriteLine("┌ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┐");
            Console.WriteLine($"│ {GameInfo.playerFleet[inputNumber - 1].Name}을 {buyFleetCount}개 구매하셨습니다                                                                        │");
            Console.WriteLine($"│ 보유한 {GameInfo.playerFleet[inputNumber - 1].Name} 수 : {GameInfo.playerFleet[inputNumber - 1].UnitCount}                                                                               │");
            Console.WriteLine($"│ 보유한 금액은 {GameInfo.user.Money} 입니다.                                                                                  │");
            Console.WriteLine($"│ 엔터를 입력해주세요.                                                                                     │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                               　                         │");
            Console.WriteLine("│                                                                                        　                │");
            Console.WriteLine("└ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┘");
        }

        public void ShowMyFleetList()
        {
            Console.WriteLine("┌ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┐");
            Console.WriteLine("│ 현재 함대 상황입니다.                                                                                    │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine($"   구축함 : {GameInfo.playerFleet[0].UnitCount} 대 | 순양함 : {GameInfo.playerFleet[1].UnitCount} 대 | 전 함 : {GameInfo.playerFleet[2].UnitCount} 대                                                                                          ");
            Console.WriteLine($"│                                                                                                          │");
            Console.WriteLine($"│ 정보를 보고 싶은 함선을 선택하세요                                                                       │");
            Console.WriteLine("│  1 : 구축함 | 2 : 순양함 | 3 : 전함                                                                      │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                               　                         │");
            Console.WriteLine("│                                                                                        　                │");
            Console.WriteLine("└ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┘");
        }

        public void SellectEnemyLevel()
        {
            Console.WriteLine("┌ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┐");
            Console.WriteLine("│ 적 난이도를 선택해 주세요.                                                                               │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│  1 : 쉬움                                                                                                │");
            Console.WriteLine("│  2 : 보통                                                                                                │");
            Console.WriteLine("│  3 : 어려움                                                                                              │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                               　                         │");
            Console.WriteLine("│                                                                                        　                │");
            Console.WriteLine("└ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┘");
        }

        public void BettleResultPrint()
        {
            Console.WriteLine("┌ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┐");
            Console.WriteLine("│                                                    전투 결과                                             │");
            Console.WriteLine("│                                -제국군 함대-                       -연합군 함대-                         │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine($"                             구축함 : {GameInfo.playerFleet[0].UnitCount} - ~ 손실                  구축함 : {GameInfo.enemyFleet[0].UnitCount}  손실                          ");
            Console.WriteLine($"                             순양함 : {GameInfo.playerFleet[1].UnitCount} ~ 손실                    순양함 : {GameInfo.enemyFleet[1].UnitCount}  손실                         ");
            Console.WriteLine($"                              전함 : {GameInfo.playerFleet[2].UnitCount} ~ 손실                      전함  : {GameInfo.enemyFleet[2].UnitCount}  손실                          ");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                                                          │");
            Console.WriteLine("│                                                                               　                         │");
            Console.WriteLine("│                                                                                        　                │");
            Console.WriteLine("└ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┘");
        }

        public void ScreneDefaultPrint()
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

        public void ShipInfoPrint(int sellectShipinfo)
        {
            if (sellectShipinfo == 1)
            {
                ConsoleClear();
                DsestroyerInfo();
            }
            else if(sellectShipinfo == 2)
            {
                ConsoleClear();
                CruserInfo();
            }
            else if(sellectShipinfo == 3)
            {
                ConsoleClear();
                BattleShip();
            }    

            void DsestroyerInfo()
            {
                Console.WriteLine($"┌ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┐");
                Console.WriteLine($"│  함선 이름 : {GameInfo.playerFleet[0].Name}                                                                                 │");
                Console.WriteLine($"│  함선 구매 비용 : {GameInfo.playerFleet[0].Price}                                                                                    │");
                Console.WriteLine($"│  함선 공격력 : {GameInfo.playerFleet[0].Attack}                                                                                        │");
                Console.WriteLine($"│  함선 방어력 : {GameInfo.playerFleet[0].Defence}                                                                                         │");
                Console.WriteLine($"│  함선 체력 : {GameInfo.playerFleet[0].Hp}                                                                                          │");
                Console.WriteLine($"│  함선 설명 : 적의 공격을 대신 맞으면서 지속적으로 피해를 입히는 소형 함선입니다.                         │");
                Console.WriteLine($"│                                                                                                          │");
                Console.WriteLine($"│                                                                                                          │");
                Console.WriteLine($"│                                                                                                          │");
                Console.WriteLine($"│                                                                               　                         │");
                Console.WriteLine($"│                                                                                        　                │");
                Console.WriteLine($"└ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┘");
            }

            void CruserInfo()
            {
                Console.WriteLine($"┌ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┐");
                Console.WriteLine($"│  함선 이름 : {GameInfo.playerFleet[1].Name}                                                                                 │");
                Console.WriteLine($"│  함선 구매 비용 : {GameInfo.playerFleet[1].Price}                                                                                   │");
                Console.WriteLine($"│  함선 공격력 : {GameInfo.playerFleet[1].Attack}                                                                                        │");
                Console.WriteLine($"│  함선 방어력 : {GameInfo.playerFleet[1].Defence}                                                                                         │");
                Console.WriteLine($"│  함선 체력 : {GameInfo.playerFleet[1].Hp}                                                                                         │");
                Console.WriteLine($"│  함선 설명 : 적의 공격을 대신 맞으면서 지속적으로 피해를 입히는 소형 함선입니다.                         │");
                Console.WriteLine($"│                                                                                                          │");
                Console.WriteLine($"│                                                                                                          │");
                Console.WriteLine($"│                                                                                                          │");
                Console.WriteLine($"│                                                                               　                         │");
                Console.WriteLine($"│                                                                                        　                │");
                Console.WriteLine($"└ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┘");
            }

            void BattleShip()
            {
                Console.WriteLine($"┌ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┐");
                Console.WriteLine($"│  함선 이름 : {GameInfo.playerFleet[2].Name}                                                                                   │");
                Console.WriteLine($"│  함선 구매 비용 : {GameInfo.playerFleet[2].Price}                                                                                   │");
                Console.WriteLine($"│  함선 공격력 : {GameInfo.playerFleet[2].Attack}                                                                                       │");
                Console.WriteLine($"│  함선 방어력 : {GameInfo.playerFleet[2].Defence}                                                                                        │");
                Console.WriteLine($"│  함선 체력 : {GameInfo.playerFleet[2].Hp}                                                                                        │");
                Console.WriteLine($"│  함선 설명 : 적의 공격을 대신 맞으면서 지속적으로 피해를 입히는 소형 함선입니다.                         │");
                Console.WriteLine($"│                                                                                                          │");
                Console.WriteLine($"│                                                                                                          │");
                Console.WriteLine($"│                                                                                                          │");
                Console.WriteLine($"│                                                                               　                         │");
                Console.WriteLine($"│                                                                                        　                │");
                Console.WriteLine($"└ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┘");
            }
        }
    }
}
