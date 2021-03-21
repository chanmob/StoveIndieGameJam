using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPosition;
    [SerializeField]
    private Transform idlePosition;

    public float chaseRadius = 1f;
    public float halfViewAngle = 30f;

    public float viewZ = 0;

    public float createEnemyTime;

    private void Start()
    {
        StartCoroutine(CreateEnemyCoroutine());
    }

    private IEnumerator CreateEnemyCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(createEnemyTime);

            Enemy newEnemy = ObjectPoolManager.instance.GetEnemy();
            newEnemy.halfViewAngle = halfViewAngle;
            newEnemy.viewZ = viewZ;
            newEnemy.idleTransform = idlePosition;
            newEnemy.transform.position = spawnPosition.position;
            newEnemy.gameObject.SetActive(true);
            newEnemy.StartShootCoroutine();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 originPos = transform.position;

        Vector3 horizontalRightDir = AngleToDirZ(-halfViewAngle + viewZ);
        Vector3 horizontalLeftDir = AngleToDirZ(halfViewAngle + viewZ);
        Vector3 lookDir = AngleToDirZ(viewZ);

        Debug.DrawRay(originPos, horizontalLeftDir * chaseRadius, Color.cyan);
        Debug.DrawRay(originPos, lookDir * chaseRadius, Color.green);
        Debug.DrawRay(originPos, horizontalRightDir * chaseRadius, Color.cyan);
    }

    private Vector2 AngleToDirZ(float angleInDegree)
    {
        float radian = (angleInDegree - transform.eulerAngles.z) * Mathf.Deg2Rad;
        return new Vector2(Mathf.Sin(radian), Mathf.Cos(radian));
    }
}
