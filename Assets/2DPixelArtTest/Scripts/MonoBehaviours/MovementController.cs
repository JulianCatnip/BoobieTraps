using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    Vector2 movement = new Vector2();

    Animator animator;
    bool isWalking = false;
    Rigidbody2D rb2D;
    public AudioSource feetAudioSrc;

    /*enum CharStates
    {
        idle = 0,
        walkLeft = 1,
        walkRight = 2,
        walkUp = 3,
        walkDown = 4
    }*/

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        feetAudioSrc = GetComponentInChildren<AudioSource>();
        feetAudioSrc.Play();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();
        rb2D.velocity = movement * movementSpeed;
    }

    private void UpdateState()
    {
        if (Mathf.Approximately(movement.x, 0) && Mathf.Approximately(movement.y, 0))
        {
            animator.SetBool("isWalking", false);
            isWalking = false;
        }
        else
        {
            animator.SetBool("isWalking", true);
            isWalking = true;
        }

        if(!isWalking && feetAudioSrc.isPlaying)
        {
            feetAudioSrc.Stop();
        } 
        
        if(isWalking && !feetAudioSrc.isPlaying)
        {
            feetAudioSrc.Play();
        }

        animator.SetFloat("xDir", movement.x);
        animator.SetFloat("yDir", movement.y);
    }
}
