using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Pickup : MonoBehaviour
{
    [SerializeField]
    int points = 10;
    MeshRenderer[] mrs;

    private void Start()
    {
        mrs = GetComponentsInChildren<MeshRenderer>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameData.instance.UpdateScore(points);

            foreach (MeshRenderer ms in mrs)
            {
                ms.enabled = false;
            }
        }
    }

    private void OnEnable()
    {
        if (mrs.Length == 0)
        {
            mrs = GetComponentsInChildren<MeshRenderer>();
        }

        foreach (MeshRenderer ms in mrs)
        {
            ms.enabled = enabled;
        }
    }
}
