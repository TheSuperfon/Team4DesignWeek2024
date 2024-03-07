using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalLerpScript : MonoBehaviour
{
    public Transform targetPosition;
    public float initialWaitTime = 4f; // Time to wait before starting lerping
    public float lerpTime = 2f; // Time taken to reach the target position
    public AnimalScoreCounter AnimalManager;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        StartCoroutine(StartLerping());
    }

    IEnumerator StartLerping()
    {
        yield return new WaitForSeconds(initialWaitTime); // Wait for 4 seconds

        float elapsedTime = 0f;

        while (elapsedTime < lerpTime)
        {
            float t = elapsedTime / lerpTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition.position, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition.position; // Ensure object reaches exactly at target position
        AnimalManager.AnimalCounter += 1;
    }
}
