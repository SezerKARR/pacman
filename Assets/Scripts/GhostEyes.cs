using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEyes : MonoBehaviour
{
    public Sprite eyesDirectionRight;
    public Sprite eyesDirectionLeft;
    public Sprite eyesDirectionUp;
    public Sprite eyesDirectionDown;
    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeTheEyesDirection(Vector2 direction)
    {
        if (direction == Vector2.up)
        {
            spriteRenderer.sprite = eyesDirectionUp;
        }
        else if (direction == Vector2.down)
        {
            spriteRenderer.sprite = eyesDirectionDown;
        }
        else if (direction == Vector2.right)
        {
            spriteRenderer.sprite = eyesDirectionRight;
        }
        else if (direction == Vector2.left)
        {
            spriteRenderer.sprite = eyesDirectionLeft;
        }
    }
}
