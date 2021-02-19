using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{

    //public GameObject[] platforms;
    [SerializeField]
    int numPlatforms = 20;
    [SerializeField]
    float forwardOffset = 10f;
    [SerializeField]
    float stairsOffset = 5f;

    public static GameObject dummyTraveller;
    public static GameObject lastPlatform;

    int platformNum;

    // Start is called before the first frame update
    void Awake()
    {
        dummyTraveller = new GameObject("Dummy");

    }

    public static void RunDummy()
    {
        GameObject p = Pool.singleton.GetRandom();

        if (p == null)
        { return; }

        if (lastPlatform != null)
        {
            if (lastPlatform.CompareTag("PlatformTSection"))
                dummyTraveller.transform.position = lastPlatform.transform.position + PlayerController.player.transform.forward * 20f;
            else
                dummyTraveller.transform.position = lastPlatform.transform.position + PlayerController.player.transform.forward * 10f;

            if (lastPlatform.CompareTag("StairsUp"))
            {
                dummyTraveller.transform.Translate(0f, 5f, 0f);
            }
        }

        p.SetActive(true);
        p.transform.position = dummyTraveller.transform.position;
        p.transform.rotation = dummyTraveller.transform.rotation;
        lastPlatform = p;

        if (p.CompareTag("StairsDown"))
        {
            dummyTraveller.transform.Translate(0f, -5f, 0f);
            p.transform.Rotate(Vector3.up, 180f);
            p.transform.position = dummyTraveller.transform.position;
        }

    }
}
