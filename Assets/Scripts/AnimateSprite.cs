using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSprite : MonoBehaviour
{
    public Sprite[] sprites;
    public float animateTime;
    private SpriteRenderer spriteRenderer; 
    private float timeSinceLastSpriteChange = 0f;
    private int spriteNo;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
    }
    void Animate()
    {
        timeSinceLastSpriteChange += Time.deltaTime; 

        if (timeSinceLastSpriteChange >= 0.25f) 
        {
            timeSinceLastSpriteChange = 0f;
            spriteNo++;
            spriteRenderer.sprite = sprites[spriteNo%(sprites.Length)];
        }
    }

}
