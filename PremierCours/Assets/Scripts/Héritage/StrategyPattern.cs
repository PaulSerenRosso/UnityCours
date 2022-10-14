using UnityEngine;

public class StrategyPattern : MonoBehaviour
{
    void Start()
    {
        Animal sparky = new Dog();
        Animal tweety = new Bird();

        Debug.Log(sparky.flyingType.Fly());
        Debug.Log(tweety.flyingType.Fly());
        
        sparky.SetFlyingAbility(new FlyingSuperFast());
        
        Debug.Log(sparky.flyingType.Fly());
        Debug.Log(tweety.flyingType.Fly());
    }
}

public interface IFly
{
    string Fly();
}

class ItFly : IFly
{
    public string Fly()
    {
        return "Flying high";
    }
}

class CantFly : IFly
{
    public string Fly()
    {
        return "I can't fly";
    }
}

class FlyingSuperFast : IFly
{
    public string Fly()
    {
        return "Fly super fast";
    }
}

public class Animal
{
    public IFly flyingType;

    public void TryToFly()
    {
        Debug.Log(flyingType.Fly());
    }

    public void SetFlyingAbility(IFly newFlyingType)
    {
        flyingType = newFlyingType;
    }
}

public class Dog : Animal
{
    public  Dog()
    {
        flyingType = new CantFly();
    }
}

public class Bird : Animal
{
    public  Bird()
    {
        flyingType = new ItFly();
    }
}

public class Cat : Animal
{
    public  Cat()
    {
        flyingType = new CantFly();
    }
}