using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteHandler : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public GameObject normalBackground;
    public GameObject ghostBackground;

    public Sprite ghostSprite;
    public Sprite normalSprite;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        normalBackground.SetActive(true);
        ghostBackground.SetActive(false);
    }
    public void ChangeSprite(Sprite newPlayerSprite ,string background)
    {
        spriteRenderer.sprite = newPlayerSprite;
        if (background == "Ghost")
        {
            normalBackground.SetActive(true);
            ghostBackground.SetActive(false);
        }
        if (background == "Normal")
        {
            normalBackground.SetActive(false);
            ghostBackground.SetActive(true);
        }
    }
}
