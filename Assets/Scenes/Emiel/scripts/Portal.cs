using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Player player;

    public GameObject normalWorldScene;
    public GameObject ghostWorldScene;
    public Transform endPoint;
    private bool normalWorld;
    void Start()
    {
        if (normalWorld)
        {
            normalWorldScene.SetActive(true);
            ghostWorldScene.SetActive(false);
        }
        normalWorld = true;
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (normalWorld == true)
        {
            normalWorldScene.SetActive(true);
            ghostWorldScene.SetActive(false);
        }
        if (normalWorld == false)
        {
            normalWorldScene.SetActive(false);
            ghostWorldScene.SetActive(true);
        }
        Debug.Log(normalWorld);
    }
/*    public void ChangeWorld(int w)
    {
        if (w.Equals(0))
        {
            normalWorld = true;
            player.ChangeSprite(player.normalSprite);
            normalWorldScene.SetActive(true);
            ghostWorldScene.SetActive(false);
        }
        if (w.Equals(1))
        {
            normalWorld = false;
            player.ChangeSprite(player.ghostSprite);
            normalWorldScene.SetActive(false);
            ghostWorldScene.SetActive(true);
        }
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (normalWorld)
            {
                normalWorld = false;
                player.transform.position = endPoint.transform.position;
            }
            if (!normalWorld)
            {
                normalWorld = true;
                player.transform.position = endPoint.transform.position;
            }
        }
    }
}
