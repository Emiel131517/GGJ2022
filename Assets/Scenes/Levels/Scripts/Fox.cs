using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : Enemy
{
    // Start is called before the first frame update
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
        
        if (moving.x > 0)
            GetComponent<SpriteRenderer>().flipX = true;
        else if (moving.x < 0)
            GetComponent<SpriteRenderer>().flipX = false;
        Debug.Log("Moving X" + moving.x);
    }
}


