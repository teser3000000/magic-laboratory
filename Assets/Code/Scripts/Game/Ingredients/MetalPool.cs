using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalPool : MonoBehaviour
{
    [SerializeField] private GameObject metalPrefab; // ������ �������
    [SerializeField] private int poolSize = 10; // ������ ����
    [SerializeField] private float spawnRadius = 1.0f; // ������ ������ �������

    private Queue<GameObject> metalPool = new Queue<GameObject>();

    private void Start()
    {
        InitializePool();
    }

    // ������������� ����
    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            var metal = Instantiate(metalPrefab, transform);
            metal.SetActive(false);
            metalPool.Enqueue(metal);
        }
    }

    // ����� �������
    public void SpawnMetal(Vector3 position, int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (metalPool.Count > 0)
            {
                var metal = metalPool.Dequeue();
                metal.transform.position = position;
                metal.SetActive(true);
            }
        }
    }

    // ������� ������� � ���
    public void ReturnMetalToPool(GameObject metal)
    {
        metal.SetActive(false);
        metalPool.Enqueue(metal);
    }
}
