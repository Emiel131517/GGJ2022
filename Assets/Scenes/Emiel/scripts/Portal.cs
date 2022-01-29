using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Player player;

    private GameObject normalWorldScene;
    private GameObject ghostWordScene;
    private bool normalWorld;
    private bool ghostWorld;
    void Start()
    {
        normalWorldScene = GameObject.Find("NormalWorld");
        ghostWordScene = GameObject.Find("GhostWorld");
        normalWorldScene.SetActive(true);
        ghostWordScene.SetActive(false);

        normalWorld = true;

        player = new Player();
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
            normalWorldScene.SetActive(true);
            ghostWordScene.SetActive(false);
        }
        if (w.Equals(1))
        {
            normalWorld = false;
            ghostWorld = true;
            player.ChangeSprite(player.ghostSprite);
            normalWorldScene.SetActive(false);
            ghostWordScene.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (normalWorld)
            {
                ChangeWorld(1);
            }
            if (ghostWorld)
            {
                ChangeWorld(0);
            }
        }
    }
}
