using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonaController : MonoBehaviour
{
    [SerializeField] private GameObject smallBottle;
    [SerializeField] private GameObject smallBottle2;
    [SerializeField] private GameObject smallBottle3;
    [SerializeField] private GameObject seeds;
    [SerializeField] private GameObject seeds2;
    [SerializeField] private GameObject mouse;
    [SerializeField] private GameObject discription;
    [SerializeField] private GameObject congratulationUI;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OpenBottle()
    {
        smallBottle.SetActive(true);
        smallBottle2.SetActive(false);
    }

    private void CloseBottle()
    {
        smallBottle.SetActive(false);
        smallBottle2.SetActive(true);
    }

    private void OpenBottle2CloseBottle3()
    {
        smallBottle2.SetActive(true);
        smallBottle3.SetActive(false);
    }

    private void OpenBottle3CloseBottle2()
    {
        smallBottle2.SetActive(false);
        smallBottle3.SetActive(true);
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

    public void SetTrueAnimationSurprise()
    {
        _animator.SetBool("Surprise", true);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 316.753f, transform.rotation.eulerAngles.z);
        transform.position = new Vector3(1.26f, -0.702f, -9.52f);
        StartCoroutine(ActiveCongratulationUI());
    }

    private IEnumerator ActiveCongratulationUI()
    {
        yield return new WaitForSeconds(2f);
        congratulationUI.SetActive(true);
    }


}
