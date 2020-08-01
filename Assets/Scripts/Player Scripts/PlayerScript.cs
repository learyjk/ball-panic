﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float speed = 8.0f;
    private float maxVelocity = 4.0f;

    [SerializeField]
    private Rigidbody2D myRigidbody;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject[] arrows;

    private float height;

    private bool canWalk;

    [SerializeField]
    private AnimationClip clip;

    [SerializeField]
    private AudioClip shootClip;

    void Awake() 
    {
        float cameraHeight = Camera.main.orthographicSize;
        height = -cameraHeight - 0.8f;
        canWalk = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate() {
        PlayerWalkKeyBoard();
    }

    // Update is called once per frame
    void Update()
    {
        ShootTheArrow();
    }

    public void ShootTheArrow()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(PlayTheShootAnimation());
            Instantiate(arrows[0], new Vector3(transform.position.x, height, 0), Quaternion.identity);
        }
    }

    IEnumerator PlayTheShootAnimation()
    {
        canWalk = false;
        animator.Play("PlayerShoot");
        AudioSource.PlayClipAtPoint(shootClip, transform.position);
        yield return new WaitForSeconds(clip.length);
        animator.SetBool("Shoot", false);
        canWalk = true;
    }

    void PlayerWalkKeyBoard()
    {
        float force = 0.0f;
        float velocity = Mathf.Abs (myRigidbody.velocity.x);

        float h = Input.GetAxis("Horizontal");

        if (canWalk)
        {
            if (h > 0) //right
            {
                if (velocity < maxVelocity)
                {
                    force = speed;
                }

                Vector3 scale = transform.localScale;
                scale.x = 1.0f;
                transform.localScale = scale;

                animator.SetBool("Walk", true);
            }
            else if (h < 0)
            {
                if (velocity < maxVelocity)
                {
                    force = -speed;
                }

                Vector3 scale = transform.localScale;
                scale.x = -1.0f;
                transform.localScale = scale;
                animator.SetBool("Walk", true);
            }
            else if (h == 0)
            {
                animator.SetBool("Walk", false);
            }

            myRigidbody.AddForce(new Vector2(force, 0));
        }
    }
}
