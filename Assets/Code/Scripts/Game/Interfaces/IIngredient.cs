using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIngredient
{
    object Type { get; }

    public void TryInteract();
}
