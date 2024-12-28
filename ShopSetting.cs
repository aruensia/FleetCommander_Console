using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetComander_Console
{
    internal class ShopSetting
    {
        //유저는 전투에 들어가기 전에 가지고 있는 돈을 소비하여 함대를 보충할 수 있다.
        //상점 -> 원하는 함선 선택 -> 돈 제거 -> 함선 추가

        public void ShopList()
        {
            
            GameInfo.consoleUiSetting.ShopMenuPrint();

            int inputNumber = GameInfo.InputNumberMethod();

            //1 이면 구매(ShopListPrint();). 2면 나가기.(GameInfo.mainMenu.SelectListMenu();)

            if ( inputNumber == 1 )
            {
                GameInfo.consoleUiSetting.ConsoleClear();
                GameInfo.shopSetting.BuyShip();
            }
            else if ( inputNumber == 2 )
            {
                GameInfo.consoleUiSetting.ConsoleClear();
                Console.WriteLine("미구현 기능입니다.");
            }
            else if ( inputNumber == 3)
            {
                GameInfo.consoleUiSetting.ConsoleClear();
                return;
            }
        }

        public void BuyShip()
        {
            ConsoleKeyInfo setkey;

            GameInfo.consoleUiSetting.ShipListPrint();

            int inputNumber = GameInfo.InputNumberMethod();

            if (GameInfo.user.Money >= 0)
            {
                if (inputNumber == 1 || inputNumber == 2 || inputNumber == 3) // 함급을 선택하는 부분
                {
                    switch (inputNumber)
                    {
                        case 1:
                            GameInfo.consoleUiSetting.ShipInfoPrint(inputNumber);
                            break;

                        case 2:
                            GameInfo.consoleUiSetting.ShipInfoPrint(inputNumber);
                            break;

                        case 3:
                            GameInfo.consoleUiSetting.ShipInfoPrint(inputNumber);
                            break;
                    }

                    Console.WriteLine($"몇 대를 구매하시겠습니까? | 보유한 골드 {GameInfo.user.Money} | 0 : 나가기");
                    int buyFleetCount = GameInfo.InputNumberMethod();

                    if (buyFleetCount == 0)
                    {
                        GameInfo.consoleUiSetting.ConsoleClear();
                        return;
                    }

                    else if (GameInfo.user.Money >= (GameInfo.playerFleet[inputNumber - 1].Price * buyFleetCount))
                    {
                        GameInfo.user.Money = GameInfo.user.Money - (GameInfo.playerFleet[inputNumber - 1].Price * buyFleetCount);
                        GameInfo.consoleUiSetting.ConsoleClear();
                        GameInfo.consoleUiSetting.ShipBuyPrint(inputNumber, buyFleetCount);

                        setkey = Console.ReadKey();

                        if (setkey.Key == ConsoleKey.Enter)
                        {
                            GameInfo.consoleUiSetting.ConsoleClear();
                        }
                        return;
                    }
                    
                    else if (GameInfo.user.Money < (GameInfo.playerFleet[inputNumber - 1].Price * inputNumber)) //보유한 돈이 구매하려는 함급보다 모자랄 경우
                    {
                        Console.WriteLine("보유한 금액이 구매하려는 함선의 비용보다 모자랍니다.");
                        Console.WriteLine($"엔터를 입력해주세요.");
                        setkey = Console.ReadKey();

                        if (setkey.Key == ConsoleKey.Enter)
                        {
                            GameInfo.consoleUiSetting.ConsoleClear();
                        }
                        return;
                    }
                    else
                    {
                        Console.WriteLine("보유한 금액이 구매하려는 함선의 비용보다 모자랍니다.");
                        Console.WriteLine($"엔터를 입력해주세요.");
                        setkey = Console.ReadKey();

                        if (setkey.Key == ConsoleKey.Enter)
                        {
                            GameInfo.consoleUiSetting.ConsoleClear();
                        }
                        return;
                    }
                }
                else if (inputNumber == 4) // 상점 나가기
                {
                    GameInfo.consoleUiSetting.ConsoleClear();
                    //GameInfo.mainMenu.SelectListMenu();
                    return;
                }
                else if (inputNumber > 4) // 숫자 비교
                {
                    Console.WriteLine("1~4의 숫자를 입력하세요.");
                    return;
                }
                
            }
            else if (GameInfo.user.Money == 0)
            {
                Console.WriteLine("보유한 금액이 0원입니다.");
            }
        }
    }
}
