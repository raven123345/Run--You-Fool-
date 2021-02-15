using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{

    //public GameObject[] platforms;
    [SerializeField]
    int iterations = 20;
    [SerializeField]
    float forwardOffset = 10f;
    [SerializeField]
    float stairsOffset = 5f;

    int platformNum;

    // Start is called before the first frame update
    void Start()
    {
        GameObject dummyTraveller = new GameObject("Dummy");
        for (int i = 0; i < iterations; i++)
        {
            GameObject platform = Pool.singleton.GetRandom();

            if (platform == null) return;

            platform.SetActive(true);
            platform.transform.position = dummyTraveller.transform.position;
            platform.transform.rotation = dummyTraveller.transform.rotation;


            if (platform.CompareTag("StairsUp"))
            {
                dummyTraveller.transform.Translate(0f, stairsOffset, 0f);
            }
            else if (platform.CompareTag("StairsDown"))
            {
                dummyTraveller.transform.Translate(0f, -stairsOffset, 0f);

                platform.transform.Rotate(Vector3.up, 180f);
                platform.transform.position = dummyTraveller.transform.position;
            }
            else if (platform.CompareTag("PlatformTSection"))
            {
                if ((int)Random.Range(0f, 2f) == 0)
                    dummyTraveller.transform.Rotate(Vector3.up, 90f);
                else
                    dummyTraveller.transform.Rotate(Vector3.up, -90f);

                dummyTraveller.transform.Translate(Vector3.forward * -10f);
            }

            dummyTraveller.transform.Translate(0f, 0f, -forwardOffset);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
