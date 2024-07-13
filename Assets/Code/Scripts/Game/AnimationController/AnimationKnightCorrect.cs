using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationKnightCorrect : MonoBehaviour
{
    [SerializeField] private Transform pointReturn;
    [SerializeField] private GameObject persona;

    public void Return()
    {
        persona.transform.position = pointReturn.position;
    }
}
