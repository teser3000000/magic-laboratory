using System.Collections.Generic;
using static UnityEditor.Progress;

public class Recipe
{
    public List<Item> Ingredients { get; private set; }
    public string Result { get; private set; }

    public Recipe(List<Item> ingredients, string result)
    {
        Ingredients = ingredients;
        Result = result;
    }

    public bool Matches(List<Item> items)
    {
        if (items.Count != Ingredients.Count)
            return false;

        var itemsSorted = new List<Item>(items);
        var ingredientsSorted = new List<Item>(Ingredients);

        /*itemsSorted.Sort((a, b) => a.Type.CompareTo(b.Type));
        ingredientsSorted.Sort((a, b) => a.Type.CompareTo(b.Type));

        for (int i = 0; i < itemsSorted.Count; i++)
        {
            if (itemsSorted[i].Type != ingredientsSorted[i].Type || itemsSorted[i].Color != ingredientsSorted[i].Color)
                return false;
        }*/

        return true;
    }
}
