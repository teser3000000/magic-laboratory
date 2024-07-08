using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class TestMixing : MonoBehaviour
{
    [SerializeField] private List<IIngredient> selectedIngredients = new List<IIngredient>();

    /*private RecipeFactory _recipeFactory;
    private RecipeManager _recipeManager;*/
    private MixingContext _mixingContext;
   

    private ReactiveProperty<int> _numberOfIngredients = new ReactiveProperty<int>();

    private CompositeDisposable _disposables = new CompositeDisposable();

    [Inject] private void Construct( MixingContext mixingContext)
    {
        _mixingContext = mixingContext;
    }

    private void Start()
    {
        _numberOfIngredients.Where(value => value >= 3).Subscribe(_ =>
        {
            MixingIngredients();
        }).AddTo(_disposables);
    }

    public void AddIngredientToPot(IIngredient ingredient)
    {
        if (ingredient == null) return;
                selectedIngredients.Add(ingredient);

        _numberOfIngredients.Value++;
    }

    private void MixingIngredients()
    {
        _mixingContext.Mix(selectedIngredients);
        ZeroingArray();
    }

    private void ZeroingArray()
    {
        _numberOfIngredients.Value = 0;
        selectedIngredients.Clear();
    }

}
