using System.Collections.Generic;
using static UnityEditor.Progress;

public class RecipeManager
{
    private List<Recipe> _recipes = new List<Recipe>();

    public void RegisterRecipe(Recipe recipe)
    {
        _recipes.Add(recipe);
    }

    public string FindRecipe(List<Item> items)
    {
        foreach (var recipe in _recipes)
        {
            if (recipe.Matches(items))
            {
                return recipe.Result;
            }
        }
        return null;
    }
}
