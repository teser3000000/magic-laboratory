using Cinemachine;
using UnityEngine;

public class ShaderManager : MonoBehaviour
{
    [SerializeField] private ParticleSystemRenderer particleRenderer;
    [SerializeField] private ParticleSystemRenderer beamLarge;
    [SerializeField] private ParticleSystemRenderer beamSmall;
    [SerializeField] private ParticleSystemRenderer beamVerticalLarge;

    [SerializeField] private ParticleSystemRenderer beamParticles;

    private ParticleSystem.LightsModule _lightsModule;

    private Color _colorBeamLarge;
    private Color _colorBeamSmall;
    private Color _colorBeamParticles;


    public float startValue = 10f;
    public float endValue = 0f;
    public float duration = 5f; // ƒлительность интерпол€ции в секундах
    private float currentTime = 0f; // “екущее врем€ интерпол€ции

    private void Start()
    {
        _colorBeamLarge = beamLarge.material.color;
        _colorBeamSmall = beamSmall.material.color;
        _colorBeamParticles = beamParticles.material.color;
        _lightsModule = beamLarge.GetComponent<ParticleSystem>().lights;

    }

    private void Update()
    {
        if (currentTime < duration)
        {
            currentTime += Time.deltaTime; // ”величиваем текущее врем€ на врем€ кадра
            float newValue = Mathf.Lerp(startValue, endValue, currentTime / duration);
            //Debug.Log(newValue);
            particleRenderer.material.SetFloat("Vector1_9CE267C1", newValue);
            beamVerticalLarge.material.SetFloat("Vector1_9CE267C1", newValue);

            _lightsModule.rangeMultiplier = newValue;

            _colorBeamLarge.a = newValue;
            _colorBeamSmall.a = newValue;
            _colorBeamParticles.a = newValue;

            beamLarge.material.color = _colorBeamLarge;
            beamSmall.material.color = _colorBeamSmall;
            beamParticles.material.color = _colorBeamParticles;
        }
    }

    
}


