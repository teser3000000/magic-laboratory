using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RadialIndicator : MonoBehaviour
{
    [Header("Radial Timer")]
    [SerializeField] private float indicatorTimer = 1f;
    [SerializeField] private float maxIndicatorTimer = 1f;

    [Header("Radial Timer")]
    [SerializeField] private Image radialIndicatorUI = null;

    [Header("KeyCode")]
    [SerializeField] private KeyCode selectKey = KeyCode.Mouse0;

    [Header("Unity Event")]
    [SerializeField] private UnityEvent myEvent = null;

    private bool shouldUpdate = false;

    private void Update()
    {
        if (Input.GetKey(selectKey))
        {
            shouldUpdate = false;
            indicatorTimer -= Time.deltaTime;
            radialIndicatorUI.enabled = true;
            radialIndicatorUI.fillAmount = indicatorTimer;

            if (indicatorTimer <= 0)
            {
                indicatorTimer = maxIndicatorTimer;
                radialIndicatorUI.fillAmount = maxIndicatorTimer;
                radialIndicatorUI.enabled = false;
                myEvent.Invoke();
                Debug.Log(33333);
            }

        }
        else
        {
            if (shouldUpdate)
            {
                indicatorTimer += Time.deltaTime;
                radialIndicatorUI.fillAmount = indicatorTimer;

                if (indicatorTimer >= maxIndicatorTimer)
                {
                    indicatorTimer = maxIndicatorTimer;
                    radialIndicatorUI.fillAmount = maxIndicatorTimer;
                    radialIndicatorUI.enabled = false;
                    shouldUpdate = false;
                }
            }
        }

        if (Input.GetKeyUp(selectKey))
        {
            shouldUpdate = true;
        }

        radialIndicatorUI.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
    }
}
