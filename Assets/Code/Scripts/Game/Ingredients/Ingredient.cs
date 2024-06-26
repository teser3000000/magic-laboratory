using UnityEngine;

public enum PotionType { Red, Green, Purple }
public enum MetalType { Gold, RedMetal }
public enum SeedType { Watermelon, Sunflower }
public enum MushroomType { Blue }
public enum FlowerType { Daisy }


public abstract class Ingredient<T> : MonoBehaviour, IIngredient
{
    [SerializeField] private T type;
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

    protected virtual void DropIntoCauldron() { }
}