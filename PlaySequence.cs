using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetComander_Console
{
    internal class PlaySequence
    {
        public void PlayMode()
        {
            GameInfo.battleSetting.BattleFleid();


            Console.WriteLine("1을 눌러 종료하세요.");

            while(true)
            {
                if(GameInfo.InputNumberMethod() == 1)
                {
                    Console.Clear();
                    GameInfo.mainMenu.SelectListMenu();
                    break;
                }
            }
        }
    }
}
