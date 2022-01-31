using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Score per kill")]
    [SerializeField] private int scorePerHit;
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private Transform parent;

    private ScoreBoard myScoreBoard;

    private void Awake()
    {
        myScoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        DestroyEnemy();
    }

    private void ProcessHit()
    {
        myScoreBoard.IncreaseScore(scorePerHit);
    }

    private void DestroyEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
