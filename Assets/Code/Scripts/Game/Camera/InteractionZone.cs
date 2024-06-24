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

    public Action OnInteracted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public bool TryInteract()
    {
        Activate();
        return true;
    }

    public void Activate()
    {
        _cameraMovement.SelectCamera(cameraNumber);
    }
}
