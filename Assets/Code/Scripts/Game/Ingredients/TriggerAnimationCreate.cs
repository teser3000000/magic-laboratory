using DG.Tweening;
using UniRx;
using UnityEngine;

public class TriggerAnimationCreate : MonoBehaviour
{
    [SerializeField] private GameObject cinematicStripes1;
    [SerializeField] private GameObject cinematicStripes2;
    public ReactiveCommand appearanceCinematicStripesCommand { get; private set; } = new ReactiveCommand();

    private Tween _tween;
    private CompositeDisposable _disposables = new CompositeDisposable();

    private void Start()
    {
        appearanceCinematicStripesCommand.Subscribe(_ =>
        {
            AppearanceCinematicStripes();
        }).AddTo(_disposables);
    }

    private void AppearanceCinematicStripes()
    {
         cinematicStripes1.transform.DOMoveY(63f, 0.6f);
         cinematicStripes2.transform.DOMoveY(1019f, 0.6f);
    }
}
