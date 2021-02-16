using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float rotAngle = 45f;
    [SerializeField]
    float moveAmount = 1f;

    Animator anim;

    public static GameObject player;
    public static GameObject currentPlatform;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("isJumping", true);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("isMagic", true);
            anim.SetLayerWeight(1, 1.0f);
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            transform.Rotate(Vector3.up * rotAngle * Mathf.Sign(Input.GetAxisRaw("Horizontal")));
        }

        if (Input.GetButtonDown("MoveHorizontal"))
        {
            transform.Translate(transform.right * moveAmount * Mathf.Sign(Input.GetAxisRaw("MoveHorizontal")), Space.World);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        currentPlatform = other.gameObject;
    }
    public void StopJumping()
    {
        anim.SetBool("isJumping", false);
    }

    public void StopMagic()
    {
        anim.SetBool("isMagic", false);
        anim.SetLayerWeight(1, 0.0f);
    }

    public void StopDying()
    {
        anim.SetBool("isDead", false);
    }

}
