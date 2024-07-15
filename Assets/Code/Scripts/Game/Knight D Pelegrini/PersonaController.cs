using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonaController : MonoBehaviour
{
    [SerializeField] private GameObject smallBottle;
    [SerializeField] private GameObject seeds;
    [SerializeField] private GameObject seeds2;
    [SerializeField] private GameObject mouse;
    [SerializeField] private GameObject discription;

    private void OpenBottle()
    {
        smallBottle.SetActive(true);
    }

    private void CloseBottle()
    {
        smallBottle.SetActive(false);
    }

    private void ProcessAllChildren()
    {
        foreach (Transform child in seeds.transform)
        {
            child.SetParent(null);
            child.gameObject.SetActive(true);

            Rigidbody rb = child.GetComponent<Rigidbody>();
            if (rb != null)
                rb.useGravity = true;

            MeshCollider collider = child.GetComponent<MeshCollider>();
            if (collider != null)
                collider.enabled = true;

        }
    }
    
    private void ProcessAllChildren2()
    {
        foreach (Transform child in seeds2.transform)
        {
            child.SetParent(null);
            child.gameObject.SetActive(true);

            Rigidbody rb = child.GetComponent<Rigidbody>();
            if (rb != null)
                rb.useGravity = true;

            MeshCollider collider = child.GetComponent<MeshCollider>();
            if (collider != null)
                collider.enabled = true;

        }
    }

    public void ActiveMouse()
    {
        mouse.gameObject.SetActive(true);
    }

    public void ActiveDiscription()
    {
        discription.gameObject.SetActive(true);
    }
}
