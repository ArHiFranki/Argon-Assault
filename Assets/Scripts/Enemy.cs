using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] private int enemyHitPoints;
    [SerializeField] private int scorePerHit;

    [Header("Particle Systems Effects")]
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private Transform parent;

    private ScoreBoard myScoreBoard;

    private void Awake()
    {
        myScoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        myScoreBoard.IncreaseScore(scorePerHit);
        InstantiateVFX(hitVFX);
        ReduseEnemyHitPoints();
    }

    private void InstantiateVFX(GameObject particleVFX)
    {
        GameObject vfx = Instantiate(particleVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
    }

    private void ReduseEnemyHitPoints()
    {
        enemyHitPoints--;
        if (enemyHitPoints < 1)
        {
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        InstantiateVFX(deathVFX);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
