using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moth : Enemy
{
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moving = startPos;
        moving.x += moveArea * Mathf.Sin(Time.time * moveSpeed);
        transform.position = moving;
    }
}
