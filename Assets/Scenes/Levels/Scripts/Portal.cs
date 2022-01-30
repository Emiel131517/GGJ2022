using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Player player;

    public GameObject normalWorldScene;
    public GameObject ghostWorldScene;
    public Transform endPoint;
    void Start()
    {
        normalWorldScene.SetActive(true);
        ghostWorldScene.SetActive(false);
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    public void ChangeWorld(int w)
    {
        if (w.Equals(0))
        {
            player.ChangeSprite(player.normalSprite, player.normalBackground);
            normalWorldScene.SetActive(true);
            ghostWorldScene.SetActive(false);
            player.transform.position = endPoint.transform.position;
        }
        if (w.Equals(1))
        {
            player.ChangeSprite(player.ghostSprite, player.ghostBackground);
            normalWorldScene.SetActive(false);
            ghostWorldScene.SetActive(true);
            player.transform.position = endPoint.transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (normalWorldScene.activeSelf)
            {
                ChangeWorld(1);
            }
            else if (!normalWorldScene.activeSelf)
            {
                ChangeWorld(0);
            }
        }
    }
}
