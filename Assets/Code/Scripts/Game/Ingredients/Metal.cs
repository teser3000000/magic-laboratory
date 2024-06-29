using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Metal : Ingredient<MetalType>
{
    public Metal(MetalType type) : base(type) { }

    protected override void DropIntoCauldron()
    {
        IIngredient newIngredient = gameObject.GetComponent<Metal>();
        _testMixing.AddIngredientToPot(newIngredient);
    }
}
