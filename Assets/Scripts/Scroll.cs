using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{

    [SerializeField]
    float scrollSpeed = 0.1f;
    [SerializeField]
    float ZScroll = 0.06f;
    private void FixedUpdate()
    {
        this.transform.position += PlayerController.player.transform.forward * -scrollSpeed;

        if (PlayerController.currentPlatform == null)
        {
            return;
        }

        if (PlayerController.currentPlatform.CompareTag("StairsUp"))
        {
            transform.Translate(Vector3.up * -ZScroll);
        }
        else if (PlayerController.currentPlatform.CompareTag("StairsDown"))
        {
            transform.Translate(Vector3.up * ZScroll);
        }
    }
}
