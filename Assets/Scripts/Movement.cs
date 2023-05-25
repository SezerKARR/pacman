using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public LayerMask obstacleLayer;
    public Vector2 initialDirection;
    public Rigidbody2D rigidbody;
    public float speed=5f;
    public Vector2 direction;
    public Vector2 nextDirection { get; private set; }
    public float speedMultiplier = 1f;
    public GhostEyes ghostEyes { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        ghostEyes = GetComponentInChildren<GhostEyes>();
        rigidbody = GetComponent<Rigidbody2D>();
        resetState();
    }
    void resetState()
    {
        direction = initialDirection;
    }
    // Update is called once per frame
    void Update()
    {
        if (nextDirection != Vector2.zero)
        {
            SetDirection(nextDirection);
        }
    }
    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        Vector2 translation = direction * speed * speedMultiplier * Time.fixedDeltaTime;

        rigidbody.MovePosition(position + translation);
    }
    public void SetDirection(Vector2 direction)
    {
        
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.75f, 0, direction, 1.5f, obstacleLayer);

        if (hit.collider == null)
        {
            
            this.direction = direction;
            if (ghostEyes != null)
            {

                ghostEyes.ChangeTheEyesDirection(direction);
            }
            nextDirection = Vector2.zero;
        }
        if (hit.collider != null)
        {
            nextDirection = direction;
        }
    }
    /*void move()
    {
        rigidbody.MovePosition(rigidbody.position+(direction * speed * Time.fixedDeltaTime));
    }*/
    

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.layer == LayerMask.NameToLayer("Node"))
        {
            Debug.Log("geldi");
            if (collision.gameObject.GetComponent<Node>().avaliableDirections.Contains(nextDirection))
            {
                Debug.Log("geldi2");
                direction = nextDirection;
            }

        }
    }*/

}
