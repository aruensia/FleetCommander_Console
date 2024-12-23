using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FleetComander_Console
{
    class Ship
    {
        string _name;
        int _type;
        int _attack;
        int _defence;
        int _hp;
        int _unitcount;
        int _price;
        int _screenPiercing;

        int _dsetroyerAttackChance;
        int _curisesrAttackChance;
        int _battleshipAttackChance;

        public Ship()
        {

        }

        public Ship(string name, int attack, int defence, int hp, int unitCount, int screenpiercing, int price, int dac, int cac, int bac)
        {
            Name = name;
            Attack = attack;
            Defence = defence;
            Hp = hp;
            UnitCount = unitCount;
            Price = price;
            ScreenPiercing = screenpiercing;
            DsestroyerAttackChance = dac;
            CruiserAttackChance = cac;
            BattleshipAttackChance = bac;
        }
        #region 프로퍼티 모음
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int Attack
        {
            get { return _attack; }
            set { _attack = value; }
        }

        public int Defence
        {
            get { return _defence; }
            set { _defence = value; }
        }

        public int Hp
        {
            get { return _hp; }
            set
            {
                if (value <= 0)
                {
                    _hp = 0;
                }
                else
                {
                    _hp = value;
                }
            }
        }

        public int UnitCount
        {
            get { return _unitcount; }
            set { _unitcount = value; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int ScreenPiercing
        {
            get { return _screenPiercing; }
            set { _screenPiercing = value; }
        }

        public int DsestroyerAttackChance
        {
            get { return _dsetroyerAttackChance; }
            set { _dsetroyerAttackChance = value; }
        }

        public int CruiserAttackChance
        {
            get { return _curisesrAttackChance; }
            set { _curisesrAttackChance = value; }
        }

        public int BattleshipAttackChance
        {
            get { return _battleshipAttackChance; }
            set { _battleshipAttackChance = value; }
        }
        #endregion
    }

    #region 함선 클래스

    class Dsestroyer : Ship
    {
        public Dsestroyer(string name, int attack, int defence, int hp, int unitCount, int screenpiercing, int price, int dac, int cac, int bac) : base(name, attack, defence, hp, unitCount, screenpiercing, price, dac, cac, bac)
        {
            
        }
    }

    class Cruiser : Ship
    {
        public Cruiser(string name, int attack, int defence, int hp, int unitCount, int screenpiercing, int price, int dac, int cac, int bac) : base(name, attack, defence, hp, unitCount, screenpiercing, price, dac, cac, bac)
        {

        }
    }

    class Battleship : Ship
    {
        public Battleship(string name, int attack, int defence, int hp, int unitCount, int screenpiercing, int price, int dac, int cac, int bac) : base(name, attack, defence, hp, unitCount, screenpiercing, price, dac, cac, bac)
        {

        }
    }

    #endregion

    class UserInfo
    {
        int _rank;
        int _money;

        public int Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

        public int Money
        {
            get { return _money; }
            set { _money = value; }
        }

        public UserInfo()
        {
            Rank = 1;
            Money = 1000;
        }
    }

    class FleetSetting // 각 함대의 기본 정보를 세팅하는 함수
    {
        public void FleetDefaltSetting()
        {
            GameInfo.playerFleet[0] = new Dsestroyer("유저 구축함", 10, 1, 10, 10, 50, 30, 7, 0, 2);
            GameInfo.playerFleet[1] = new Cruiser("유저 순양함", 20, 5, 200, 1, 500, 1000, 2, 5, 5);
            GameInfo.playerFleet[2] = new Battleship("유저 전함", 100, 15, 1000, 0, 30, 3000, 1, 6, 8);

            GameInfo.enemyFleet[0] = new Dsestroyer("적 구축함", 10, 1, 10, 5, 50, 30, 7, 0, 2);
            GameInfo.enemyFleet[1] = new Cruiser("적 순양함", 20, 5, 200, 1, 500, 30, 2, 5, 5);
            GameInfo.enemyFleet[2] = new Battleship("적 전함", 100, 15, 1000, 0, 3000, 30, 1, 6, 8);
        }    
    }

    class BattleSetting //세팅된 함대가 전투를 하기 위해 세팅.
    {
        public int fleetType = 0;
        public bool userFirst = true;

        public string[] attackerFleetName = new string[3];
        public int[] attackerFleetCount = new int[3];
        public int[] attackerFleetHp = new int[3];

        public string[] defenderFleetName = new string[3];
        public int[] defenderFleetCount = new int[3];
        public int[] defenderFleetHp = new int[3];
        public int[] originFleetHp = new int[3];

        public int[] emptyPlayerFleetCount = new int[3];
        public int[] emptyEnemyFleetCount = new int[3];

        public void BattleFleid()
        {
            BattleEngage(userFirst);
            FleetBattle();
            BattleResult();
        }

        public void BattleEngage(bool userFirst)
        {
            if (userFirst == true)
            {
                for (int i = 0; i < 3; i++)
                {
                    attackerFleetName[i] = GameInfo.playerFleet[i].Name;
                    attackerFleetCount[i] = GameInfo.playerFleet[i].UnitCount;
                    attackerFleetHp[i] = GameInfo.playerFleet[i].Hp;

                    defenderFleetName[i] = GameInfo.enemyFleet[i].Name;
                    defenderFleetCount[i] = GameInfo.enemyFleet[i].UnitCount;
                    defenderFleetHp[i] = GameInfo.enemyFleet[i].Hp;
                    originFleetHp[i] = GameInfo.enemyFleet[i].Hp;
                }
            }
            else if (userFirst == false)
            {
                for (int i = 0; i < 3; i++)
                {
                    attackerFleetName[i] = GameInfo.enemyFleet[i].Name;
                    attackerFleetCount[i] = GameInfo.enemyFleet[i].UnitCount;
                    attackerFleetHp[i] = GameInfo.enemyFleet[i].Hp;

                    defenderFleetName[i] = GameInfo.playerFleet[i].Name;
                    defenderFleetCount[i] = GameInfo.playerFleet[i].UnitCount;
                    defenderFleetHp[i] = GameInfo.playerFleet[i].Hp;
                    originFleetHp[i] = GameInfo.playerFleet[i].Hp;
                }
            }
        }

        public void SaveBattleResult(bool userFirst)
        {
            // 전투에 투입했던 함대들을 기존 함대 배열에 넣음
            if (userFirst == true)
            {
                for (int i = 0; i < 3; i++)
                {
                    emptyEnemyFleetCount[i] = defenderFleetCount[i];
                }
            }

            else if (userFirst == false)
            {
                for (int i = 0; i < 3; i++)
                {
                    emptyPlayerFleetCount[i] = defenderFleetCount[i];
                }
            }
        }

        public void EndBattleResult()
        {
            //턴 종료 시 임시배열에 넣은 함대를 기존 함대 배열에 넣음
            for(int i = 0; i < 3;i++)
            {
                GameInfo.enemyFleet[i].UnitCount = emptyEnemyFleetCount[i];
                GameInfo.playerFleet[i].UnitCount = emptyPlayerFleetCount[i];
            }
        }

        public void FleetBattle()
        {
            int trun = 0;

            for (trun = 1; trun < 6; trun++)
            {
                userFirst = true;
                Console.WriteLine($"현재 턴 {trun}");
                Console.WriteLine("----- 유저 차례-----");
                BattleEngage(userFirst);
                Console.WriteLine(userFirst);
                GameInfo.battleFleets.FleetAttack(attackerFleetCount, defenderFleetCount, defenderFleetHp, originFleetHp, fleetType, attackerFleetName, defenderFleetName);
                SaveBattleResult(userFirst);

                Console.WriteLine();
                Console.WriteLine("----- 적 차례-----");
                userFirst = false;
                BattleEngage(userFirst);
                Console.WriteLine(userFirst);
                GameInfo.battleFleets.FleetAttack(attackerFleetCount, defenderFleetCount, defenderFleetHp, originFleetHp, fleetType, attackerFleetName, defenderFleetName);
                SaveBattleResult(userFirst);

                EndBattleResult();
                Console.WriteLine("ㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁ턴 종료ㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁ");
            }
        }

        public void BattleResult()
        {
            Console.Clear();
            Console.WriteLine("전투 종료!");
            Console.WriteLine();
            Console.WriteLine($"전투 결과는 다음과 같습니다.");
            Console.WriteLine($"유저 : ");
            Console.WriteLine($"{GameInfo.playerFleet[0].Name} : {GameInfo.playerFleet[0].UnitCount}");
            Console.WriteLine($"{GameInfo.playerFleet[1].Name} : {GameInfo.playerFleet[1].UnitCount}");
            Console.WriteLine($"{GameInfo.playerFleet[2].Name} : {GameInfo.playerFleet[2].UnitCount}");

            Console.WriteLine();
            Console.WriteLine($"적 : ");
            Console.WriteLine($"{GameInfo.enemyFleet[0].Name} : {GameInfo.enemyFleet[0].UnitCount}");
            Console.WriteLine($"{GameInfo.enemyFleet[1].Name} : {GameInfo.enemyFleet[1].UnitCount}");
            Console.WriteLine($"{GameInfo.enemyFleet[2].Name} : {GameInfo.enemyFleet[2].UnitCount}");

            ConsoleKeyInfo setkey;
            setkey = Console.ReadKey();

            if (setkey.Key == ConsoleKey.Enter)
            {
                Console.Clear();
            }
        }
    }

    class BattleFleets
    {
        //public bool ScreenPiercing(int[] defenderFleetCount, int[] attackerFleetCount) ////구축함이 방벽역할을 하는 함수. (공격자 순양함 + 공격자 전함 / 방어자 구축함)
        //{
        //    bool isFleetScreenPiercing = false;

        //    if(defenderFleetCount[0] >= (attackerFleetCount[1] + attackerFleetCount[2]))
        //    {

        //    }

        //    return isFleetScreenPiercing;
        //}

        public void FleetAttack(int[] attackerFleetCount, int[] defenderFleetCount, int[] defenderFleetHp, int[] originFleetHp, int fleetType, string[] attackerFleetName, string[] defenderFleetName) // 아군 함대가 적의 함대에게 우선 공격을 가함. 공격 후, 공격 찬스 만큼 추가 공격을 가함.
        {
            float setAttackChance = 0;

            setAttackChance = GameInfo.attackChance.Next(0, 100);

            for (fleetType = 0; fleetType < 3; fleetType++) // 구축함, 순양함, 전함 순으로 공격을 진행함.
            {
                if (attackerFleetCount[fleetType] <= 0)
                {
                    for (int i = 0; i < attackerFleetCount[fleetType]; i++)
                    {
                        Console.WriteLine($"적 {defenderFleetName[fleetType]}이 없어, {defenderFleetName[fleetType+1]}으로 변경합니다.");
                        Console.WriteLine($"{defenderFleetName[fleetType+1]} / {defenderFleetCount[fleetType+1]}");
                        GameInfo.battleFleets.TakeDamage(fleetType + 1, attackerFleetCount, defenderFleetCount, defenderFleetHp, originFleetHp, attackerFleetName, defenderFleetName);
                    }
                }

                else if (attackerFleetCount[fleetType] > 0)
                {
                    for (int i = 0; i < attackerFleetCount[fleetType]; i++)
                    {
                       Console.WriteLine($"{attackerFleetName[fleetType]} / {attackerFleetCount[fleetType]}");
                        GameInfo.battleFleets.TakeDamage(fleetType, attackerFleetCount, defenderFleetCount, defenderFleetHp, originFleetHp, attackerFleetName, defenderFleetName);
                    }
                }
            }
        }

        public void TakeDamage(int fleetType,int[] attackerFleetCount,  int[] defenderFleetCount, int[] defenderFleetHp, int[] originFleetHp, string[] attackerFleetName, string[] defenderFleetName) // 적의 함대에게 피해를 입음.
        {
            int setDamage = 0;
            int isOriginHp = 0;

            //데미지 계산 : 방어함대의 방어력 - 공격함대의 공격력
            setDamage = GameInfo.enemyFleet[fleetType].Attack - GameInfo.playerFleet[fleetType].Defence;

            for (int i = 0; i < 3; i++)
            {
                if (defenderFleetCount[i] > 0) //수비하는 함대의 유닛수가 1보다 많을 경우 전투 참여
                {
                    if (setDamage > 0) //공격자의 피해가 1보다 높을 경우 적에게 피해를 입힘
                    {
                        defenderFleetHp[i] = defenderFleetHp[i] - setDamage;
                        Console.WriteLine($"공격 함대 {attackerFleetName[fleetType]}은 방어 함대의 {defenderFleetName[i]} 을 공격했다.");
                        Console.WriteLine($"현재 대상의 남은 체력은 {defenderFleetHp[i]} 입니다.");

                        if (defenderFleetHp[i] <= 0) //공격자의 피해가 0이거나 음수일 경우 방어자의 함대 수를 1 감소시킴
                        {
                            defenderFleetCount[i] = Convert.ToInt32(defenderFleetCount[i]) - 1;
                            Console.WriteLine($"방어 함대 {defenderFleetName[i]}의 남은 수는 {defenderFleetCount[i]} 입니다. ");
                            isOriginHp = Convert.ToInt32(originFleetHp[i]);
                            defenderFleetHp[i] = isOriginHp;
                        }
                    }
                    else if (setDamage <= 0) //공격자의 공격력이 방어력보다 낮을 경우 피해가 1로 고정
                    {
                        defenderFleetHp[i] = defenderFleetHp[i] - 1;
                        Console.WriteLine("적의 공격력이 낮아 피해를 못줬다.");
                    }
                }
                else if (defenderFleetCount[i] <= 0) //방어자의 유닛 수가 0일 경우 출력
                {
                    Console.WriteLine($"전장에 {defenderFleetName[i]}이 없다.");
                }
            }
        }
    }
}
