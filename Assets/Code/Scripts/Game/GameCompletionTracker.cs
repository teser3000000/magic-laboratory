using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class GameCompletionTracker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject cutscene1;
    [SerializeField] private GameObject cutscene2;

    private TriggerAnimationStrips _triggerAnimationStrips;
    private CameraMovement _cameraMovement;

    private HashSet<GameObject> _createdItems;
    private HashSet<GameObject> _requiredItems;

    private IDisposable _gameTimerDisposable;
    public ReactiveProperty<float> TimeLeft { get; private set; }

    public float gameTimerDuration = 20; // Длительность таймера в секундах, например 5 минут

    public event System.Action OnGameCompleted;
    public event System.Action OnGameFailed;

    [Inject]
    public void Construct(RecipeManager recipeManager, RecipeResults recipeResults, TriggerAnimationStrips triggerAnimationStrips, CameraMovement cameraMovement)
    {
        _createdItems = new HashSet<GameObject>();
        _requiredItems = new HashSet<GameObject> { recipeResults.Crystal, recipeResults.MagicWand, recipeResults.Statue};
        _triggerAnimationStrips = triggerAnimationStrips;
        _cameraMovement = cameraMovement;

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

        _triggerAnimationStrips.AppearanceCinematicStripes();
        cutscene1.SetActive(true);
        // StartGameTimer();
    }

    public void StartGameTimer()
    {
        timerText.transform.parent.gameObject.SetActive(true);

        TimeLeft = new ReactiveProperty<float>(gameTimerDuration);

        _gameTimerDisposable = Observable.Interval(System.TimeSpan.FromSeconds(1))
            .TakeWhile(_ => TimeLeft.Value > 0)
            .Subscribe(_ =>
            {
                TimeLeft.Value -= 1;
                timerText.text = TimeLeft.Value.ToString();
                if (TimeLeft.Value <= 0)
                {
                    OnGameFailed?.Invoke();
                    Debug.Log("Game Failed! Time is up.");
                }
            }, () =>
            {
                if (TimeLeft.Value <= 0)
                {
                    OnGameFailed?.Invoke();
                    Debug.Log("Game Failed! Time is up.");
                }
            })
            .AddTo(this);
    }

    private void CheckCompletion()
    {
        if (_requiredItems.IsSubsetOf(_createdItems))
        {
            OnGameCompleted?.Invoke();
            //Debug.Log("Game Completed! All required items have been created.");
            Debug.Log("Game!");
            _triggerAnimationStrips.RefundTimer(-1032f);
            StartCoroutine(ComletionGame(11.5f));
            _gameTimerDisposable?.Dispose();
        }
    }

    private IEnumerator ComletionGame(float delay)
    {
        yield return new WaitForSeconds(delay);
        cutscene2.SetActive(true);
        _cameraMovement.SelectCamera(5);
    }

    private void OnDestroy()
    {
        _gameTimerDisposable?.Dispose();
    }

}
