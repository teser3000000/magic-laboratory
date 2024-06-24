using System;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour, IInteroperable, IActivatable, IDeactivatable, ISelectable
{
    //public bool IsInteracted => throw new NotImplementedException();

    public Action OnInteracted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Action OnSelected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Action OnDeselected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public virtual void Activate() { }

    public virtual void Deactivate() { }

    public virtual bool TryInteract()
    {
        return true;
    }
}
