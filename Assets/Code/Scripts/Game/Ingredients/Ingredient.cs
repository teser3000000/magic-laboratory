using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public enum PotionType { Red, Green, Purple }
public enum MetalType { Gold, RedMetal }
public enum SeedType { Watermelon, Sunflower }
public enum MushroomType { Blue }
public enum FlowerType { Daisy }


public abstract class Ingredient<T> : MonoBehaviour, IIngredient, IAnimatable
{
    [SerializeField] private T type;
    private Animation _anim;
    protected TestMixing _testMixing;

    [Inject] private void Construct(TestMixing testMixing)
    {
        _testMixing = testMixing;
    }

    public T Type
    {
        get { return type; }
        private set { type = value; }
    }
    object IIngredient.Type => Type.ToString();

    protected Ingredient(T initialType)
    {
        Type = initialType;
    }
    private void Awake()
    {
        _anim = gameObject.GetComponent<Animation>();
    }

    public void PlayAnimation()
    {
        _anim.Play();
    }

    public virtual void TryInteract()
    {
        PlayAnimation();
        DropIntoCauldron();
    }

    protected virtual void DropIntoCauldron() { }
}