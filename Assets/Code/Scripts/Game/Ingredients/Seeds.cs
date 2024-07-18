using System.Collections;
using UnityEngine;

public class Seeds : Ingredient<SeedType>
{
    public Seeds(SeedType type) : base(type) { }

    [SerializeField] private Transform seedSpawn;
    [SerializeField] private GameObject vfxReset;

    private SeedPool _seedPool;

    private Material _dissolveMaterial;

    private void Start()
    {
        //_meshRenderer = vfxReset.GetComponent<MeshRenderer>();
        _dissolveMaterial = vfxReset.GetComponent<MeshRenderer>().material;

        _seedPool = GetComponent<SeedPool>();

        SpawnSeeds();

        ProcessAllChildren();

        StartCoroutine(ProcessAllChildrenWithDelay(0.8f));
    }

    protected override void DropIntoCauldron()
    {
        IIngredient newIngredient = gameObject.GetComponent<Seeds>();
        _testMixing.AddIngredientToPot(newIngredient);

        ReturnToTheInitialCamera();
    }

    IEnumerator ChangeValue(float start, float end, float duration, float delay)
    {
        yield return new WaitForSeconds(delay);
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

        StartCoroutine(ChangeValue(0.21f, -0.02f, 2f, 0f));
        StartCoroutine(ChangeValue(-0.02f, -0.52f, 1f, 2f));

        SpawnSeeds();
    }

    private void ProcessAllChildren()
    {
        foreach (Transform child in transform)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            MeshCollider meshCollider = child.GetComponent<MeshCollider>();

            if (rb != null)
            {
                rb.isKinematic = false;
                rb.useGravity = true;
            }

            if (meshCollider != null)
                meshCollider.enabled = true;
        }
    }

    private IEnumerator ProcessAllChildrenWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        foreach (Transform child in transform)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            MeshCollider meshCollider = child.GetComponent<MeshCollider>();

            if (rb != null)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
            }

            if (meshCollider != null)
                meshCollider.enabled = false;
        }
    }

    private void SpawnSeeds()
    {
        _seedPool.SpawnSeeds(seedSpawn.position, 5);
    }
}
