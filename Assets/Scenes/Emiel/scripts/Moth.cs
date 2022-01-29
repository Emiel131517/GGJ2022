using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float moveSpeed;

    private float moveArea;
    private float moveAreaMax;
    private float moveAreMin;
    void Start()
    {
        moveSpeed = 500;

        moveAreaMax = 100;
        moveAreMin = -100;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveArea < 100)
        {

        }
    }
    private void MoveRight()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
}
