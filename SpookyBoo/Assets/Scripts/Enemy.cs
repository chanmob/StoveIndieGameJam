using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform idleTransform;

    public float idleTime;
    public float searchingTime;
    public float idleSpeed;
    public float shootSpeed;

    public float halfViewAngle = 30f;
    public float viewZ = 90;

    private void Start()
    {
        StartCoroutine(EnemyShootingCoroutine());
    }

    private IEnumerator EnemyShootingCoroutine()
    {
        Vector2 idleDir = (idleTransform.position - transform.position).normalized;
        float distance = Vector2.Distance(idleTransform.position, transform.position);

        while (distance >= 0.05f)
        {
            distance = Vector2.Distance(idleTransform.position, transform.position);
            transform.Translate(idleDir * shootSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = idleTransform.position;

        float time = 0f;
        while (time < searchingTime)
        {
            transform.eulerAngles = new Vector3(0, 0, -Mathf.PingPong(Time.time * 25, 10));
            time += Time.deltaTime;
            yield return null;
        }

        float random = Random.Range(-halfViewAngle, halfViewAngle);
        Vector3 randomVec = AngleToDirZ(random + viewZ);
        transform.eulerAngles = randomVec;

        yield return new WaitForSeconds(idleTime);

        Vector2 dir = (randomVec - transform.position).normalized;
        Vector2 finalDistance = dir * 10f;
        finalDistance = new Vector3(finalDistance.x, finalDistance.y, 0);

        float finaldistance = Vector2.Distance(finalDistance, transform.position);
        while(finaldistance >= 0.05f)
        {
            finaldistance = Vector2.Distance(finalDistance, transform.position);
            transform.Translate(dir * shootSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private Vector3 AngleToDirZ(float angleInDegree)
    {
        float radian = (angleInDegree - transform.eulerAngles.z) * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), Mathf.Cos(radian), 0);
    }
}
