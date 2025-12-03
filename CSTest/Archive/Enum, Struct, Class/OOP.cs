using System.Linq.Expressions;

public class OOP
{
    // 추상화: 공통 속성을 뽑아서 하나의 개념으로 묶는 것
    // 캡슐화: 내부 정보를 숨기고 외부엔 필요한 기능만 공개
    // 상속: 기존 클래스를 물려받아 코드 재사용.
    // 다형성: 같은 함수로 다양한 행동을 할 수 있게함
    static public void RunTest()
    {
        Mage mage = new Mage();
        mage.UseSpecialSkill();
    }
}

abstract class Player // 추상(abstract) Class는 객체생성이 불가능하다. 
{
    public virtual void Attack()
    {
        Console.WriteLine("플레이어 공격");
    }
    public abstract void UseSpecialSkill();
}

class Knight : Player
{
    public override void Attack()
    {
        Console.WriteLine("기사 공격");

    }
    public override void UseSpecialSkill()
    {
        Console.WriteLine("기사 스킬");
    }
}
class Mage : Player
{
    public override void Attack()
    {
        Console.WriteLine("메이지 공격");
    }
    public override void UseSpecialSkill()
    {
        Console.WriteLine("메이지 스킬");
    }
}