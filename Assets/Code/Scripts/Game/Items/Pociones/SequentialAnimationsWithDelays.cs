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

        // ������������� DOTween (���� ��� ����������)
        DOTween.Init();

        // ������� ����� ������������������
        Sequence mySequence = DOTween.Sequence();

        // ��������� ����������� �������
        mySequence.Append(targetObject.DOMove(new Vector3(3, 0, 0), 2f).OnComplete(() => Debug.Log("Move complete")));
        
        // ��������� �������� � 1 �������
        mySequence.AppendInterval(5f).OnComplete(() => Debug.Log("Interval 1 complete"));

        // ��������� �������� �������
        mySequence.Append(targetObject.DORotate(new Vector3(0, 180, 0), 2f).OnComplete(() => Debug.Log("Rotate complete")));
        
        // ��������� ��� ���� �������� � 1 �������
        mySequence.AppendInterval(5f).OnComplete(() => Debug.Log("Interval 2 complete"));

        // ��������� ��������� �������� �������
        mySequence.Append(targetObject.DOScale(new Vector3(2, 2, 2), 1.5f).OnComplete(() => Debug.Log("Scale complete")));

        // ��������� ������������������
        mySequence.Play();
    }
}
