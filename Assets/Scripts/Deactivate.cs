using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    [SerializeField]
    float deactivateAfter = 3f;

    bool deactivating = false;
    private void OnCollisionExit(Collision player)
    {
        if(player.gameObject.CompareTag("Player") && !deactivating)
        {
            Invoke("SetInactive", deactivateAfter);
            deactivating = true;
        }
    }

    void SetInactive()
    {
        gameObject.SetActive(false);
        deactivating = false;
    }
}
