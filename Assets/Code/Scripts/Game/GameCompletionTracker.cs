using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;

public class GameCompletionTracker : MonoBehaviour
{
    private HashSet<GameObject> _createdItems;
    private HashSet<GameObject> _requiredItems;

    public event System.Action OnGameCompleted;

    [Inject]
    public void Construct(RecipeManager recipeManager, RecipeResults recipeResults)
    {
        _createdItems = new HashSet<GameObject>();
        _requiredItems = new HashSet<GameObject> { recipeResults.Crystal, recipeResults.MagicWand };
        Initialize(recipeManager);
    }

    private void Initialize(RecipeManager recipeManager)
    {
        recipeManager.LastCreatedRecipe
            .Where(result => result != null && _requiredItems.Contains(result))
            .Subscribe(result =>
            {
                _createdItems.Add(result);
                CheckCompletion();
            })
            .AddTo(this);
    }

    private void CheckCompletion()
    {
        if (_requiredItems.IsSubsetOf(_createdItems))
        {
            OnGameCompleted?.Invoke();
            Debug.Log("Game Completed! All required items have been created.");
        }
    }
}
