using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
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

        int _dsetroyerAttackChance;
        int _curisesrAttackChance;
        int _battleshipAttackChance;

        public Ship()
        {

        }

        public Ship(string name, int attack, int defence, int hp, int unitCount, int price, int dac, int cac, int bac)
        {
            Name = name;
            Attack = attack;
            Defence = defence;
            Hp = hp;
            UnitCount = unitCount;
            Price = price;
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
            set { if (value <= 0)
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
        public Dsestroyer(string name, int attack, int defence, int hp, int unitCount, int price, int dac, int cac, int bac) : base(name, attack, defence, hp, unitCount, price, dac, cac, bac)
        {
            
        }
    }

    class Cruiser : Ship
    {
        public Cruiser(string name, int attack, int defence, int hp, int unitCount, int price, int dac, int cac, int bac) : base(name, attack, defence, hp, unitCount, price, dac, cac, bac)
        {

        }
    }

    class Battleship : Ship
    {
        public Battleship(string name, int attack, int defence, int hp, int unitCount, int price,int dac, int cac, int bac) : base(name, attack, defence, hp, unitCount, price, dac, cac, bac)
        {

        }
    }

    #endregion

    class UserInfo
    {
        int _rank;
        int _money;
    }



    class FleetSetting // 각 함대의 기본 정보를 세팅하는 함수
    {
       
        public void FleetDefaltSetting()
        {
            GameInfo.playerFleet[0] = new Dsestroyer("구축함", 10, 1, 10, 20, 50, 7, 0, 2);
            GameInfo.playerFleet[1] = new Cruiser("순양함", 20, 5, 200, 5, 500, 2, 5, 5);
            GameInfo.playerFleet[2] = new Battleship("전함", 100, 15, 1000, 0, 3000, 1, 6, 8);

            GameInfo.enemyFleet[0] = new Dsestroyer("구축함", 10, 1, 10, 10, 50, 7, 0, 2);
            GameInfo.enemyFleet[1] = new Cruiser("순양함", 20, 5, 200, 10, 500, 2, 5, 5);
            GameInfo.enemyFleet[2] = new Battleship("전함", 100, 15, 1000, 1, 3000, 1, 6, 8);

            Console.WriteLine($"플레이어 함대 : {GameInfo.playerFleet[0].Name} / {GameInfo.playerFleet[1].Name} / {GameInfo.playerFleet[2].Name}");
            Console.WriteLine($"플레이어 함대 : {GameInfo.playerFleet[0].UnitCount} / {GameInfo.playerFleet[1].UnitCount} / {GameInfo.playerFleet[2].UnitCount}");
            Console.WriteLine("");
            Console.WriteLine($"적 함대 : {GameInfo.enemyFleet[0].Name} / {GameInfo.enemyFleet[1].Name} / {GameInfo.enemyFleet[2].Name}");
            Console.WriteLine($"적 함대 : {GameInfo.enemyFleet[0].UnitCount} / {GameInfo.enemyFleet[1].UnitCount} / {GameInfo.enemyFleet[2].UnitCount}");

            Console.WriteLine("a를 눌러 종료하세요.");
            var a = Console.ReadKey();

            switch (a.Key)
            {
                case ConsoleKey.A:
                    Console.Clear();
                    break;
            }
        }    
    }

    class BattleSetting //세팅된 함대가 전투를 하기 위해 세팅.
    {
        public int fleetType = 0;

        public int[] playerEngageShip = new int[3];
        public int[] playerEngageShipHp = new int[3];
        public int[] originEnemyShipCount = new int[3];
        public int[] originEnemyShipHp = new int[3];
        
        public void BattleFleid()
        {
            BattleEngage();
            FleetBattle();
        }

        public void BattleEngage()
        {
            playerEngageShip[0] = GameInfo.playerFleet[0].UnitCount; // 전투에 들어가는 아군 구축함을 전투 배열에 넣음
            playerEngageShip[1] = GameInfo.playerFleet[1].UnitCount; // 전투에 들어가는 아군 순양함을 전투 배열에 넣음
            playerEngageShip[2] = GameInfo.playerFleet[2].UnitCount; // 전투에 들억아는 아군 전함을 전투 배열에 넣음

            playerEngageShipHp[0] = GameInfo.playerFleet[0].Hp; // 전투에 들어가는 아군 구축함의 원래 체력을 넣음
            playerEngageShipHp[1] = GameInfo.playerFleet[1].Hp; // 전투에 들어가는 아군 순양함의 원래 체력을 넣음
            playerEngageShipHp[2] = GameInfo.playerFleet[2].Hp; // 전투에 들어가는 아군 전함의 원래 체력을 넣음


            originEnemyShipCount[0] = GameInfo.enemyFleet[0].UnitCount; // 전투에 들어가는 적 구축함의 원래 함대수를 넣음
            originEnemyShipCount[1] = GameInfo.enemyFleet[1].UnitCount; // 전투에 들어가는 적 순양함의 원래 함대수를 넣음
            originEnemyShipCount[2] = GameInfo.enemyFleet[2].UnitCount; // 전투에 들어가는 적 전함의 원래 함대수를 넣음

            originEnemyShipHp[0] = GameInfo.enemyFleet[0].Hp; // 전투에 들어가는 적 구축함의 원래 체력을 넣음
            originEnemyShipHp[1] = GameInfo.enemyFleet[1].Hp; // 전투에 들어가는 적 순양함의 원래 체력을 넘음
            originEnemyShipHp[2] = GameInfo.enemyFleet[2].Hp; // 전투에 들어가는 적 순양함의 원래 체력을 넘음
        }

        public void FleetBattle()
        {
            int trun = 1;

            for (int i = 0; i < trun; i++)
            {
                Console.WriteLine("----- 유저 차례-----");
                GameInfo.player.HaveAttack(playerEngageShip, GameInfo.playerFleet, fleetType, originEnemyShipHp);

                Console.WriteLine();
                Console.WriteLine("----- 적 차례-----");
                GameInfo.enemy.HaveAttack(originEnemyShipCount, GameInfo.enemyFleet, fleetType, playerEngageShipHp);
            }
        }
    }

    class PlayerFleet
    {
        public void BattleSwhich(Ship[] ships)
        {
            bool userFirst = true;

            Ship[] attackerFleet = new Ship[3];
            Ship[] defenderFleet = new Ship[3];

            if (userFirst = true)
            {
                for (int i = 0; i < 3; i++)
                {
                    attackerFleet[i].UnitCount = GameInfo.playerFleet[i].UnitCount;
                    attackerFleet[i].Hp = GameInfo.playerFleet[i].Hp;

                    defenderFleet[i].UnitCount = GameInfo.enemyFleet[i].UnitCount;
                    defenderFleet[i].Hp = GameInfo.enemyFleet[i].Hp;
                }
            }
        }



        public void HaveAttack(int[] playerEngageShip, Ship[] ships, int fleetType, int[] originenemyFleetHp) // 아군 함대가 적의 함대에게 우선 공격을 가함. 공격 후, 공격 찬스 만큼 추가 공격을 가함.
        {
            float setAttackChance = 0;

            setAttackChance = GameInfo.attackChance.Next(0, 100);

            for (fleetType = 0; fleetType < 3; fleetType++) // 구축함,순양함, 전함 순으로 공격을 진행함.
            {
                if (ships[fleetType].UnitCount <= 0)
                {
                    for (int i = 0; i < ships[fleetType].UnitCount; i++)
                    {
                        Console.WriteLine($"적 {ships[fleetType].Name}이 없어, {ships[fleetType + 1].Name}으로 변경합니다.");
                        Console.WriteLine($"{ships[fleetType + 1].Name} / {ships[fleetType + 1].UnitCount}");
                        GameInfo.enemy.TakeDamage(fleetType + 1, originenemyFleetHp);
                    }
                }

                else if (ships[fleetType].UnitCount > 0)
                {
                    for (int i = 0; i < ships[fleetType].UnitCount; i++)
                    {
                        Console.WriteLine($"{ships[fleetType].Name} / {ships[fleetType].UnitCount}");
                        GameInfo.enemy.TakeDamage(fleetType, originenemyFleetHp);
                    }
                }
            }
        }

        public void TakeDamage(int fleetType, int[] playerEngageShipHp) // 적의 함대에게 피해를 입음.
        {
            int setDamage = 0;
            int isOriginHp = 0;

            //데미지 계산 : 방어함대의 방어력 - 공격함대의 공격력
            setDamage = GameInfo.enemyFleet[fleetType].Attack - GameInfo.playerFleet[fleetType].Defence;

            for (int i = 0; i < 3; i++)
            {
                if (GameInfo.playerFleet[i].UnitCount > 0) //수비하는 함대의 유닛수가 1보다 많을 경우 전투 참여
                {
                    if (setDamage > 0) //공격자의 피해가 1보다 높을 경우 적에게 피해를 입힘
                    {
                        GameInfo.playerFleet[i].Hp = GameInfo.playerFleet[i].Hp - setDamage;
                        Console.WriteLine($"적 함대 {GameInfo.enemyFleet[fleetType].Name}은 아군 함대의 {GameInfo.playerFleet[i].Name} 을 공격했다.");
                        Console.WriteLine($"현재 대상의 남은 체력은 {GameInfo.playerFleet[i].Hp} 입니다.");

                        if (GameInfo.playerFleet[i].Hp <= 0) //공격자의 피해가 0이거나 음수일 경우 방어자의 함대 수를 1 감소시킴
                        {
                            GameInfo.playerFleet[i].UnitCount = GameInfo.playerFleet[i].UnitCount - 1;
                            Console.WriteLine($"아군 함대 {GameInfo.playerFleet[i].Name}의 남은 수는 {GameInfo.playerFleet[i].UnitCount} 입니다. ");
                            isOriginHp = Convert.ToInt32(playerEngageShipHp[i]);
                            GameInfo.playerFleet[i].Hp = isOriginHp;
                        }
                    }
                    else if (setDamage <= 0) //공격자의 공격력이 방어력보다 낮을 경우 피해가 1로 고정
                    {
                        GameInfo.playerFleet[i].Hp = GameInfo.playerFleet[i].Hp - 1;
                        Console.WriteLine("적의 공격력이 낮아 피해를 못줬다.");
                    }
                }
                else if (GameInfo.playerFleet[fleetType].UnitCount <= 0) //방어자의 유닛 수가 0일 경우 출력
                {
                    Console.WriteLine("전장에 적이 없다.");
                }
            }
        }
    }

    class EnemyFleet
    {
        public void HaveAttack(int[] originEnemyShipCount, Ship[] ships, int fleetType, int[] playerEngageShipHp) // 적의 함대가 아군 함대에게 공격을 시도함.
        {
            float setAttackChance = 0;

            Random attackChance = new Random();
            setAttackChance = attackChance.Next(0, 100);

            for (fleetType = 0; fleetType < 3; fleetType++) // 구축함,순양함, 전함 순으로 공격을 진행함.
            {
                if (originEnemyShipCount[fleetType] <= 0)
                {
                    for (int i = 0; i < originEnemyShipCount[fleetType]; i++)
                    {
                        Console.WriteLine($"적 {ships[fleetType].Name}이 없어, {ships[fleetType + 1].Name}으로 변경합니다.");
                        Console.WriteLine($"{ships[fleetType + 1].Name} / {originEnemyShipCount[fleetType + 1]}");
                        GameInfo.player.TakeDamage(fleetType + 1, playerEngageShipHp);
                    }
                }

                else if (originEnemyShipCount[fleetType] > 0)
                {
                    for (int i = 0; i < originEnemyShipCount[fleetType]; i++)
                    {
                        Console.WriteLine($"{ships[fleetType].Name} / {originEnemyShipCount[fleetType]}");
                        GameInfo.player.TakeDamage(fleetType, playerEngageShipHp);
                    }
                }
            }
        }
        
        public void TakeDamage(int fleetType, int[] originenemyFleetHp) // 아군함대에게 피해를 받음.
        {
            int setDamage = 0;
            int isOriginHp = 0;

            //데미지 계산 : 방어함대의 방어력 - 공격함대의 공격력
            setDamage = GameInfo.playerFleet[fleetType].Attack - GameInfo.enemyFleet[fleetType].Defence;

            for (int i = 0; i < 3; i++)
            {
                if (GameInfo.enemyFleet[i].UnitCount > 0) //수비하는 함대의 유닛수가 1보다 많을 경우.
                {
                    if (setDamage > 0)
                    {
                        GameInfo.enemyFleet[i].Hp = GameInfo.enemyFleet[i].Hp - setDamage;
                        Console.WriteLine($"아군 함대 {GameInfo.playerFleet[fleetType].Name}은 적 함대의 {GameInfo.enemyFleet[i].Name} 을 공격했다.");
                        Console.WriteLine($"현재 대상의 남은 체력은 {GameInfo.enemyFleet[i].Hp} 입니다.");

                        if (GameInfo.enemyFleet[i].Hp <= 0)
                        {
                            GameInfo.enemyFleet[i].UnitCount = GameInfo.enemyFleet[i].UnitCount - 1;
                            Console.WriteLine($"적 함대의 {GameInfo.enemyFleet[i].Name}의 남은 수는 {GameInfo.enemyFleet[i].UnitCount} 입니다. ");
                            isOriginHp = Convert.ToInt32(originenemyFleetHp[i]);
                            GameInfo.enemyFleet[i].Hp = isOriginHp;
                        }
                    }
                    else if (setDamage <= 0)
                    {
                        GameInfo.enemyFleet[i].Hp = GameInfo.enemyFleet[i].Hp - 1;
                        Console.WriteLine("적의 방어력이 높아 피해를 못줬다.");
                    }
                }
                else if (GameInfo.enemyFleet[fleetType].UnitCount <= 0)
                {
                    Console.WriteLine("전장에 적이 없다.");
                }
            }
        }
    }
}
