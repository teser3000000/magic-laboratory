using UnityEngine;

public enum ItemType
{
    Flower,
    Mushroom,
    Potion
}

public abstract class item : ItemBase
{
    [SerializeField] protected Transform endPointAnimation;

    public ItemType Type { get; private set; }
    public GameObject prefab { get; private set; }

    protected IAnimationStrategy animationStrategy;
    protected Vector3 startPoint;

    public void SetAnimationStrategy(IAnimationStrategy strategy)
    {
        animationStrategy = strategy;
    }

    public void PerformAnimation()
    {
        animationStrategy?.PlayAnimation(gameObject.transform);
    }

    public override void Activate()
    {
        if (endPointAnimation == null) return;
        StartingAnActionItem();
    }

    public override void Deactivate()
    {
        StartingAnDeactionItem();
    }

    public override bool TryInteract()
    {
        Activate();
        return true;
    }
    protected virtual void StartingAnActionItem() { }
    protected virtual void StartingAnDeactionItem() { }
}
