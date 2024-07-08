using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RecipeUIManagement : MonoBehaviour
{
    [SerializeField] private List<GameObject> recipeSheets;

    public void StartingMovement()
    {
        bool allAlphaOne = true;

        foreach (GameObject recipeSheet in recipeSheets)
        {
            foreach (Transform ingredient in recipeSheet.transform)
            {
                Image imageComponent = ingredient.GetComponent<Image>();
                if (imageComponent != null)
                {
                    float valueAlpha = imageComponent.color.a;
                    if (valueAlpha != 1)
                    {
                        allAlphaOne = false;
                        break; // ������� �� ����������� �����, ���� ������ ������ � ����� != 1
                    }
                }
                else
                {
                    Debug.LogError("Image component not found on " + ingredient.name);
                    allAlphaOne = false;
                    break; // ������� �� ����������� �����, ���� �� ������� ��� ���������� Image
                }
            }

            if (!allAlphaOne)
            {
                break; // ������� �� �������� �����, ���� ������� �� �����������
            }
            else
            {
                recipeSheet.transform.DOLocalMoveY(757f, 1f).SetDelay(3f).OnComplete(()=> 
                {
                    recipeSheet.SetActive(false);
                });

                int currentIndex = recipeSheets.IndexOf(recipeSheet);
                if (currentIndex + 1 < recipeSheets.Count)
                {
                    GameObject nextRecipeSheet = recipeSheets[currentIndex + 1];

                    nextRecipeSheet.transform.DOLocalMoveX(654f, 1f).SetDelay(11f);

                }
            }
        }

       /* if (allAlphaOne)
        {
            Debug.Log("������: � ���� ����������� �����-����� ����� 1");
        }
        else
        {
            Debug.Log("�� ������: �� � ���� ����������� �����-����� ����� 1");
        }*/

    }

}
