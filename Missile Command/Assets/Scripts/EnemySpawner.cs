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

    //Not Visible in Editor
    float timeSinceLastLaunch = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastLaunch += Time.deltaTime;
        if(timeSinceLastLaunch >= timeBetweenLaunches)
        {
            timeSinceLastLaunch = 0;
            LaunchEnemyMissile();
        }
    }

    void LaunchEnemyMissile()
    {
        Vector2 spawnPos = DetermineSpawnPoint();
        Vector3 target = DetermineTargetPoint();

        Instantiate(enemyMissilePrefab, spawnPos, Quaternion.identity);
        EnemyMissile enemyMissile = enemyMissilePrefab.GetComponent<EnemyMissile>();
        enemyMissile.SetTarget(target);
        enemyMissile.ApplyForce();
    }

    Vector2 DetermineSpawnPoint()
    {
        float x = Random.Range(-ScreenUtils.ScreenRight, ScreenUtils.ScreenRight);
        float y = ScreenUtils.ScreenTop + 1;
        return new Vector2(x, y);
    }

    Vector3 DetermineTargetPoint()
    {
        float x = Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight);
        return new Vector3(x,0,-10);
    }
}
