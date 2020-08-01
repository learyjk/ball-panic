﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    private float arrowSpeed = 4.0f;
    private bool canShootStickyArrow;

    private void Awake() {
        canShootStickyArrow = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShootArrow();
    }

    void ShootArrow()
    {
        Vector3 temp = transform.position;
        temp.y += arrowSpeed * Time.unscaledDeltaTime;
        transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "LargestBall" || target.tag == "LargeBall" || target.tag == "MediumBall" || target.tag == "SmallBall" || target.tag == "SmallestBall")
        {
            gameObject.SetActive(false);
        }
        
        if (target.tag == "TopBrick")
        {
            gameObject.SetActive(false);
        }
    }
}
