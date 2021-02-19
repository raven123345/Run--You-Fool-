using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    [SerializeField]
    float deactivateAfter = 3f;
    private void OnCollisionExit(Collision player)
    {
        if(player.gameObject.CompareTag("Player"))
        {
            Invoke("SetInactive", deactivateAfter);
        }
    }

    void SetInactive()
    {
        gameObject.SetActive(false);
    }
}
