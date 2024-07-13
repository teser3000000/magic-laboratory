using UnityEngine;

public class DiscardIngredient : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Seed seed))
        {
            other.GetComponentInParent<SeedPool>().ReturnSeedToPool(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
