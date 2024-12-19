using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace FleetComander_Console
{
    internal class Program
    {
        // 함대의 구조체를 작성
        struct Ship
        {
            public string name; // 함선 이름
            public int type; // 함선 타입 : 0없음, 1 구축함, 2 순양함, 3 전함 

            public int dsestroyerAttack; // 구축함에 대한 연속 공격 값
            public int cruiserAttack; // 순양함에 대한 연속 공격 값
            public int battleshipAttack; // 전함에 대한 연속 공격 값

            public int attack; // 공격력
            public int defence; // 방어력
            public int hp; // 체력
            public int count; // 함대 수
            public int price; // 판매가격
        }

        //공격자와 방어자를 구분하기 위한 함수
        struct AttackerDefenderCheck
        {
            //공격자 정보
            public int attackerCountCheck;
            public int attackerAttackCheck;
            public int attackerType;

            //방어자 정보
            public int defenderCountCheck;
            public int defenderDefenceCheck;
            public int defenderHpCheck;
            public int defenderType;
        }

        // 유저의 기본 정보에 관한 구조체를 작성
        struct UserInfo
        {
            public int rank; // 유저의 계급
            public int money; // 유저가 가진 돈
            public int defaultExp; // 유저의 시작 경험치
            public int victoryCount; //유저가 전투에 승리한 횟수
        }

        //메인에서 유저의 기본 정보를 세팅한 함수를 세팅을 한다.
        //기본 정보는 유저의 기본 함대 값 : 구축함 10대, 순양함 2대 , 전함 0대.
        //세팅한 함수를 메인에서 배열을 반환받아 UI 함수에 매개변수로 준다.
        //UI함수에서 기본 목록을 설정한다.
        // ---------- 1. 턴 정보 / 2. 내 함대 수 / 3. 상점 / 4. 다음 적의 정보 / 5. 전투 버튼

        static void Main(string[] args)
        {
            //Ship dsestroyer;
            //Ship cruiser;
            //Ship battleship;

            UserInfo player = new UserInfo();
            Ship[] userFleet = new Ship[4];
            Ship[] enemyFleet = new Ship[4];

            SettingManager(player, userFleet, enemyFleet);
            //SetUi(userFleet);
            BattleSatting(userFleet, enemyFleet, player);
        }


        
        //유저가 게임 실행 시 플레이 하기 위해 함대를 세팅을 해준다.
        static void DefaultUserFleetSetting(Ship[] userfleets)
        {
            Ship dsestroyer;
            Ship cruiser;
            Ship battleship;
            Ship empty;

            dsestroyer.name = "구축함";
            dsestroyer.type = 1;

            dsestroyer.dsestroyerAttack = 7;
            dsestroyer.cruiserAttack = 2;
            dsestroyer.battleshipAttack = 2;


            dsestroyer.attack = 10;
            dsestroyer.defence = 1;
            dsestroyer.hp = 10;
            dsestroyer.count = 100;
            dsestroyer.price = 50;
            //---------------

            cruiser.name = "순양함";
            cruiser.type = 2;

            cruiser.dsestroyerAttack = 2;
            cruiser.cruiserAttack = 5;
            cruiser.battleshipAttack = 5;


            cruiser.attack = 20;
            cruiser.defence = 5;
            cruiser.hp = 200;
            cruiser.count = 10;
            cruiser.price = 500;
            //------------

            battleship.name = "전함";
            battleship.type = 3;

            battleship.dsestroyerAttack = 2;
            battleship.cruiserAttack = 6;
            battleship.battleshipAttack = 8;


            battleship.attack = 100;
            battleship.defence = 15;
            battleship.hp = 1000;
            battleship.count = 5;
            battleship.price = 3000;
            //------------

            empty.name = "비어있음";
            empty.type = 0;

            empty.dsestroyerAttack =0;
            empty.cruiserAttack = 0;
            empty.battleshipAttack = 0;


            empty.attack = 0;
            empty.defence = 0;
            empty.hp = 0;
            empty.count = 99999;
            empty.price = 0;


            userfleets[0] = dsestroyer;
            userfleets[1] = cruiser;
            userfleets[2] = battleship;
            userfleets[3] = empty;
        }

        //유저가 상대할 최초의 적 정보를 세팅해준다.
        static void DefaultEnemyFleetSetting(Ship[] enemyfleets)
        {
            Ship dsestroyer;
            Ship cruiser;
            Ship battleship;
            Ship empty;

            dsestroyer.name = "구축함";
            dsestroyer.type = 1;

            dsestroyer.dsestroyerAttack = 7;
            dsestroyer.cruiserAttack = 2;
            dsestroyer.battleshipAttack = 2;


            dsestroyer.attack = 10;
            dsestroyer.defence = 1;
            dsestroyer.hp = 10;
            dsestroyer.count = 40;
            dsestroyer.price = 50;
            //---------------

            cruiser.name = "순양함";
            cruiser.type = 2;

            cruiser.dsestroyerAttack = 2;
            cruiser.cruiserAttack = 5;
            cruiser.battleshipAttack = 5;


            cruiser.attack = 20;
            cruiser.defence = 5;
            cruiser.hp = 200;
            cruiser.count = 30;
            cruiser.price = 500;
            //------------

            battleship.name = "전함";
            battleship.type = 3;

            battleship.dsestroyerAttack = 5;
            battleship.cruiserAttack = 10;
            battleship.battleshipAttack = 1;


            battleship.attack = 100;
            battleship.defence = 15;
            battleship.hp = 1000;
            battleship.count = 0;
            battleship.price = 3000;
            //-----------


            empty.name = "비어있음";
            empty.type = 0;

            empty.dsestroyerAttack = 0;
            empty.cruiserAttack = 0;
            empty.battleshipAttack = 0;


            empty.attack = 0;
            empty.defence = 0;
            empty.hp = 0;
            empty.count = 99999;
            empty.price = 0;

            enemyfleets[0] = dsestroyer;
            enemyfleets[1] = cruiser;
            enemyfleets[2] = battleship;
            enemyfleets[3] = empty;
        }

        //모든 첫 초기화에 필요한 함수를 호출하는 함수.
        static void SettingManager(UserInfo player, Ship[] userFleet, Ship[] enemyFleet)
        {
            DefaultUserFleetSetting(userFleet);
            DefaultEnemyFleetSetting(enemyFleet);
            UserSetting(player);
        }

        static void SetUi(Ship[] fleets)
        {
            int setUiMenuNumber = 0;

            Console.WriteLine("{0}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{2}", "┌", "ㅡ", "┐", " ");
            Console.WriteLine("{4}{3}①함대{3}정보{3}보기{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{4}", "┌", "ㅡ", "┐", "  ", "│");
            Console.WriteLine("{4}{3}②함선{3}상점{3}가기{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{4}", "┌", "ㅡ", "┐", "  ", "│");
            Console.WriteLine("{4}{3}①다음{3}적{3}정보{3}보기{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{4}", "┌", "ㅡ", "┐", "  ", "│");
            Console.WriteLine("{4}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{4}", "┌", "ㅡ", "┐", "  ", "│");
            Console.WriteLine("{4}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{4}", "┌", "ㅡ", "┐", "  ", "│");
            Console.WriteLine("{4}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{4}", "┌", "ㅡ", "┐", "  ", "│");
            Console.WriteLine("{0}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{2}", "└", "ㅡ", "┘", " ");
            Console.WriteLine("{0}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{2}", "┌", "ㅡ", "┐", " ");
            Console.WriteLine("{4}{3}{3}매뉴를{3}입력하세요{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{3}{4}", "┌", "ㅡ", "┐", "  ", "│");
            Console.WriteLine("{0}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{2}", "└", "ㅡ", "┘", " ");
            Console.SetCursorPosition(2, 11);


            //Console.ReadLine();
            setUiMenuNumber = int.Parse(Console.ReadLine());






            //Console.SetCursorPosition(0, 0);
        }


        //게임 실행 시 최초의 유저 정보를 세팅하는 함수.
        static void UserSetting(UserInfo player)
        {
            player.rank = 1;
            player.money = 1000;
            player.victoryCount = 0;
        }

        //상점에 관련된 정보를 호출하는 함수.
        //static int FleetShop(int userinfo)
        //{
        //    int 
        //}

        //데미지 계산을 하는 함수.
        static void DamageCalculate(Ship[] userfleet , Ship[] enemyfleet , int fleettpye , AttackerDefenderCheck attackerDefenderCheck ,bool setAttacker)
        {
            int setDamage = 0;
            int copyHp = 0;

            //공격자와 방어자를 결정하는 if문.
            if ( setAttacker == true)
            {
                attackerDefenderCheck.attackerCountCheck = userfleet[fleettpye].count;
                attackerDefenderCheck.attackerAttackCheck = userfleet[fleettpye].attack;
                attackerDefenderCheck.defenderCountCheck = enemyfleet[fleettpye].count;
                attackerDefenderCheck.defenderDefenceCheck = enemyfleet[fleettpye].defence;
                attackerDefenderCheck.defenderHpCheck = enemyfleet[fleettpye].hp;
            }
            else
            {
                attackerDefenderCheck.attackerCountCheck = enemyfleet[fleettpye].count;
                attackerDefenderCheck.attackerAttackCheck = enemyfleet[fleettpye].attack;
                attackerDefenderCheck.defenderCountCheck = userfleet[fleettpye].count;
                attackerDefenderCheck.defenderDefenceCheck = userfleet[fleettpye].defence;
                attackerDefenderCheck.defenderHpCheck = userfleet[fleettpye].hp;
            }
            //Console.WriteLine($"데미지 계산 {setDamage}");

            //데미지 계산식 : 데미지 = 공격자의 공격력 - 방어자의 방어력
            setDamage = attackerDefenderCheck.attackerAttackCheck - attackerDefenderCheck.defenderDefenceCheck;
            copyHp = attackerDefenderCheck.defenderHpCheck;

            //수비자의 함대 수가 0보다 많다면 if문으로 진입
            if (attackerDefenderCheck.defenderCountCheck > 0)
            {
                if (setDamage > 0)
                {
                    //함선의 피해 계산식 : 체력 = 체력 - 데미지
                    attackerDefenderCheck.defenderHpCheck = attackerDefenderCheck.defenderHpCheck- setDamage;

                    if (attackerDefenderCheck.defenderHpCheck <= 0)
                    {
                        attackerDefenderCheck.defenderCountCheck = attackerDefenderCheck.defenderCountCheck - 1;
                        
                        attackerDefenderCheck.defenderHpCheck = copyHp;

                        //Console.WriteLine($"유저 {userfleet[0].name}의 남은 체력 : {userfleet[0].hp}");
                        //Console.WriteLine($"적 함대 수{userfleet[0].count}");
                    }
                    else if (setDamage <= 0)
                    {
                        attackerDefenderCheck.defenderHpCheck = attackerDefenderCheck.defenderHpCheck - 1;
                        //Console.WriteLine($"방어력이 높다");
                    }
                }
            }
            else
            {
                //Console.WriteLine($"적의 {enemyfleet[fleettpye].name}부대가 전멸했습니다.");
            }

            if (setAttacker == true)
            {
                userfleet[fleettpye].count = attackerDefenderCheck.attackerCountCheck;
                userfleet[fleettpye].attack = attackerDefenderCheck.attackerAttackCheck;
                enemyfleet[fleettpye].count = attackerDefenderCheck.defenderCountCheck;
                enemyfleet[fleettpye].defence = attackerDefenderCheck.defenderDefenceCheck;
                enemyfleet[fleettpye].hp = attackerDefenderCheck.defenderHpCheck;
            }
            else
            {
                enemyfleet[fleettpye].count = attackerDefenderCheck.attackerCountCheck;
                enemyfleet[fleettpye].attack = attackerDefenderCheck.attackerAttackCheck;
                userfleet[fleettpye].count = attackerDefenderCheck.defenderCountCheck;
                userfleet[fleettpye].defence = attackerDefenderCheck.defenderDefenceCheck;
                userfleet[fleettpye].hp = attackerDefenderCheck.defenderHpCheck;
            }
        }

        //전투를 하기 전 턴과 전투에 관련된 함수를 호출하는 함수
        static void BattleSatting(Ship[] userFleet, Ship[] enemyFleet, UserInfo player)
        {
            int[] battleCount = new int[4];
            int[] orignalEnemyCount = new int[4];
            int turn =  1;

            //유저 함대 수를 배열 0~2까지 저장한다.

            battleCount[0] = userFleet[0].count;
            battleCount[1] = userFleet[1].count;
            battleCount[2] = userFleet[2].count;
            battleCount[3] = userFleet[3].count;

            //적이 공격할 때 죽기 전 원래 함대수를 배열을 통해 0~2까지 저장한다.
            orignalEnemyCount[0] = enemyFleet[0].count;
            orignalEnemyCount[1] = enemyFleet[1].count;
            orignalEnemyCount[2] = enemyFleet[2].count;

            //전투는 총 6회 진행되며 승패는 적의 전멸을 기준으로 판단한다. 만일 적을 전멸시키지 못했으면 무승부로 판단한다.
            //유저턴이 반드시 먼저 진행된다.
            //전투는 아군의 함선들이 함급에 맞게 순차사격을 한다. 구축함 -> 순양함 -> 전함
            //사격의 대상은 구축함 -> 순양함 -> 전함 순으로 모두 한 번씩 사격하고, 연속사격을 할 수 있을 경우 사격 도중에 연속사격을 진행한다.

            for (int i = 0; i < turn; i++)
            {
                Console.WriteLine("--------유저의 차례--------");
                UserBattleSimulator(battleCount, userFleet, enemyFleet);
                Console.WriteLine("-----------------남은 적의 전투기 수" + enemyFleet[0].count);
                Console.WriteLine("-----------------남은 적의 순양함 수" + enemyFleet[1].count);
                Console.WriteLine("-----------------남은 적의 전함 수" + enemyFleet[2].count);
                Console.WriteLine("--------적의 차례--------");
                EnemyBattleSimulator(battleCount, userFleet, enemyFleet , orignalEnemyCount);
                Console.WriteLine("-----------------남은 유저의 전투기 수" + userFleet[0].count);
                Console.WriteLine("-----------------남은 유저의 순양함 수" + userFleet[1].count);
                Console.WriteLine("-----------------남은 유저의 전함 수" + userFleet[2].count);
            }
        }

        //유저가 적을 공격하기 위한 정보를 관리하는 함수
        static int UserBattleSimulator(int[] battleCount, Ship[] userfleet, Ship[] enemyfleet)
        {
            int result = 0;
            int attackChance = 0;
            bool setAttack = true;

            //공자 방자 결정 및 해당 캐릭터들에 대한 정보를 가지고 있을 구조체.
            AttackerDefenderCheck attackerDefenderCheck = new AttackerDefenderCheck();
            
            bool endBattle = false;

            Random attackChanceValue = new Random();

            for( int fleetType = 0; fleetType <4; fleetType++)
            {
                if(battleCount[fleetType] == battleCount[3])
                {
                    break;
                }

                for (int i = 0; i <= userfleet[fleetType].count; i++)
                {
                    DamageCalculate(userfleet, enemyfleet, fleetType ,attackerDefenderCheck , setAttack);
                    float setAttackChanceValue = attackChanceValue.Next(0, 100);
                    
                    attackerDefenderCheck.defenderType = enemyfleet[fleetType].type;

                    if (userfleet[fleetType].count == 0)
                    {
                        Console.WriteLine($"함선이 없습니다. 함선 이름 : {userfleet[fleetType].name} / 함선 수 : {userfleet[fleetType].count}");
                        break;
                    }

                    switch (attackerDefenderCheck.defenderType)
                    {
                        case 1:
                            attackChance = ((userfleet[fleetType].dsestroyerAttack - 1) % userfleet[fleetType].dsestroyerAttack) * 10;
                            break;
                        case 2:
                            attackChance = ((userfleet[fleetType].cruiserAttack - 1) % userfleet[fleetType].cruiserAttack) * 10;
                            break;
                        case 3:
                            attackChance = ((userfleet[fleetType].battleshipAttack - 1) % userfleet[fleetType].battleshipAttack) * 10;
                            break;
                    }

                    if (attackChance >= setAttackChanceValue)
                    {
                        if (endBattle == true)
                        {
                            break;
                        }

                        DamageCalculate(userfleet, enemyfleet , fleetType , attackerDefenderCheck , setAttack);

                    }

                    else if (attackChance < setAttackChanceValue)
                    {
                       Console.WriteLine("적이 공격을 피했습니다.");
                    }
                }

            }

            return result;
        }

        //적이 유저를 공격에 관련된 정보를 관리하는 함수
        static int EnemyBattleSimulator(int[] battleCount, Ship[] userfleet, Ship[] enemyfleet , int[] enemycount)
        {
            int result = 0;
            int attackChance = 0;
            bool setAttack = false;

            int[] reSetCount = new int[3];

            //공격받기 전 적의 함대수를 현재 적 함대수에 대입.

            

            enemyfleet[0].count = enemycount[0];
            enemyfleet[1].count = enemycount[1];
            enemyfleet[2].count = enemycount[2];

            bool endBattle = false;

            AttackerDefenderCheck attackerDefenderCheck = new AttackerDefenderCheck();

            Random attackChanceValue = new Random();

            for (int fleetType = 0; fleetType < 4; fleetType++)
            {
                if (battleCount[fleetType] == battleCount[3])
                {
                    break;
                }

                for (int i = 0; i < userfleet[fleetType].count; i++)
                {
                    DamageCalculate(userfleet, enemyfleet, fleetType, attackerDefenderCheck, setAttack);
                    float setAttackChanceValue = attackChanceValue.Next(0, 100);

                    attackerDefenderCheck.defenderType = enemyfleet[fleetType].type;

                    if (userfleet[fleetType].count == 0)
                    {
                        Console.WriteLine($"함선이 없습니다. 함선 이름 : {userfleet[fleetType].name} / 함선 수 : {userfleet[fleetType].count}");
                        break;
                    }

                    switch (attackerDefenderCheck.defenderType)
                    {
                        case 1:
                            attackChance = ((enemyfleet[fleetType].dsestroyerAttack - 1) % enemyfleet[fleetType].dsestroyerAttack) * 10;
                            break;
                        case 2:
                            attackChance = ((enemyfleet[fleetType].cruiserAttack - 1) % enemyfleet[fleetType].cruiserAttack) * 10;
                            break;
                        case 3:
                            attackChance = ((enemyfleet[fleetType].battleshipAttack - 1) % enemyfleet[fleetType].battleshipAttack) * 10;
                            break;
                    }

                    if (attackChance >= setAttackChanceValue)
                    {
                        if (endBattle == true)
                        {
                            break;
                        }

                        DamageCalculate(userfleet, enemyfleet, fleetType, attackerDefenderCheck, setAttack);
                    }

                    else if (attackChance < setAttackChanceValue)
                    {
                        Console.WriteLine("적이 공격을 피했습니다.");
                    }
                }

            }

            //리턴.. 안쓸거같은데..
            return result;
        }
    }
}
