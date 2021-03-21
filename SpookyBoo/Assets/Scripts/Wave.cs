using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private Vector3 startPosition;

    public float waitTime;
    public float time;
    public float waveDelayTime;

    private IEnumerator waveCoroutine;

    private void Start()
    {
        startPosition = new Vector2(0, -8f);
    }

    public void StartWaveCoroutine()
    {
        if(waveCoroutine != null)
        {
            StopCoroutine(waveCoroutine);
            waveCoroutine = null;
        }

        waveCoroutine = WaveCoroutine();
        StartCoroutine(waveCoroutine);
    }

    private IEnumerator WaveCoroutine()
    {
        while (true)
        {
            float randomY = Random.Range(2f, 4.5f);
            Vector2 destination = startPosition + new Vector3(0, randomY);

            float distance = Vector2.Distance(transform.position, destination);

            while (distance > 0.05f)
            {
                distance = Vector2.Distance(transform.position, destination);
                transform.position = Vector2.Lerp(transform.position, destination, time * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(waitTime);

            distance = Vector2.Distance(transform.position, startPosition);

            while (distance > 0.05f)
            {
                distance = Vector2.Distance(transform.position, startPosition);
                transform.position = Vector2.Lerp(transform.position, startPosition, time * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(waveDelayTime);
        }
    }
}
