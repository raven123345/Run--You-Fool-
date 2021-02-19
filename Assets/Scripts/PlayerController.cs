﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float rotAngle = 45f;
    [SerializeField]
    float moveAmount = 1f;

    Animator anim;
    bool canTurn = false;

    public static GameObject player;
    public static GameObject currentPlatform;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = this.gameObject;
        GenerateWorld.RunDummy();
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

        //Завъртане
        if (Input.GetButtonDown("Horizontal") && canTurn)
        {
            transform.Rotate(Vector3.up * rotAngle * Mathf.Sign(Input.GetAxisRaw("Horizontal")));
            GenerateWorld.dummyTraveller.transform.forward = -this.transform.forward;
            GenerateWorld.RunDummy();
            canTurn = false;
        }

        //Отместване
        if (Input.GetButtonDown("MoveHorizontal"))
        {
            transform.Translate(transform.right * moveAmount * Mathf.Sign(Input.GetAxisRaw("MoveHorizontal")), Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other is BoxCollider && !GenerateWorld.lastPlatform.CompareTag("PlatformTSection"))
            GenerateWorld.RunDummy();

        if (other is SphereCollider)
        {
            canTurn = true;
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
