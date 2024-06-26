using static UnityEditor.Progress;
using System.Collections.Generic;

public class RecipeFactory
{
    private static RecipeFactory _instance;
    private RecipeManager _recipeManager;

    private RecipeFactory()
    {
        _recipeManager = new RecipeManager();
        InitializeRecipes();
    }

    public static RecipeFactory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new RecipeFactory();
            }
            return _instance;
        }
    }

    public RecipeManager RecipeManager
    {
        get { return _recipeManager; }
    }

    // Метод инициализации рецептов
    // Добавьте другие рецепты здесь
    private void InitializeRecipes()
    {
        _recipeManager.RegisterRecipe(new Recipe(
            new List<IIngredient>
            {
                new Potion (PotionType.Red ),
                new Metal (MetalType.Gold)
                /*new Item { Type = ItemType.Flower, Color = Color.Blue },
                new Item { Type = ItemType.Potion }*/
            },
            "Crystal"));

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
