﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BallScript : MonoBehaviour
{

    private Rigidbody myBody;
    private bool rollLeft;


    public float speed = 4.0f;

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        rollLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckBallPosition();
    }

    private void FixedUpdate()
    {
        if (GameplayController.instance.gamePlaying)
        {
            if (rollLeft)
            {
                myBody.velocity = new Vector3(-speed, Physics.gravity.y, 0f);
            }
            else
            {
                myBody.velocity = new Vector3(0f, Physics.gravity.y, speed);

            }
        }
    }

    private void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!GameplayController.instance.gamePlaying)
            {
                GameplayController.instance.gamePlaying = true;
                GameplayController.instance.ActivateTileSpawner();
            }

        }

        if (GameplayController.instance.gamePlaying)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rollLeft = !rollLeft;
            }
        }
    }

    private void CheckBallPosition()
    {
        if (GameplayController.instance.gamePlaying)
        {
            if (transform.position.y < -5f)
            {
                GameplayController.instance.gamePlaying = false;
                Destroy(gameObject);
                SceneManager.LoadScene(0);
            }
        }
    }

} //class


























