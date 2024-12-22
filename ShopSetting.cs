using System;
using System.Collections.Generic;
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
            int inputNumber = 0;
            bool isBoolCodition = false;

            Console.WriteLine("상점에서 할 일을 선택하세요.");
            Console.WriteLine("1. 구매할 함대 목록 보기");
            Console.WriteLine("2. 나가기");

            isBoolCodition = int.TryParse(Console.ReadLine(), out inputNumber);

            //1 이면 구매(ShopListPrint();). 2면 나가기.(GameInfo.mainMenu.SelectListMenu();)

            while (true)
            {
                if (inputNumber == 1)
                {
                    Console.Clear();
                    ShopListPrint();
                }
                else if (inputNumber == 2)
                {
                    Console.Clear();
                    GameInfo.mainMenu.SelectListMenu();
                }
                else if ( inputNumber > 3)
                {
                    Console.WriteLine("숫자 1~2을 눌러 주세요.");
                    isBoolCodition = int.TryParse(Console.ReadLine(), out inputNumber);
                }
                else if (isBoolCodition == false)
                {
                    Console.WriteLine("숫자를 입력해주세요");
                    isBoolCodition = int.TryParse(Console.ReadLine(), out inputNumber);
                }
            }
        }

        public void ShopListPrint()
        {
            ConsoleKeyInfo setkey;

            Console.WriteLine($"보유한 금액은 {GameInfo.user.Money} 입니다.");
            Console.WriteLine("구매하려는 함선을 선택해 주세요.");
            Console.WriteLine("1. 구축함 | 2. 순양함 | 3. 전함 | 4. 나가기");

            int inputNumber = 0;
            bool isBoolCodition = false;

            isBoolCodition = int.TryParse(Console.ReadLine(), out inputNumber);

            if (GameInfo.user.Money > 0)
            {
                while (true)
                {
                    if (inputNumber == 1 || inputNumber == 2 || inputNumber == 3) // 함급을 선택하는 부분
                    {
                        if (GameInfo.user.Money >= GameInfo.playerFleet[inputNumber-1].Price)
                        {
                            Console.WriteLine($"{GameInfo.playerFleet[inputNumber - 1].Name} 선택");
                            GameInfo.user.Money = GameInfo.user.Money - GameInfo.playerFleet[inputNumber - 1].Price;

                            GameInfo.playerFleet[inputNumber - 1].UnitCount++;
                            Console.WriteLine($"{GameInfo.playerFleet[inputNumber - 1].Name}을 1개 구매하셨습니다");
                            Console.WriteLine($"보유한 {GameInfo.playerFleet[inputNumber - 1].Name} 수 : {GameInfo.playerFleet[inputNumber - 1].UnitCount}");
                            Console.WriteLine($"보유한 금액은 {GameInfo.user.Money} 입니다.");
                            setkey = Console.ReadKey();

                            if (setkey.Key == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                ShopListPrint();
                            }
                            break;
                        }
                        else if (GameInfo.user.Money < GameInfo.playerFleet[inputNumber - 1].Price) //보유한 돈이 구매하려는 함급보다 모자랄 경우
                        {
                            Console.WriteLine("보유한 금액이 구매하려는 함선의 비용보다 모자랍니다.");
                            setkey = Console.ReadKey();

                            if (setkey.Key == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                ShopListPrint();
                            }
                            break;
                        }
                    }
                    else if ( inputNumber == 4) // 상점 나가기
                    {
                        Console.Clear();
                        GameInfo.mainMenu.SelectListMenu();
                        break;
                    }
                }
            }
            else if(GameInfo.user.Money == 0 )
            {
                Console.WriteLine("보유한 금액이 0원입니다.");
            }


        }
    }
}
