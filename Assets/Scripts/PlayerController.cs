using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public float speed = 5f;
    public bool alive = true;
    private float ScreenWidth;
    public float speedIncreasePerPoint = 3f;
    //public CapsuleCollider col;
    public GameObject DeathMenu;
    public TextMeshProUGUI distanceMoved;
    public ParticleSystem deathParticle;
    public ParticleSystem runningParticle;
    public static int distanceUnit = 0;

    [SerializeField] float jumpForce = 5;
    [SerializeField] float HorizontalMultiplier = 1.01f;
    [SerializeField] Rigidbody rb;
    //[SerializeField] LayerMask groundMask;


    float horizontalInput;
    public bool isGrounded = true;

    private void Start()
    {
        //col = GetComponent<CapsuleCollider>();
        ScreenWidth = Screen.width;
        anim.SetBool("RotatingRunning", true);
        InvokeRepeating("Distance", 0, 1 / speed);
        InvokeRepeating("IncreaseSpeed", 10, 7);
        distanceUnit = 0;
    }
    private void FixedUpdate()
    {
        if (!alive)
        {
            return;
        }

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

#if UNITY_EDITOR
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
#endif
    }

    void Update()
    {
        //Debug.Log(col.bounds.min.y);

        if(isGrounded == false)
        {
            runningParticle.Stop();
        }
        int i = 0;
        while(i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                rb.AddForce(new Vector3(horizontalInput * speed * Time.deltaTime, 1.0f));
            }
            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                rb.AddForce(new Vector3(horizontalInput * speed * Time.deltaTime, -1.0f));
            }
            ++i;
        }
        horizontalInput = Input.GetAxis("Horizontal");

        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {

            anim.SetTrigger("Jumping");
 
            Jump();
           
            Debug.Log("Jumping");
        } 

    }
    public void Die()
    {
        alive = false;
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        DeathMenu.SetActive(true);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        FindObjectOfType<AudioManager>().Play("Jump");
        isGrounded = false;
    }
    
    void Distance()
    {
        distanceUnit++;
        distanceMoved.text = "Distance Traveled: " + distanceUnit.ToString();
    }

    void IncreaseSpeed()
    {
        speed++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GroundTag")
        {
            isGrounded = true;
            runningParticle.Play();
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            Die();
        }
    }
}
