using System.Collections;
using UnityEngine;

public class Seeds : Ingredient<SeedType>
{
    public Seeds(SeedType type) : base(type) { }

    [SerializeField] private Transform seedSpawn;
    private SeedPool _seedPool;

    private void Start()
    {
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
