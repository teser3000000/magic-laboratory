using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Potion : Ingredient<PotionType>
{
    public Potion(PotionType type) : base(type) { }

    public override IEnumerator ResetOriginalState()
    {
        yield return new WaitForSeconds(11.4f);

        TurningTheIcon();
        ResetInteracteble();
    }

    protected override void DropIntoCauldron()
    {
        IIngredient newIngredient = gameObject.GetComponent<Potion>();
 
        _testMixing.AddIngredientToPot(newIngredient);

        ReturnToTheInitialCamera();
    }

}