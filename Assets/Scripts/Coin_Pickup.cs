using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Pickup : MonoBehaviour
{
    [SerializeField]
    int points = 10;
    MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            try
            {
                GameData.instance.UpdateScore(points);
            }
            catch { }
            meshRenderer.enabled = false;
        }
    }

    private void OnEnable()
    {
        if (meshRenderer != null)
        {
            meshRenderer.enabled = enabled;
        }
    }
}
