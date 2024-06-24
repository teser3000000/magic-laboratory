using DG.Tweening;
using UnityEngine;

public interface IAnimationCommand
{
    void Execute(Transform transform, Ease ease);
}
