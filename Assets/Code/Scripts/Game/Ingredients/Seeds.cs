using UnityEngine;

public class Seeds : Ingredient<SeedType>
{
    public Seeds(SeedType type) : base(type) { }

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
            child.GetComponent<MeshCollider>().enabled = true;
            if (rb != null)
            {
                rb.useGravity = true;
            }
        }
    }


}
