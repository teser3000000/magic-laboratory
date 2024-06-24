using static UnityEditor.Progress;
using System.Collections.Generic;
using UnityEngine;

public class MixingContext
{
    private RecipeManager _recipeManager;

    public MixingContext(RecipeManager recipeManager)
    {
        _recipeManager = recipeManager;
    }

    public void Mix(List<Item> items)
    {
        string result = _recipeManager.FindRecipe(items);
        if (result != null)
        {
            Debug.Log("Created: " + result);
        }
        else
        {
            Debug.Log("No matching recipe found.");
        }
    }
}
