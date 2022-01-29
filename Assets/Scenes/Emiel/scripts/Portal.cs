using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    float xpos;
    float ypos;

    Player player;

    bool normalWorld;
    bool ghostWorld;
    void Start()
    {
        player = new Player();

        ypos = transform.position.y;
        xpos = transform.position.x;
    }

    void Update()
    {
        
    }
    public void ChangeWorld(int w)
    {
        if (w.Equals(0))
        {
            normalWorld = true;
            ghostWorld = false;
            player.ChangeSprite(player.normalSprite);
        }
        if (w.Equals(1))
        {
            normalWorld = false;
            ghostWorld = true;
            player.ChangeSprite(player.ghostSprite);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (normalWorld)
        {
            ChangeWorld(0);
        }
        if (ghostWorld)
        {
            ChangeWorld(1);
        }
    }
}
