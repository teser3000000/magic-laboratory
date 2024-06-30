using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MixingContext : MonoBehaviour
{
    private RecipeManager _recipeManager;
    private CameraMovement _cameraMovement;
    private TriggerAnimationCreate _triggerAnimationCreate;

    [Inject] private void Construct(RecipeManager recipeManager, CameraMovement cameraMovement, TriggerAnimationCreate triggerAnimationCreate)
    {
        _recipeManager = recipeManager;
        _cameraMovement = cameraMovement;
        _triggerAnimationCreate = triggerAnimationCreate;
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
            Debug.Log("No matching recipe found.");
        }
    }

    private IEnumerator CreateResultWithDelay(GameObject result, float delay)
    {
        yield return new WaitForSeconds(delay);
        AnimationBeforeCreation();
        _triggerAnimationCreate.appearanceCinematicStripesCommand.Execute();
        yield return new WaitForSeconds(2.3f);
        Instantiate(result, new Vector3(0.613f, 0, -9.177f), Quaternion.identity);
    }

    private void AnimationBeforeCreation()
    {
        _cameraMovement.SelectCamera(3);
    }


}
