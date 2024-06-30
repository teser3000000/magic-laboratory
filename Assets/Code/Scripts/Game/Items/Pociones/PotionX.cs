using DG.Tweening;
using UniRx;
using UnityEngine;
using UnitySimpleLiquid;
using Zenject;

public class PotionX /*: item*/
{
    [SerializeField] private GameObject stopper;
    [SerializeField] private SplitController splitController;
    [SerializeField] private Transform liftingHeightStopper;

    [SerializeField] private float angleOfInclination;

    private Vector3 _startStopperTransform;

    private CompositeDisposable _disposables = new CompositeDisposable();

    private CameraMovement _cameraMovement;

    [Inject]
    private void Construct(CameraMovement cameraMovement)
    {
        _cameraMovement = cameraMovement;
    }

    private void Start()
    {
        /*_startStopperTransform = stopper.transform.localPosition;
        startPoint = transform.position;

        splitController.IsSplitingReactive.Skip(3).Subscribe(_ =>
        {
            StartingAnDeactionItem();
        }).AddTo(_disposables);*/
    }

   /* protected override void StartingAnActionItem()
    {
        if (!AnimationLock.IsAnimationPlaying)
        {
            AnimationLock.SetAnimationState(true);
            ReturnToTheInitialCamera();

            var strategy = new SequentialAnimationStrategy();

            strategy.AddCommand(new MoveCommand(endPointAnimation.position, 1f), 2f, Ease.InOutQuad);
            stopper.transform.DOLocalMove(liftingHeightStopper.localPosition, 1f).SetEase(Ease.InOutElastic).SetDelay(1f);
            strategy.AddCommand(new LocalRotateCommand(new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, angleOfInclination), 1f), 2f, Ease.InOutQuad);
            *//*Sequence mySequence = DOTween.Sequence();

            mySequence.Append(transform*//*.parent.transform.parent*//*.DOMove(endPointAnimation.position, 1f).SetEase(Ease.InOutQuad));
            mySequence.AppendInterval(0.2f);
            mySequence.Append(stopper.transform.DOLocalMove(liftingHeightStopper.localPosition *//*new Vector3(0.0001310068f, 0.225f, 0.0002933532f)*//*, 1f).SetEase(Ease.InOutElastic).SetDelay(0.2f));
            mySequence.Append(transform*//*.parent.transform.parent*//*.DORotate(new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, angleOfInclination*//*97.254f*//*), 1f));

            mySequence.Play();*//*
            SetAnimationStrategy(strategy);
            PerformAnimation();
        }

    }*/

    /*protected override void StartingAnDeactionItem()
    {
        var strategy = new SequentialAnimationStrategy();

        strategy.AddCommand(new LocalRotateCommand(new Vector3(0, 0, 0), 1f), 2f, Ease.InOutQuad);
        stopper.transform.DOLocalMove(_startStopperTransform, 1f).SetEase(Ease.InOutElastic).SetDelay(1f).OnComplete(() =>
        {
            AnimationLock.SetAnimationState(false);
        });
        strategy.AddCommand(new MoveCommand(new Vector3(startPoint.x, startPoint.y, startPoint.z), 1f), 2f, Ease.InOutQuad);
        *//*Sequence mySequence = DOTween.Sequence();

        mySequence.AppendInterval(0.3f);
        mySequence.Append(transform.parent.transform.parent.DOLocalRotate(new Vector3(0, 0, 0), 1f)*//*.SetDelay(0.3f)*//*);
        //mySequence.Append(stopper.transform.DOLocalMove(new Vector3(_startStopperTransform.x, _startStopperTransform.y, _startStopperTransform.z), 1f).SetEase(Ease.InOutElastic));
        mySequence.Append(transform.parent.transform.parent.DOMove(new Vector3(startPoint.x, startPoint.y, startPoint.z), 1f).SetEase(Ease.InOutQuad));

        mySequence.Play();*//*

        SetAnimationStrategy(strategy);
        PerformAnimation();
    }*/
    
}
