using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface IInteroperable
{
    //public bool IsInteracted { get; }

    public Action OnInteracted { get; set; }

    public bool TryInteract();

}
