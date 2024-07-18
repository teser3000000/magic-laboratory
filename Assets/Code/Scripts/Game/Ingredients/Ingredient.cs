using DG.Tweening;
using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


public enum PotionType { Red, Green, Purple }
public enum MetalType { Gold, RedMetal }
public enum SeedType { Watermelon, Sunflower, Crystal }
public enum MushroomType { Blue }
public enum FlowerType { Daisy }


public abstract class Ingredient<T> : MonoBehaviour, IIngredient, IAnimatable, IInteroperable
{
    [SerializeField] private T type;
    [SerializeField] private ReactiveProperty<Image> iconIngredient = new ReactiveProperty<Image>();

    private CameraMovement _cameraMovement;

    protected Animation _anim;
    protected TestMixing _testMixing;

    private bool onInteract;

    [Inject]
    private void Construct(TestMixing testMixing, CameraMovement cameraMovement)
    {
        _testMixing = testMixing;
        _cameraMovement = cameraMovement;
    }

    public bool OnInteract
    {
        get { return onInteract; }
        private set { onInteract = value; }
    }

    public T Type
    {
        get { return type; }
        private set { type = value; }
    }

    object IIngredient.Type => Type.ToString();

    protected Ingredient(T initialType)
    {
        Type = initialType;
    }

    private void Awake()
    {
        _anim = gameObject.GetComponent<Animation>();
    }

    public void TryInteract()
    {
        if (onInteract || AnimationLock.IsAnimationPlaying) return;
        onInteract = true;

        PlayAnimation();
        DropIntoCauldron();

        if (iconIngredient != null) EnablingTheIcon();
    }

    public virtual void PlayAnimation()
    {
        if (!AnimationLock.IsAnimationPlaying)
        {
            _anim.Play();
            AnimationLock.SetAnimationState(true);
        }
    }
    public virtual IEnumerator ResetOriginalState() { yield return new WaitForSeconds(0); }

    protected void EnablingTheIcon()
    {
        iconIngredient.Value.DOFade(1f, 1f);
    }

    protected void TurningTheIcon()
    {
        iconIngredient.Value.DOFade(0.2f, 1f);
    }

    protected void ResetInteracteble()
    {
        onInteract = false;
    }

    protected void ReturnToTheInitialCamera()
    {
        _cameraMovement.SelectCamera(0);
    }

    protected virtual void DropIntoCauldron() { }

    private void AnimationCompleted()
    {
        AnimationLock.AnimationCompleted();
    }

}