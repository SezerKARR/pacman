using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public List<Vector2> avaliableDirections;
    // Start is called before the first frame update
    void Start()
    {
        avaliableDirections = new List<Vector2>();
        checkAvaliableDirections(Vector2.up);
        checkAvaliableDirections(Vector2.down);
        checkAvaliableDirections(Vector2.right);
        checkAvaliableDirections(Vector2.left);
    }
    
    private void checkAvaliableDirections(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position,Vector2.one*0.5f,0,direction,0.5f,obstacleLayer);
        if (hit.collider == null)
        {
            avaliableDirections.Add(direction);
        }
        
    }
}
