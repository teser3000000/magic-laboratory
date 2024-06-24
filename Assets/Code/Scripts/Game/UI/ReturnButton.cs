using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class ReturnButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image _imageButton;
    private CameraMovement _cameraMovement;
    private Tween _currentTween;
    private Button _button;

    [Inject]
    private void Construct(CameraMovement cameraMovement)
    {
        _cameraMovement = cameraMovement;
    }

    private void Start()
    {
        _imageButton = GetComponent<Image>();
        _button = GetComponent<Button>();

        _cameraMovement.isApproximate.Subscribe(_ =>
        {
            if (_cameraMovement.isApproximate.Value == true)
            {
                _currentTween.Kill();
                _button.interactable = true;
            }
            else
            {
                _currentTween.Kill();
                _button.interactable = false;
                _currentTween = _imageButton.DOFade(0f, 1f);
            };
        }).AddTo(this);

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(_button.interactable) 
            _currentTween = _imageButton.DOFade(0.5f, 1f).SetEase(Ease.InOutQuad);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_button.interactable) 
            _currentTween = _imageButton.DOFade(0f, 1f).SetEase(Ease.InOutQuad);
    }


}
