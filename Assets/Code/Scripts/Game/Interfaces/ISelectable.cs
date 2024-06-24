using System;

public interface ISelectable
{
    public Action OnSelected { get; set; }
    public Action OnDeselected { get; set; }

    public void Select()
    {
        OnSelected?.Invoke();
    }

    public void Deselect()
    {
        OnDeselected?.Invoke();
    }
}
