using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using Zenject;

public class InteractionZone : MonoBehaviour, IInteroperable
{
    [SerializeField] private int cameraNumber;

    private CameraMovement _cameraMovement;

    [Inject] private void Construct(CameraMovement cameraMovement)
    {
        _cameraMovement = cameraMovement;
    }
    public void TryInteract()
    {
        Activate();
    }

    private void Activate()
    {
        _cameraMovement.SelectCamera(cameraNumber);
    }
}
