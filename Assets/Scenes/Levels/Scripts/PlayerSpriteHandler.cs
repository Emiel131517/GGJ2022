using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteHandler : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer backgroundSpriteRenderer;
    public Sprite normalBackground;
    public Sprite ghostBackground;
    public Sprite ghostSprite;
    public Sprite normalSprite;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        backgroundSpriteRenderer = GameObject.Find("Background").GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = normalSprite;
        backgroundSpriteRenderer.sprite = normalBackground;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSprite(Sprite newPlayerSprite, Sprite newBackgroundSprite)
    {
        spriteRenderer.sprite = newPlayerSprite;
        backgroundSpriteRenderer.sprite = newBackgroundSprite;
    }
}
