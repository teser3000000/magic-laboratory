using System.Collections;
using UnityEngine;

public static class AnimationLock
{
    private static bool isAnimationPlaying = false;

    public static bool IsAnimationPlaying
    {
        get { return isAnimationPlaying; }
        private set { isAnimationPlaying = value; }
    }

    public static void SetAnimationState(bool state)
    {
        isAnimationPlaying = state;
    }

    public static IEnumerator AnimationCompleted(float delay)
    {
        yield return new WaitForSeconds(delay);
        SetAnimationState(false);
    }
}
