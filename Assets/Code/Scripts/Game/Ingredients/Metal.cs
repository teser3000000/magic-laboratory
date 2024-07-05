using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Metal : Ingredient<MetalType>
{
    private Rigidbody _rb;

    public Metal(MetalType type) : base(type) { }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    protected override void DropIntoCauldron()
    {
        IIngredient newIngredient = gameObject.GetComponent<Metal>();
        _testMixing.AddIngredientToPot(newIngredient);

        ReturnToTheInitialCamera();
    }

    private void EnableGravityAndDestroy()
    {
        _rb.useGravity = true;
        Destroy(gameObject, 3f);
    }
}
