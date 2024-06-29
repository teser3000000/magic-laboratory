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
                new Potion (PotionType.Red ),
                new Metal (MetalType.Gold),
                new Metal (MetalType.Gold)
                /*new Item { Type = ItemType.Flower, Color = Color.Blue },
                new Item { Type = ItemType.Potion }*/
            },
            _recipeResults.Crystal));
         
        /*_recipeManager.RegisterRecipe(new Recipe(
            new List<IIngredient>
            {
                new Item { Type = ItemType.Mushroom },
                new Item { Type = ItemType.Flower },
                new Item { Type = ItemType.Potion }
            },
            "Magic Wand"));*/

    }
}
