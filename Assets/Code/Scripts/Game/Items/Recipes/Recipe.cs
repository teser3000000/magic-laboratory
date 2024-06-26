using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static UnityEditor.Progress;

public class Recipe
{
    public List<IIngredient> Ingredients { get; private set; }
    public string Result { get; private set; }

    public Recipe(List<IIngredient> ingredients, string result)
    {
        Ingredients = ingredients;
        Result = result;
    }

    public bool Matches(List<IIngredient> ingredients)
    {
        if (ingredients.Count != Ingredients.Count)
            return false;

        var itemsSorted = ingredients.Select(i => i.Type).ToList();
        var ingredientsSorted = Ingredients.Select(i => i.Type).ToList();

        itemsSorted.Sort();
        ingredientsSorted.Sort();

        for (int i = 0; i < itemsSorted.Count; i++)
        {
            if (itemsSorted[i] != ingredientsSorted[i])
                return false;
        }

        return true;
    }
}
