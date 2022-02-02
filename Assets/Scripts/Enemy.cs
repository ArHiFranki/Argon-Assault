using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] private int enemyHitPoints;
    [SerializeField] private int scorePerHit;

    [Header("Particle Systems Effects")]
    [SerializeField] private GameObject deathFX;
    [SerializeField] private GameObject hitVFX;

    private GameObject parentGameObject;
    private ScoreBoard myScoreBoard;

    private void Awake()
    {
        myScoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
    }

    private void Start()
    {
        AddRigidbody();
    }

    private void AddRigidbody()
    {
        Rigidbody myRigidbody = gameObject.AddComponent<Rigidbody>();
        myRigidbody.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        InstantiateVFX(hitVFX);
        ReduseEnemyHitPoints();
    }

    private void InstantiateVFX(GameObject particleVFX)
    {
        GameObject fx = Instantiate(particleVFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentGameObject.transform;
    }

    private void ReduseEnemyHitPoints()
    {
        enemyHitPoints--;
        if (enemyHitPoints < 1)
        {
            myScoreBoard.IncreaseScore(scorePerHit);
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        InstantiateVFX(deathFX);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
