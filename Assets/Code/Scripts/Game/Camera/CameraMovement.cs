using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private List<GameObject> cameraPoints;
    [SerializeField] private UnityEngine.UI.Button moveButtonLeft;
    [SerializeField] private UnityEngine.UI.Button moveButtonRight;

    public ReactiveProperty<bool> isApproximate { get; private set; } = new ReactiveProperty<bool>();

    private CompositeDisposable _disposables = new CompositeDisposable();

    private void Start()
    {
        moveButtonLeft.OnClickAsObservable().Subscribe(_ =>
        {
            SelectCamera(0);
        }).AddTo(_disposables);

        moveButtonRight.OnClickAsObservable().Subscribe(_ =>
        {
            SelectCamera(0);
        }).AddTo(_disposables);
    }

    public void SelectCamera(int number)
    {
        for (int i = 0; i < cameraPoints.Count; i++)
        {
            if (i == number) cameraPoints[i].SetActive(true);
            else cameraPoints[i].SetActive(false);

            if(CameraIsApproximate(number)) isApproximate.Value = true;
            else isApproximate.Value = false;
        }
    }

    private void TurnOffCameraShaking()
    {
        var noise = cameraPoints[3].GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        noise.m_AmplitudeGain = 0;
        //cameraPoints[3].
    }

    private bool CameraIsApproximate(int number)
    {
        if (number == 0) return false;
        return true;
    }
}
