﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 5f;

    [SerializeField]
    float frequency = 20f;

    [SerializeField]
    float magnitude = 0.5f;

    [SerializeField]
    bool zigzag = true;

    [SerializeField]
    bool forward = false;

    public GameObject explosionPrefab;

    Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();
    }
    void MoveDown()
    {
        if (zigzag)
        {
            startingPos -= transform.up * Time.deltaTime * movementSpeed;
            transform.position = startingPos + transform.right * Mathf.Sin(Time.time * frequency) * magnitude;
        }

        if (forward)
        {
            startingPos -= transform.up * Time.deltaTime * movementSpeed;
            transform.position = startingPos + transform.right * magnitude;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
