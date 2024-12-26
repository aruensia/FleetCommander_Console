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
            Console.WriteLine("상점에서 할 일을 선택하세요.");
            Console.WriteLine("1. 구매할 함대 목록 보기");
            Console.WriteLine("2. 나가기");

            int inputNumber = GameInfo.InputNumberMethod();

            //1 이면 구매(ShopListPrint();). 2면 나가기.(GameInfo.mainMenu.SelectListMenu();)

            if ( inputNumber == 1 )
            {
                GameInfo.consoleUiSetting.ConsoleClear();
                GameInfo.shopSetting.BuyShip();
            }
            else if ( inputNumber == 2 )
            {
                //GameInfo.consoleUiSetting.ConsoleClear();
                return;
            }
        }

        public void BuyShip()
        {
            ConsoleKeyInfo setkey;

            Console.WriteLine($"보유한 금액은 {GameInfo.user.Money} 입니다.");
            Console.WriteLine("구매하려는 함선을 선택해 주세요.");
            Console.WriteLine("1. 구축함 | 2. 순양함 | 3. 전함 | 4. 나가기");

            int inputNumber = GameInfo.InputNumberMethod();

            if (GameInfo.user.Money >= 0)
            {
                
                if (inputNumber == 1 || inputNumber == 2 || inputNumber == 3) // 함급을 선택하는 부분
                {
                    Console.WriteLine("몇 대를 구매하시겠습니까?");
                    int buyFleetCount = GameInfo.InputNumberMethod();

                    if (GameInfo.user.Money >= (GameInfo.playerFleet[inputNumber - 1].Price * buyFleetCount))
                    {
                        Console.WriteLine($"{GameInfo.playerFleet[inputNumber - 1].Name} 선택");
                        GameInfo.user.Money = GameInfo.user.Money - (GameInfo.playerFleet[inputNumber - 1].Price * buyFleetCount);

                        GameInfo.playerFleet[inputNumber - 1].UnitCount = GameInfo.playerFleet[inputNumber - 1].UnitCount + (1 * buyFleetCount);
                        Console.WriteLine($"{GameInfo.playerFleet[inputNumber - 1].Name}을 {buyFleetCount}개 구매하셨습니다");
                        Console.WriteLine($"보유한 {GameInfo.playerFleet[inputNumber - 1].Name} 수 : {GameInfo.playerFleet[inputNumber - 1].UnitCount}");
                        Console.WriteLine($"보유한 금액은 {GameInfo.user.Money} 입니다.");
                        Console.WriteLine($"엔터를 입력해주세요.");
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
