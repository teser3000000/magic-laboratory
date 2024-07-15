using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Metal : Ingredient<MetalType>
{
    private Rigidbody _rb;

    private Vector3 _originalPosition;
    private Quaternion _originalRotation;

    public Metal(MetalType type) : base(type) { }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _originalPosition = transform.position;
        _originalRotation = transform.rotation;
    }

    public override IEnumerator ResetOriginalState()
    {
        yield return new WaitForSeconds(7);

        TurningTheIcon();
        ResetInteracteble();

        transform.position = _originalPosition;
        transform.rotation = _originalRotation;

        if (_rb != null)
        {
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            _rb.useGravity = false;
        }

        gameObject.SetActive(true);
    }

    protected override void DropIntoCauldron()
    {
        IIngredient newIngredient = gameObject.GetComponent<Metal>();
        _testMixing.AddIngredientToPot(newIngredient);

        ReturnToTheInitialCamera();
    }

    private void EnableGravityAndDestroy()
    {
        _rb.useGravity = true;
        StartCoroutine(DeactivateAfterDelay(3f));
    }

    private IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false); 
    }

}
