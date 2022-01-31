using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerControls))]
[RequireComponent(typeof(MeshRenderer))]
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float loadDelay = 1f;

    [Header("Explosion Effect")]
    [SerializeField] private ParticleSystem crashVFX;

    private bool isCrash;

    private void OnTriggerEnter(Collider other)
    {
        StartCrashQequence();
    }

    private void StartCrashQequence()
    {
        if (!isCrash)
        {
            isCrash = true;
            crashVFX.Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<PlayerControls>().enabled = false;
            StartCoroutine(RestartLevelSequence(loadDelay));
        }
    }

    private IEnumerator RestartLevelSequence(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
