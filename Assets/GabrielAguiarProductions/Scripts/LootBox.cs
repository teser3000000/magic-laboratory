using UnityEngine;

[RequireComponent(typeof(Collider))]
public class LootBox : MonoBehaviour
{
    public Animator cameraAnimator;

    public GameObject lootBox;
    public GameObject lootBoxFractured;
    public GameObject lootReward;

    public Transform lootRewardVector;

    private GameObject _fracturedObject;
    private GameObject _loot;

    private Animator _animator;


    private TriggerAnimationStrips _triggerAnimationCreate;

    void Start()
    {
        _animator = GetComponent<Animator>();

        OpenAnimation();
    }
    public void LootReward()
    {
        _loot = Instantiate(lootReward, lootRewardVector) as GameObject;

        lootBox.SetActive(false);

        if (lootBoxFractured != null)
        {
            _fracturedObject = Instantiate(lootBoxFractured, lootRewardVector) as GameObject;
        }
    }

    private void OpenAnimation()
    {
        _animator.SetBool("Open", true);
        cameraAnimator.SetBool("Open", true);
    }

    private void OnDestroy()
    {
        
    }
}
