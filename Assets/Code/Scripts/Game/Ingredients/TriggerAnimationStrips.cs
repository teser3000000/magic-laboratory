using DG.Tweening;
using UniRx;
using UnityEngine;

public class TriggerAnimationStrips : MonoBehaviour
{
    [SerializeField] private GameObject cinematicStripes1;
    [SerializeField] private GameObject cinematicStripes2;
    [SerializeField] private GameObject timer;
    public ReactiveCommand appearanceCinematicStripesCommand { get; private set; } = new ReactiveCommand();
    public ReactiveCommand refundCinematicStripesCommand { get; private set; } = new ReactiveCommand();

    private CompositeDisposable _disposables = new CompositeDisposable();

    private void Start()
    {
        appearanceCinematicStripesCommand.Subscribe(_ =>
        {
            AppearanceCinematicStripes();
        }).AddTo(_disposables);

        refundCinematicStripesCommand.Subscribe(_ =>
        {
            DeactivationCinematicStripes();
            RefundCinematicStripes();
        }).AddTo(_disposables);
    }

    public void AppearanceCinematicStripes()
    {
        cinematicStripes1.SetActive(true);
        cinematicStripes2.SetActive(true);

        cinematicStripes1.transform.DOMoveY(63f, 0.6f);
        cinematicStripes2.transform.DOMoveY(1019f, 0.6f);

        RefundTimer(-1032f);
    }

    public void RefundCinematicStripes()
    {
        cinematicStripes1.transform.DOMoveY(-70f, 0.1f);
        cinematicStripes2.transform.DOMoveY(1141f, 0.1f);

        RefundTimer(-862f);
    }

    public void DeactivationCinematicStripes()
    {
        cinematicStripes1.SetActive(false);
        cinematicStripes2.SetActive(false);
    }

    public void RefundTimer(float distance)
    {
        timer.transform.DOLocalMoveX(distance, 0.6f);
    }
}
