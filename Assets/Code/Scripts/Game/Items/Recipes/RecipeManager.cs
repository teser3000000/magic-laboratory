using System.Collections.Generic;

public class RecipeManager
{
    private List<Recipe> _recipes = new List<Recipe>();

    public void RegisterRecipe(Recipe recipe)
    {
        _recipes.Add(recipe);
    }

    public string FindRecipe(List<IIngredient> ingredient)
    {
        foreach (var recipe in _recipes)
        {
            if (recipe.Matches(ingredient))
            {
                return recipe.Result;
            }
        }
        return null;
    }
}
