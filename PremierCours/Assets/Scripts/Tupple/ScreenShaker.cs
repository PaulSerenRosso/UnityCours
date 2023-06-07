using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScreenShaker : MonoBehaviour
{
    public static ScreenShaker instance;
    [SerializeField] private float displacementIntensity;
    [SerializeField] private float rotationIntensity;
    [SerializeField] private AnimationCurve intensityCurve;

    public void Shake(float stress, float animationSpeed)
    {
        StartCoroutine(ShakeCoroutine(stress, 0, animationSpeed));
    }

    [SerializeField] private float testStress = 0.1f;
    [SerializeField] private float testAnimationSpeed = 0.01f;


    private void Start()
    {
        Shake(testStress, testAnimationSpeed);
    }

    private IEnumerator ShakeCoroutine(float stress, float animationEvolution, float animationSpeed)
    {
        yield return new WaitForEndOfFrame();
        var stressWithCurve = stress * intensityCurve.Evaluate(animationEvolution);
        animationEvolution += animationSpeed;
        transform.localPosition = (transform.right * Random.Range(-1, 1f) +
                                   transform.up * Random.Range(-1, 1f)) * stressWithCurve *
                                  displacementIntensity ;
        transform.localRotation = Quaternion.Euler(
            Random.Range(-1, 1f) * stressWithCurve*rotationIntensity,
            Random.Range(-1, 1f) * stressWithCurve*rotationIntensity,
            Random.Range(-1, 1f) * stressWithCurve*rotationIntensity);
        if (animationEvolution < 1)
        {
            StartCoroutine(ShakeCoroutine(stress, animationEvolution, animationSpeed));
        }
        else
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }
}