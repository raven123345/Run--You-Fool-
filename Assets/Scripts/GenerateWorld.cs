using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{

    public GameObject[] platforms;
    [SerializeField]
    int iter = 20;
    [SerializeField]
    float offset = 10f;

    int platformNum;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(0f, 0f, 0f);
        for (int i = 0; i < iter; i++)
        {
            platformNum = Random.Range(0, platforms.Length);
            pos.z = i * offset;

            Instantiate(platforms[platformNum], pos, Quaternion.identity);
            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
