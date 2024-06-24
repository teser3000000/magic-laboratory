using UniRx;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class RayX : MonoBehaviour
{
    [SerializeField] private LayerMask interoperableLayer;

    public ReactiveProperty<IInteroperable> _currentInteroperableObjectReact { get; private set; } = new ReactiveProperty<IInteroperable>();

    private Camera mainCamera;


    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectHackableObject();
        }
    }

    private void SelectHackableObject()
    {
        if (TryGetInteroperableObject(out IInteroperable item))
        {
            _currentInteroperableObjectReact.Value = item;
            _currentInteroperableObjectReact.Value.TryInteract();
        }
        else
        {
            _currentInteroperableObjectReact.Value = null;
        }
    }

    private bool TryGetInteroperableObject(out IInteroperable item)
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 1000))
        {
            if (hit.transform.TryGetComponent(out item))
            {
                return true;
            }
        }

        item = default;
        return false;
    }
}
