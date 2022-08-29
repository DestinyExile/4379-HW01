using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    [SerializeField] float powerupDuration = 3f;

    bool powerupActive = false;

    protected abstract void PowerUp();
    protected abstract void PowerDown();

    [SerializeField] Collider _collider;
    [SerializeField] MeshRenderer _meshRenderer;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PowerUp();
        powerupActive = true;
        _collider.enabled = false;
        _meshRenderer.enabled = false;
        
    }

    private void Update()
    {
        if(powerupActive)
        {
            powerupDuration -= Time.deltaTime;

            if (powerupDuration <= 0f)
            {
                durationEnded();
            }
        }
    }

    private void durationEnded()
    {
        powerupDuration = 3f;
        PowerDown();
        powerupActive = false;
    }
}