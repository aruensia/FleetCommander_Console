using System;

namespace FleetComander_Console
{
    interface IShipAbility
    {
        // 모든 함선들은 스킬을 가져야 한다.
        void Skill(int attack, int defence);
    }


    public abstract class Ship : IShipAbility
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
            Skill(Attack, Defence);
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
            set
            {
                if (value <= 0)
                {
                    _unitcount = 0;
                }
                else
                {
                    _unitcount = value;
                }
            }
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

        public abstract void Skill(int attack, int defence);
    }

    #region 함선 클래스

    class Dsestroyer : Ship, IShipAbility
    {
        //순양함과 전함의 공격을 우선적으로 맞아주는 함급. 구축함이 적을 수록 순양함과 전함이 공격받을 확률이 늘어난다.

        public Dsestroyer(string name, int attack, int defence, int hp, int unitCount, int screenpiercing, int price, int dac, int cac, int bac) : base(name, attack, defence, hp, unitCount, screenpiercing, price, dac, cac, bac)
        {

        }

        public override void Skill(int increseattack, int defence)
        {
            Console.WriteLine("스킬을 사용 했다.");
        }
    }

    class Cruiser : Ship, IShipAbility
    {
        //적당히 튼튼함. 구축함을 처리하기에 좋으며, 전함에게 딜을 어느정도 박을 수 있음

        public Cruiser(string name, int attack, int defence, int hp, int unitCount, int screenpiercing, int price, int dac, int cac, int bac) : base(name, attack, defence, hp, unitCount, screenpiercing, price, dac, cac, bac)
        {

        }

        public override void Skill(int increseattack, int defence)
        {
            UseSwgWeapon();
        }

        void UseSwgWeapon()
        {
            Console.WriteLine("순양함 스킬 썼다");
        }
    }

    class Battleship : Ship, IShipAbility
    {
        // 체력과 방어력이 높으며 상대 전함을 저지하는 함급.

        public Battleship(string name, int attack, int defence, int hp, int unitCount, int screenpiercing, int price, int dac, int cac, int bac) : base(name, attack, defence, hp, unitCount, screenpiercing, price, dac, cac, bac)
        {

        }


        public override void Skill(int increseattack, int defence)
        {                                                                                                                                                                                    
            int skillUseChance = GameInfo.attackChance.Next(1, 5); // 1 이상 5미만

            switch (skillUseChance)
            {
                case 1:
                    UseBeamWeapon();
                    break;

                case 2:
                    UseEpicWeapon();
                    break;
                case 3:
                    UseMissileWeapon();
                    break;
                case 4:
                    Console.WriteLine("스킬을 사용하지 않았다.");
                    break;
            }

            void UseBeamWeapon()
            {
                Console.WriteLine("전함 스킬 썼다");
            }

            void UseEpicWeapon()
            {
                Console.WriteLine("전함 스킬 썼다");
            }

            void UseMissileWeapon()
            {
                Console.WriteLine("전함 스킬 썼다");
            }
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
            GameInfo.playerFleet[0] = new Dsestroyer("제국 구축함", 10, 1, 10, 10, 50, 100, 7, 0, 2);
            GameInfo.playerFleet[1] = new Cruiser("제국 순양함", 20, 5, 200, 1, 500, 1000, 2, 5, 5);
            GameInfo.playerFleet[2] = new Battleship("제국 전함", 100, 15, 1000, 0, 30, 3000, 1, 6, 8);

            GameInfo.enemyFleet[0] = new Dsestroyer("연합국 구축함", 10, 1, 10, 5, 50, 30, 7, 0, 2);
            GameInfo.enemyFleet[1] = new Cruiser("연합국 순양함", 20, 5, 200, 1, 500, 30, 2, 5, 5);
            GameInfo.enemyFleet[2] = new Battleship("연합국 전함", 100, 15, 1000, 0, 3000, 30, 1, 6, 8);

        }
    }

    partial class BattleSetting //세팅된 함대가 전투를 하기 위해 세팅.
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
        public int[] emptyPlayerFleetHp = new int[3];
        public int[] emptyEnemyFleetCount = new int[3];
        public int[] emptyEnemyFleetHp = new int[3];

        public void BattleFleid(int setRewardRate)
        {
            FleetBattle();
            BattleResult();
            BattleFinishReward(GameInfo.playSequence.SetupEnemyGameLevel(), WinnerJudgment(GameInfo.enemyFleet), setRewardRate);
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
            // 전투에 투입했던 함대들을 임시 배열에 저장시킴
            if (userFirst == true)
            {
                for (int i = 0; i < 3; i++)
                {
                    emptyEnemyFleetCount[i] = defenderFleetCount[i];
                    emptyEnemyFleetHp[i] = defenderFleetHp[i];
                }
            }

            else if (userFirst == false)
            {
                for (int i = 0; i < 3; i++)
                {
                    emptyPlayerFleetCount[i] = defenderFleetCount[i];
                    emptyPlayerFleetHp[i] = defenderFleetHp[i];
                }
            }
        }

        public void EndBattleResult()
        {
            //턴 종료 시 임시배열에 넣은 함대를 기존 함대 배열에 넣어서 턴 종료 시 전투 결과에 따른 유닛 변화를 본 함대에 적용시킴
            for (int i = 0; i < 3; i++)
            {
                GameInfo.enemyFleet[i].UnitCount = emptyEnemyFleetCount[i];
                GameInfo.playerFleet[i].UnitCount = emptyPlayerFleetCount[i];
            }
        }

        public int WinnerJudgment(Ship[] enemyFleet) // 승패에 따라 승리 점수를 지급. 승리점수에 비례하여 돈을 획득.
        {
            int victoryValue = 0;
            bool victoryConditionChk = false;

            for (int i = 0; i < 3; i++)
            {
                if (enemyFleet[i].UnitCount > 0)
                {
                    victoryConditionChk = false;
                }
                else if (enemyFleet[i].UnitCount == 0)
                {
                    victoryConditionChk = true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (enemyFleet[i].UnitCount > 0)
                {
                    victoryConditionChk = false;
                }
            }

            if (victoryConditionChk == true)
            {
                victoryValue = 3;
                Console.WriteLine("대 승리입니다! 적을 전멸 시켰습니다!");
            }
            else if (victoryConditionChk == false)
            {
                victoryValue = 1;
                Console.WriteLine("적이 후퇴합니다!");
            }

            return victoryValue;
        }

        public void BattleFinishReward(int gameLevel, int userIsWinner, int rewardRate)
        {
            int showGetMoney = 0;

            if (userIsWinner > 0)
            {
                GameInfo.user.Money = GameInfo.user.Money + (showGetMoney = (gameLevel + userIsWinner) * 5000);
                Console.WriteLine($"전공에 대한 보상이 지급되었습니다.");
                Console.WriteLine($"보상으로 {showGetMoney}원을 얻었습니다!");
                ConsoleKeyInfo setkey;
                setkey = Console.ReadKey();

                if (setkey.Key == ConsoleKey.Enter)
                {
                    GameInfo.consoleUiSetting.ConsoleClear();
                }
            }
            GameInfo._nextenemylevel++;
        }
    }

    partial class BattleFleets
    {
        public bool ScreenPiercing(int[] defenderFleetCount, int[] attackerFleetCount) ////구축함이 방벽역할을 하는 함수. (공격자 순양함 + 공격자 전함 / 방어자 구축함)
        {
            bool isFleetScreenPiercing = false;

            if (defenderFleetCount[0] >= (attackerFleetCount[1] + attackerFleetCount[2]))
            {
                float setAttackChance = GameInfo.attackChance.Next(0, 100);
                float setPiercingChance = (100 - (((attackerFleetCount[1] + attackerFleetCount[2]) / (float)defenderFleetCount[0]) * 100));

                if (setAttackChance > setPiercingChance)
                {
                    //Console.WriteLine("적의 스크린을 관통했습니다.");
                    //Console.WriteLine($"{setAttackChance}, {setPiercingChance}");

                    return isFleetScreenPiercing = true;
                }
            }

            return isFleetScreenPiercing;
        }

        public bool FleetAttack(int[] attackerFleetCount, int[] defenderFleetCount, int[] defenderFleetHp, int[] originFleetHp, int fleetType, string[] attackerFleetName, string[] defenderFleetName, bool userFirst) // 아군 함대가 적의 함대에게 우선 공격을 가함. 공격 후, 공격 찬스 만큼 추가 공격을 가함.
        {
            float setAttackChance = 0;
            bool battleOverCheck = false;

            setAttackChance = GameInfo.attackChance.Next(0, 100);

            for (fleetType = 0; fleetType < 3; fleetType++) // 구축함, 순양함, 전함 순으로 공격을 진행함.
            {
                if (attackerFleetCount[fleetType] > 0)
                {
                    for (int i = 0; i < attackerFleetCount[fleetType]; i++)
                    {

                        Console.WriteLine($"{attackerFleetName[fleetType]} / {attackerFleetCount[fleetType]}");
                        bool isPiercing = ScreenPiercing(defenderFleetCount, attackerFleetCount);
                        GameInfo.battleFleets.UseSkill(userFirst);
                        battleOverCheck = GameInfo.battleFleets.TakeDamage(fleetType, attackerFleetCount, defenderFleetCount, defenderFleetHp, originFleetHp, attackerFleetName, defenderFleetName, isPiercing);

                        if (battleOverCheck == true)
                        {
                            return battleOverCheck;
                        }
                    }
                }
                else if (attackerFleetCount[fleetType] <= 0 && attackerFleetCount[fleetType] <= 0 && attackerFleetCount[fleetType] <= 0)
                {
                    Console.WriteLine("공격할 수 있는 함선이 없습니다.");
                    break;
                }

                if (battleOverCheck == true)
                {
                    return battleOverCheck;
                }
            }

            return battleOverCheck;
        }

        public bool TakeDamage(int fleetType, int[] attackerFleetCount, int[] defenderFleetCount, int[] defenderFleetHp, int[] originFleetHp, string[] attackerFleetName, string[] defenderFleetName, bool isPiercing) // 적의 함대에게 피해를 입음.
        {
            int setDamage = 0;
            int isOriginHp = 0;
            bool battleOverCheck = false;
            bool[] isShotCondition = new bool[3];
            isShotCondition[0] = true;
            isShotCondition[1] = true;
            isShotCondition[2] = true;

            //데미지 계산 : 방어함대의 방어력 - 공격함대의 공격력
            setDamage = GameInfo.enemyFleet[fleetType].Attack - GameInfo.playerFleet[fleetType].Defence;

            if (isPiercing == true) //적 함대의 스크린을 관통했다면 순차적으로 모두 공격
            {

                if (defenderFleetCount[0] <= 0 && defenderFleetCount[1] <= 0 && defenderFleetCount[2] <= 0)
                {
                    Console.WriteLine("해당 전투에서 적이 전멸했습니다!");
                    battleOverCheck = true;
                    return battleOverCheck;
                }

                while (isShotCondition[0] == true || isShotCondition[1] == true || isShotCondition[2] == true)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (defenderFleetCount[i] > 0)
                        {
                            if (setDamage > 0) //공격자의 피해가 1보다 높을 경우 적에게 피해를 입힘
                            {
                                defenderFleetHp[i] = defenderFleetHp[i] - setDamage;
                               
                                if (defenderFleetHp[i] <= 0) //공격자의 피해가 0이거나 음수일 경우 방어자의 함대 수를 1 감소시킴
                                {
                                    defenderFleetCount[i] = Convert.ToInt32(defenderFleetCount[i]) - 1;
                                    Console.WriteLine($"방어 함대 {defenderFleetName[i]}의 남은 수는 {defenderFleetCount[i]} 입니다. ");
                                    isOriginHp = Convert.ToInt32(originFleetHp[i]);
                                    defenderFleetHp[i] = isOriginHp;
                                    isShotCondition[i] = false;
                                }
                                isShotCondition[i] = false;
                            }

                            else if (setDamage <= 0) //공격자의 공격력이 방어력보다 낮을 경우 피해가 1로 고정
                            {
                                defenderFleetHp[i] = defenderFleetHp[i] - 1;
                                isShotCondition[i] = false;
                                Console.WriteLine("적의 공격력이 낮아 피해를 못줬다.");
                            }
                        }

                        else if (defenderFleetCount[i] <= 0)
                        {
                            if (defenderFleetCount[i] >= defenderFleetCount.Length)
                            {
                                defenderFleetCount[i] = 2;
                                if (setDamage > 0) //공격자의 피해가 1보다 높을 경우 적에게 피해를 입힘
                                {
                                    defenderFleetHp[i] = defenderFleetHp[i] - setDamage;

                                    if (defenderFleetHp[i] <= 0) //공격자의 피해가 0이거나 음수일 경우 방어자의 함대 수를 1 감소시킴
                                    {
                                        defenderFleetCount[i] = Convert.ToInt32(defenderFleetCount[i]) - 1;
                                        Console.WriteLine($"방어 함대 {defenderFleetName[i]}의 남은 수는 {defenderFleetCount[i]} 입니다. ");
                                        isOriginHp = Convert.ToInt32(originFleetHp[i]);
                                        defenderFleetHp[i] = isOriginHp;
                                        isShotCondition[i] = false;
                                    }
                                    isShotCondition[i] = false;
                                }

                                else if (setDamage <= 0) //공격자의 공격력이 방어력보다 낮을 경우 피해가 1로 고정
                                {
                                    defenderFleetHp[i] = defenderFleetHp[i] - 1;
                                    isShotCondition[i] = false;
                                    Console.WriteLine("적의 공격력이 낮아 피해를 못줬다.");
                                }
                                defenderFleetHp[i] = defenderFleetCount[i - 1];
                            }
                            else
                            {
                                if (setDamage > 0) //공격자의 피해가 1보다 높을 경우 적에게 피해를 입힘
                                {
                                    defenderFleetHp[i] = defenderFleetHp[i] - setDamage;

                                    if (defenderFleetHp[i] <= 0) //공격자의 피해가 0이거나 음수일 경우 방어자의 함대 수를 1 감소시킴
                                    {
                                        defenderFleetCount[i] = Convert.ToInt32(defenderFleetCount[i]) - 1;
                                        Console.WriteLine($"방어 함대 {defenderFleetName[i]}의 남은 수는 {defenderFleetCount[i]} 입니다. ");
                                        isOriginHp = Convert.ToInt32(originFleetHp[i]);
                                        defenderFleetHp[i] = isOriginHp;
                                        isShotCondition[i] = false;
                                    }
                                    isShotCondition[i] = false;
                                }

                                else if (setDamage <= 0) //공격자의 공격력이 방어력보다 낮을 경우 피해가 1로 고정
                                {
                                    defenderFleetHp[i] = defenderFleetHp[i] - 1;
                                    isShotCondition[i] = false;
                                    Console.WriteLine("적의 공격력이 낮아 피해를 못줬다.");
                                }
                                defenderFleetCount[i] = defenderFleetCount[i - 1];
                            }

                            isShotCondition[i] = false;
                            break;
                        }
                    }
                }

            }
            else if (isPiercing == false) // 적 함대의 스크린을 관통하지 못했다면 공격 대상을 구축함으로 고정
            {
                if (defenderFleetCount[0] <= 0 && defenderFleetCount[1] <= 0 && defenderFleetCount[2] <= 0)
                {
                    Console.WriteLine("해당 전투에서 적이 전멸했습니다!");
                    battleOverCheck = true;
                    return battleOverCheck;
                }
                else if (defenderFleetCount[0] > 0) //수비하는 함대의 유닛수가 1보다 많을 경우 전투 참여
                {

                    if (setDamage > 0) //공격자의 피해가 1보다 높을 경우 적에게 피해를 입힘
                    {
                        defenderFleetHp[0] = defenderFleetHp[0] - setDamage;
                        Console.WriteLine($"공격 함대 {attackerFleetName[fleetType]}은 방어 함대의 {defenderFleetName[0]} 을 공격했다.");
                        Console.WriteLine($"현재 대상의 남은 체력은 {defenderFleetHp[0]} 입니다.");

                        if (defenderFleetHp[0] <= 0) //공격자의 피해가 0이거나 음수일 경우 방어자의 함대 수를 1 감소시킴
                        {
                            defenderFleetCount[0] = Convert.ToInt32(defenderFleetCount[0]) - 1;
                            Console.WriteLine($"방어 함대 {defenderFleetName[0]}의 남은 수는 {defenderFleetCount[0]} 입니다. ");
                            isOriginHp = Convert.ToInt32(originFleetHp[0]);
                            defenderFleetHp[0] = isOriginHp;
                        }
                    }
                    else if (setDamage <= 0) //공격자의 공격력이 방어력보다 낮을 경우 피해가 1로 고정
                    {
                        defenderFleetHp[0] = defenderFleetHp[0] - 1;
                        Console.WriteLine("적의 공격력이 낮아 피해를 못줬다.");
                    }
                }
                else if (defenderFleetCount[0] <= 0) //방어자의 유닛 수가 0일 경우 출력
                {
                    Console.WriteLine($"전장에 {defenderFleetName[0]}이 없다.");
                    if (defenderFleetCount[1] == 0)  // 방어자의 순양함 수가 0일 경우 전함을 공격
                    {

                        if (setDamage > 0)
                        {
                            defenderFleetHp[2] = defenderFleetHp[2] - setDamage;
                            Console.WriteLine($"방어자의 {defenderFleetName[1]}이 없어, 대상을 {defenderFleetName[2]}로 변경했습니다.");
                            Console.WriteLine($"공격 함대 {attackerFleetName[fleetType]}은 방어 함대의 {defenderFleetName[2]} 을 공격했다.");
                            Console.WriteLine($"현재 대상의 남은 체력은 {defenderFleetHp[2]} 입니다.");

                            if (defenderFleetHp[2] <= 0) //공격자의 피해가 0이거나 음수일 경우 방어자의 함대 수를 1 감소시킴
                            {
                                defenderFleetCount[2] = Convert.ToInt32(defenderFleetCount[2]) - 1;
                                Console.WriteLine($"방어 함대 {defenderFleetName[2]}의 남은 수는 {defenderFleetCount[2]} 입니다. ");
                                isOriginHp = Convert.ToInt32(originFleetHp[2]);
                                defenderFleetHp[2] = isOriginHp;
                            }
                        }
                        else if (setDamage <= 0)
                        {
                            defenderFleetHp[2] = defenderFleetHp[2] - 1;
                            Console.WriteLine("적의 공격력이 낮아 피해를 못줬다.");
                        }
                    }
                    else if (defenderFleetCount[0] == 0)  // 방어자의 구축함의 수가 0일 경우 순양함을 공격
                    {
                        if (setDamage > 0)
                        {
                            defenderFleetHp[1] = defenderFleetHp[1] - setDamage;
                            Console.WriteLine($"방어자의 {defenderFleetName[0]}이 없어, 대상을 {defenderFleetName[1]}로 변경했습니다.");
                            Console.WriteLine($"공격 함대 {attackerFleetName[fleetType]}은 방어 함대의 {defenderFleetName[1]} 을 공격했다.");
                            Console.WriteLine($"현재 대상의 남은 체력은 {defenderFleetHp[1]} 입니다.");

                            if (defenderFleetHp[1] <= 0) //공격자의 피해가 0이거나 음수일 경우 방어자의 함대 수를 1 감소시킴
                            {
                                defenderFleetCount[1] = Convert.ToInt32(defenderFleetCount[1]) - 1;
                                Console.WriteLine($"방어 함대 {defenderFleetName[1]}의 남은 수는 {defenderFleetCount[1]} 입니다. ");
                                isOriginHp = Convert.ToInt32(originFleetHp[1]);
                                defenderFleetHp[1] = isOriginHp;
                            }
                        }
                        else if (setDamage <= 0)
                        {
                            defenderFleetHp[1] = defenderFleetHp[1] - 1;
                            Console.WriteLine("적의 공격력이 낮아 피해를 못줬다.");
                        }
                    }
                }
            }
            return battleOverCheck;
        }
    }
}
