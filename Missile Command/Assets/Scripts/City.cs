﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class City : MonoBehaviour
{
    [SerializeField]
    string cityName;
    [SerializeField]
    Sprite destroyedCity;
    SpriteRenderer sr;
    GameManager gm;


    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject enemy = other.gameObject;

        if (enemy.GetComponent<EnemyMissile>() != null)
        {
            //City Destroyed Message
            gm.CityDestroyed(cityName);
            //Destroy City
            sr.sprite = destroyedCity;
            //Destroy Enemy Missile
            enemy.GetComponent<EnemyMissile>().ExplodeEnemyMissile();
        }
    }
}
