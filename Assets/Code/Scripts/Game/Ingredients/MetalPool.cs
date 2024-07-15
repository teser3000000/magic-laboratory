using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalPool : MonoBehaviour
{
    [SerializeField] private GameObject metalPrefab; // Префаб семечки
    [SerializeField] private int poolSize = 10; // Размер пула
    [SerializeField] private float spawnRadius = 1.0f; // Радиус спавна семечек

    private Queue<GameObject> metalPool = new Queue<GameObject>();

    private void Start()
    {
        InitializePool();
    }

    // Инициализация пула
    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            var metal = Instantiate(metalPrefab, transform);
            metal.SetActive(false);
            metalPool.Enqueue(metal);
        }
    }

    // Спавн семечек
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

    // Возврат семечки в пул
    public void ReturnMetalToPool(GameObject metal)
    {
        metal.SetActive(false);
        metalPool.Enqueue(metal);
    }
}
