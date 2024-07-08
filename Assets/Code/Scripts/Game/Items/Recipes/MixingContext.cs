using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MixingContext : MonoBehaviour
{
    private RecipeManager _recipeManager;
    private CameraMovement _cameraMovement;
    private TriggerAnimationStrips _triggerAnimationStrips;

    [Inject]
    private void Construct(RecipeManager recipeManager, CameraMovement cameraMovement, TriggerAnimationStrips triggerAnimationCreate)
    {
        _recipeManager = recipeManager ?? throw new System.ArgumentNullException(nameof(recipeManager));
        _cameraMovement = cameraMovement ?? throw new System.ArgumentNullException(nameof(cameraMovement));
        _triggerAnimationStrips = triggerAnimationCreate ?? throw new System.ArgumentNullException(nameof(triggerAnimationCreate));
    }

    public void Mix(List<IIngredient> items)
    {
        GameObject result = _recipeManager.FindRecipe(items);
        if (result != null)
        {
            StartCoroutine(CreateResultWithDelay(result, 4f));
        }
        else
        {
            Debug.LogWarning("No matching recipe found.");
        }
    }

    private IEnumerator CreateResultWithDelay(GameObject result, float delay)
    {
        yield return new WaitForSeconds(delay);

        SelectCameraForAnimation(3);

        _triggerAnimationStrips.appearanceCinematicStripesCommand.Execute();
        Instantiate(result, new Vector3(0.714f, 0.325f, -9.318f), Quaternion.identity);

        yield return new WaitForSeconds(2.3f);
        _triggerAnimationStrips.refundCinematicStripesCommand.Execute();
    }

    private void SelectCameraForAnimation(int cameraIndex)
    {
        _cameraMovement.SelectCamera(cameraIndex);
    }
}
