using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class SelfDestruct : MonoBehaviour
{
    private void Start()
    {
        float destroyDelay = GetComponent<ParticleSystem>().main.duration;
        Destroy(gameObject, destroyDelay);
    }
}
