using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RecipeFactory 
{
    private RecipeManager _recipeManager;
    private RecipeResults _recipeResults;

    [Inject] private void Construct(RecipeResults recipeResults, RecipeManager recipeManager)
    {
        _recipeManager = recipeManager;
        _recipeResults = recipeResults;
        InitializeRecipes();
    }

    public RecipeManager RecipeManager
    {
        get { return _recipeManager; }
    }

    // Метод инициализации рецептов

    private void InitializeRecipes()
    {
        _recipeManager.RegisterRecipe(new Recipe(
            new List<IIngredient>
            {
                new Potion (PotionType.Green),
                new Metal (MetalType.Gold),
                new Metal (MetalType.Gold)
            },
            _recipeResults.Crystal));

        _recipeManager.RegisterRecipe(new Recipe(
            new List<IIngredient>
            {
                new Potion (PotionType.Red),
                new Seeds (SeedType.Watermelon),
                new Seeds (SeedType.Sunflower)
            },
            _recipeResults.MagicWand));

    }
}
