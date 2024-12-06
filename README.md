# FleetComander_Console
 콘솔_함대 전투 **시뮬레이터**

## 구조체 설명

```cs
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



간단한 함대 전투 확인할 수 있습니다.
