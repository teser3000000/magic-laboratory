using UnityEngine;
using DG.Tweening;

public class SequentialAnimationsWithDelays : MonoBehaviour
{
    public Transform targetObject;

    void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Target object is not assigned!");
            return;
        }

        // Инициализация DOTween (если это необходимо)
        DOTween.Init();

        // Создаем новую последовательность
        Sequence mySequence = DOTween.Sequence();

        // Анимируем перемещение объекта
        mySequence.Append(targetObject.DOMove(new Vector3(3, 0, 0), 2f).OnComplete(() => Debug.Log("Move complete")));
        
        // Добавляем задержку в 1 секунду
        mySequence.AppendInterval(5f).OnComplete(() => Debug.Log("Interval 1 complete"));

        // Анимируем вращение объекта
        mySequence.Append(targetObject.DORotate(new Vector3(0, 180, 0), 2f).OnComplete(() => Debug.Log("Rotate complete")));
        
        // Добавляем еще одну задержку в 1 секунду
        mySequence.AppendInterval(5f).OnComplete(() => Debug.Log("Interval 2 complete"));

        // Анимируем изменение масштаба объекта
        mySequence.Append(targetObject.DOScale(new Vector3(2, 2, 2), 1.5f).OnComplete(() => Debug.Log("Scale complete")));

        // Запускаем последовательность
        mySequence.Play();
    }
}
