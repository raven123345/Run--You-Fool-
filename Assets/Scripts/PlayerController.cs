using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float rotAngle = 45f;
    [SerializeField]
    float moveAmount = 1f;
    [SerializeField]
    float jumpForce = 100f;
    [SerializeField]
    float spellForce = 4000f;
    [SerializeField]
    float restartLevelAfter = 1f;
    [SerializeField]
    GameObject gameOverPanel;

    Animator anim;
    bool canTurn = false;
    Rigidbody rb;
    Rigidbody magicRB;

    public GameObject magic;
    public Transform magicStartPos;


    public static GameObject player;
    public static GameObject currentPlatform;
    public static bool isDead = false;
    bool gameOver = false;

    int livesLeft;
    public GameObject[] livesTextIcons;

    bool falling = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        magicRB = magic.GetComponent<Rigidbody>();

        player = this.gameObject;

        GenerateWorld.RunDummy();

        isDead = false;
        gameOver = false;

        livesLeft = PlayerPrefs.GetInt("Lives");

        for (int i = 0; i < livesTextIcons.Length; i++)
        {
            if (i >= livesLeft)
            {
                livesTextIcons[i].SetActive(false);
            }
        }
        if (gameOverPanel)
            gameOverPanel.SetActive(false);

    }

    public void CastMagic()
    {
        if (isDead)
            return;
        magic.transform.position = magicStartPos.position;
        magic.SetActive(true);
        magicRB.AddForce(this.transform.forward * spellForce);
        Invoke("KillMagic", 1f);
    }

    void KillMagic()
    {
        magic.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (gameOver && Input.anyKeyDown)
            {
                SceneManager.LoadScene("Menu");
            }
            return;
        }
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("isJumping", true);
            rb.AddForce(Vector3.up * jumpForce);
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
        if (other.gameObject.CompareTag("OffTheEdge"))
        {
            anim.SetTrigger("isFalling");
            isDead = true;
            TakeLive();
            Invoke("RestartGame", restartLevelAfter);
        }


    }
    void GameOver()
    {
        if (gameOverPanel)
            gameOverPanel.SetActive(true);

        PlayerPrefs.SetInt("LastScore", PlayerPrefs.GetInt("Score"));
        if (PlayerPrefs.HasKey("BestScore"))
        {
            int bestScore = PlayerPrefs.GetInt("BestScore");
            if (bestScore < PlayerPrefs.GetInt("Score"))
            {
                PlayerPrefs.SetInt("BestScore", PlayerPrefs.GetInt("LastScore"));
            }
        }
        gameOver = true;
    }
    void TakeLive()
    {
        livesLeft--;
        PlayerPrefs.SetInt("Lives", livesLeft);
    }

    void RestartGame()
    {
        if (livesLeft >= 0)
            SceneManager.LoadScene("Level", LoadSceneMode.Single);
        else
            GameOver();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Fire") || other.gameObject.CompareTag("Wall"))
        {
            anim.SetTrigger("isDead");
            isDead = true;
            TakeLive();
            Invoke("RestartGame", restartLevelAfter);
        }
        else
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
