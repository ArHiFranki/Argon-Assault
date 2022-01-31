using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerControls))]
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float loadDelay = 1f;

    private void OnTriggerEnter(Collider other)
    {
        StartCrashQequence();
    }

    private void StartCrashQequence()
    {
        GetComponent<PlayerControls>().enabled = false;
        StartCoroutine(RestartLevelSequence(loadDelay));
    }

    private IEnumerator RestartLevelSequence(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
