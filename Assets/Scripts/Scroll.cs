using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{

    [SerializeField]
    float scrollSpeed = 0.1f;
    float ZScroll;
    private void FixedUpdate()
    {
        this.transform.position += PlayerController.player.transform.forward * -scrollSpeed;

        if (PlayerController.currentPlatform == null)
        {
            return;
        }

        if (PlayerController.currentPlatform.CompareTag("StairsUp"))
        {
            transform.Translate(Vector3.up * -(scrollSpeed * 0.6f));
        }
        else if (PlayerController.currentPlatform.CompareTag("StairsDown"))
        {
            transform.Translate(Vector3.up * (scrollSpeed * 0.6f));
        }
    }
}
