using System.Collections.Generic;
using UnityEngine;

public class SeedPool : MonoBehaviour
{
    [SerializeField] private GameObject seedPrefab; // ������ �������
    [SerializeField] private int poolSize = 10; // ������ ����
    [SerializeField] private float spawnRadius = 1.0f; // ������ ������ �������

    private Queue<GameObject> seedPool = new Queue<GameObject>();

    private void Start()
    {
        InitializePool();
    }

    // ������������� ����
    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            var seed = Instantiate(seedPrefab, transform);
            seed.SetActive(false);
            seedPool.Enqueue(seed);
        }
    }

    // ����� �������
    public void SpawnSeeds(Vector3 position, int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (seedPool.Count > 0)
            {
                var seed = seedPool.Dequeue();
                seed.transform.position = position + Random.insideUnitSphere * spawnRadius;
                seed.SetActive(true);
            }
        }
    }

    // ������� ������� � ���
    public void ReturnSeedToPool(GameObject seed)
    {
        seed.SetActive(false);
        seedPool.Enqueue(seed);
    }
}
