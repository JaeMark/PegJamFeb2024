using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
    [SerializeField]
    private float shakeIntensity = 0.1f;

    [SerializeField]
    private float shakeDuration = 0.5f;

    private Transform mainCameraTransform;
    private Coroutine shakeCoroutine;

    private void Start()
    {
        mainCameraTransform = Camera.main.transform;
    }

    public void Shake()
    {
        if (shakeCoroutine != null)
        {
            StopCoroutine(shakeCoroutine);
        }
        shakeCoroutine = StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        Vector3 originalPos = mainCameraTransform.localPosition;
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            float offsetX = Random.Range(-shakeIntensity, shakeIntensity);
            float offsetY = Random.Range(-shakeIntensity, shakeIntensity);
            mainCameraTransform.localPosition = originalPos + new Vector3(offsetX, offsetY, 0);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCameraTransform.localPosition = originalPos;
        shakeCoroutine = null; // Reset coroutine reference
    }
}