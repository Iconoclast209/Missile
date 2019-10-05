using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Visible in Editor
    [SerializeField]
    float timeBetweenLaunches = 3.0f;
    [SerializeField]
    GameObject enemyMissilePrefab;
    [SerializeField]
    float timeSinceLastChange = 0;
    [SerializeField]
    float timeBetweenTimeChanges = 7.0f;

    //Not Visible in Editor
    float timeSinceLastLaunch = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastChange += Time.deltaTime;

        timeSinceLastLaunch += Time.deltaTime;
        if(timeSinceLastLaunch >= timeBetweenLaunches)
        {
            timeSinceLastLaunch = 0;
            LaunchEnemyMissile();
        }

        if(timeSinceLastChange >= timeBetweenTimeChanges)
        {
            timeSinceLastChange = 0f;
            if (timeBetweenLaunches > 0.25f)
            {
                timeBetweenLaunches -= 0.25f;
            }
            else
            {
                timeBetweenLaunches = 0.25f;
            }
            timeBetweenTimeChanges += 2.0f;
        }
    }

    void LaunchEnemyMissile()
    {
        Vector3 spawnPos = DetermineSpawnPoint();
        Vector3 targetPos = DetermineTargetPoint();
        //Quaternion quat = Quaternion.FromToRotation(Vector3.up, (targetPos - transform.position).normalized);
        GameObject enemyMissile = Instantiate(enemyMissilePrefab, spawnPos, Quaternion.identity);
        enemyMissile.GetComponent<Transform>().rotation = Quaternion.FromToRotation(Vector3.up, (targetPos - enemyMissile.transform.position).normalized);
        enemyMissile.GetComponent<EnemyMissile>().SetTarget(targetPos);
        enemyMissile.GetComponent<EnemyMissile>().ApplyForce();
    }

    Vector3 DetermineSpawnPoint()
    {
        float x = Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight);
           
        return new Vector3(x, 12,0);
    }

    Vector3 DetermineTargetPoint()
    {
        float x = Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight);
        return new Vector3(x, -12,0);
    }
}
