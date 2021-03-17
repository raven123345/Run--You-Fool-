using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    [SerializeField]
    GameObject[] bricks;
    [SerializeField]
    float crushForce = 500f;
    [SerializeField]
    GameObject explosion;

    List<Rigidbody> bricksRB = new List<Rigidbody>();
    Collider col;

    List<Vector3> positions = new List<Vector3>();
    List<Quaternion> rotations = new List<Quaternion>();


    private void OnEnable()
    {
        col.enabled = true;

        for (int i = 0; i < bricks.Length; i++)
        {
            bricks[i].transform.localPosition = positions[i];
            bricks[i].transform.localRotation = rotations[i];
            bricksRB[i].isKinematic = true;
        }
    }

    void Awake()
    {
        col = GetComponent<Collider>();

        foreach (GameObject b in bricks)
        {
            bricksRB.Add(b.GetComponent<Rigidbody>());
            positions.Add(b.transform.localPosition);
            rotations.Add(b.transform.localRotation);

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Spell"))
        {
            col.enabled = false;

           Instantiate(explosion, other.contacts[0].point, Quaternion.identity);

            foreach (Rigidbody rb in bricksRB)
            {
                rb.isKinematic = false;
                rb.AddForce(Random.insideUnitSphere * crushForce);
                rb.AddTorque(Random.insideUnitSphere * crushForce * 0.5f);
            }
        }
    }


}
