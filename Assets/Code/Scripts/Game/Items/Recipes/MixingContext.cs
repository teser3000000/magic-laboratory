using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MixingContext : MonoBehaviour
{
    private RecipeManager _recipeManager;

    [Inject] private void Construct(RecipeManager recipeManager)
    {
        _recipeManager = recipeManager;
    }

    public void Mix(List<IIngredient> items)
    {
        GameObject result = _recipeManager.FindRecipe(items);
        if (result != null)
        {
            StartCoroutine(CreateResultWithDelay(result, 4f));
        }
        else
        {
            Debug.Log("No matching recipe found.");
        }
    }

    private IEnumerator CreateResultWithDelay(GameObject result, float delay)
    {
        yield return new WaitForSeconds(delay); // Ожидаем задержку
        Instantiate(result, new Vector3(0.613f, 0, -9.177f), Quaternion.identity); // Создаём префаб
    }
}
