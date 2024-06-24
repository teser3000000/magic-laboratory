using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour
{
    Renderer rend;
    Vector3 lastPos;
    Vector3 velocity;
    public float MaxWobble;
    public float WobbleSpeed;
    public float Recovery;
    float wobbleAmountX;
    float wobbleAmountZ;
    float wobbleAmountToAddX;
    float wobbleAmountToAddZ;
    float pulse;
    float time = 0.5f;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine(CalculateVelocity());
        pulse = 2 * Mathf.PI * WobbleSpeed;
    }
    private void Update()
    {
        time += Time.deltaTime;
        // decrease wobble over time
        wobbleAmountToAddX = Mathf.Lerp(wobbleAmountToAddX, 0, Time.fixedDeltaTime * (Recovery));
        wobbleAmountToAddZ = Mathf.Lerp(wobbleAmountToAddZ, 0, Time.fixedDeltaTime * (Recovery));
        // make a sine wave of the decreasing wobble
        wobbleAmountX = wobbleAmountToAddX * Mathf.Sin(pulse * time);
        wobbleAmountZ = wobbleAmountToAddZ * Mathf.Sin(pulse * time);
        // send it to the shader
        rend.material.SetFloat("_WobbleX", wobbleAmountX);
        rend.material.SetFloat("_WobbleZ", wobbleAmountZ);

    }

    IEnumerator CalculateVelocity()
    {
        while (true)
        {
            lastPos = transform.position;
            yield return new WaitForEndOfFrame();
            velocity = (lastPos - transform.position) / Time.deltaTime;
            // add clamped velocity to wobble
            wobbleAmountToAddX += Mathf.Clamp(velocity.x * MaxWobble, -MaxWobble, MaxWobble);
            wobbleAmountToAddZ += Mathf.Clamp(velocity.z * MaxWobble, -MaxWobble, MaxWobble);

        }
    }

}