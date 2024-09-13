using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    int currentHitPoints = 0; 
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void OnParticleCollision(GameObject other) 
    {
        if (currentHitPoints <= 0)
        {
            KillEnemy();
        }
        ProcessHit();
    }

    void KillEnemy()
    {
        gameObject.SetActive(false);
    }

    void ProcessHit()
    {
        currentHitPoints --;
    }
}
