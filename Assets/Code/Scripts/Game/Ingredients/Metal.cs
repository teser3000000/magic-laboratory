using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Metal : Ingredient<MetalType>
{
    private Rigidbody _rb;

    private Vector3 _originalPosition;
    private Quaternion _originalRotation;

    private MeshRenderer _meshRenderer;
    private Material _dissolveMaterial;

    public Metal(MetalType type) : base(type) { }

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _dissolveMaterial = _meshRenderer.materials[1];

        _rb = GetComponent<Rigidbody>();

        _originalPosition = transform.position;
        _originalRotation = transform.rotation;
    }

    IEnumerator ChangeValue(float start, float end, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            _dissolveMaterial.SetFloat("Vector1_EFD20677", Mathf.Lerp(start, end, elapsed / duration)); 
            yield return null;
        }
    }

    public override IEnumerator ResetOriginalState()
    {
        yield return new WaitForSeconds(11.5f);
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
        StartCoroutine(ChangeValue(0.21f, -0.02f, 5f));
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
