using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMixing : MonoBehaviour
{
    private RecipeManager _recipeManager;
    private MixingContext _mixingContext;

    private void Awake()
    {
        _recipeManager = RecipeFactory.Instance.RecipeManager;
        _mixingContext = new MixingContext(_recipeManager);
    }

    private void Start()
    {
        List<IIngredient> selectedIngredient = new List<IIngredient>
        {
            new Potion (PotionType.Red ),
            new Metal (MetalType.Gold),
        };

        // Выполнение смешивания
        _mixingContext.Mix(selectedIngredient);
    }

}
