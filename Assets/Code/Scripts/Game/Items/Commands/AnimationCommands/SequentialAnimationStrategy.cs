using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class SequentialAnimationStrategy : IAnimationStrategy
{
    private List<(IAnimationCommand command, float delay, Ease ease)> _commands = new List<(IAnimationCommand, float, Ease)>();

    public void AddCommand(IAnimationCommand command, float delay = 0f, Ease ease = Ease.Linear)
    {
        _commands.Add((command, delay, ease));
    }

    public void PlayAnimation(Transform transform)
    {
        Sequence sequence = DOTween.Sequence();

        foreach (var (command, delay, ease) in _commands)
        {
            sequence.AppendCallback(() => command.Execute(transform, ease));
            if (delay > 0)
            {
                sequence.AppendInterval(delay);
            }
        }

        sequence.Play();
    }
}
