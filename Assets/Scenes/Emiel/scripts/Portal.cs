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
            SceneManager.LoadScene("Emiel");
        }
        if (w.Equals(1))
        {
            normalWorld = false;
            ghostWorld = true;
            player.ChangeSprite(player.ghostSprite);
            SceneManager.LoadScene("GhostWorld");
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
