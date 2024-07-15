using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Potion : Ingredient<PotionType>
{
    public Potion(PotionType type) : base(type) { }

    protected override void DropIntoCauldron()
    {
        IIngredient newIngredient = gameObject.GetComponent<Potion>();
 
        _testMixing.AddIngredientToPot(newIngredient);

        ReturnToTheInitialCamera();
    }

}