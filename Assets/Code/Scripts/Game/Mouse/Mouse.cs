using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ActiveObject()
    {
        gameObject.SetActive(true);
    }

    public void SetTrueAnimationGetUp()
    {
        _animator.SetBool("GetUp", true);
    }
}
