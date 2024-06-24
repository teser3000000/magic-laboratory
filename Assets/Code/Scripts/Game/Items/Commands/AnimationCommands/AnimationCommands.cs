using DG.Tweening;
using UnityEngine;

public class MoveCommand : IAnimationCommand
{
    private Vector3 _targetPosition;
    private float _duration;

    public MoveCommand(Vector3 targetPosition, float duration)
    {
        _targetPosition = targetPosition;
        _duration = duration;
    }

    public void Execute(Transform transform, Ease ease)
    {
        transform.DOMove(_targetPosition, _duration).SetEase(ease);
    }
}

public class LocalMoveCommand : IAnimationCommand
{
    private Vector3 _targetPosition;
    private float _duration;

    public LocalMoveCommand(Vector3 targetPosition, float duration)
    {
        _targetPosition = targetPosition;
        _duration = duration;
    }

    public void Execute(Transform transform, Ease ease)
    {
        transform.DOLocalMove(_targetPosition, _duration).SetEase(ease);
    }
}

public class RotateCommand : IAnimationCommand
{
    private Vector3 _rotation;
    private float _duration;

    public RotateCommand(Vector3 rotation, float duration)
    {
        _rotation = rotation;
        _duration = duration;
    }

    public void Execute(Transform transform, Ease ease)
    {
        transform.DORotate(_rotation, _duration).SetEase(ease);
    }
}

public class LocalRotateCommand : IAnimationCommand
{
    private Vector3 _rotation;
    private float _duration;

    public LocalRotateCommand(Vector3 rotation, float duration)
    {
        _rotation = rotation;
        _duration = duration;
    }

    public void Execute(Transform transform, Ease ease)
    {
        transform.DOLocalRotate(_rotation, _duration).SetEase(ease);
    }
}

public class ScaleCommand : IAnimationCommand
{
    private Vector3 _scale;
    private float _duration;

    public ScaleCommand(Vector3 scale, float duration)
    {
        _scale = scale;
        _duration = duration;
    }

    public void Execute(Transform transform, Ease ease)
    {
        transform.DOScale(_scale, _duration).SetEase(ease);
    }
}

public class ColorCommand : IAnimationCommand
{
    private Color _color;
    private float _duration;

    public ColorCommand(Color color, float duration)
    {
        _color = color;
        _duration = duration;
    }

    public void Execute(Transform transform, Ease ease)
    {
        Renderer renderer = transform.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.DOColor(_color, _duration).SetEase(ease);
        }
    }
}
