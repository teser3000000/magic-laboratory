using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class RecipeManager
{
    private List<Recipe> _recipes = new List<Recipe>();

    public ReactiveProperty<GameObject> LastCreatedRecipe { get; private set; } = new ReactiveProperty<GameObject>();

    public void RegisterRecipe(Recipe recipe)
    {
        _recipes.Add(recipe);
    }

    public GameObject FindRecipe(List<IIngredient> ingredient)
    {
        foreach (var recipe in _recipes)
        {
            if (recipe.Matches(ingredient))
            {
                LastCreatedRecipe.Value = recipe.Result;
                return recipe.Result;
            }
            else
            {
                Debug.Log("POp");
            }
        }
        return null;
    }
}
