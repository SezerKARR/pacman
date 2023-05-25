using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHome : MonoBehaviour
{
    public GameObject inSide;
    public GameObject outSide;
    public float speed = 1.0f;
    public Movement movement;
    void Start()
    {
        movement = gameObject.GetComponent<Movement>();
        StartCoroutine(ExitTransition());
    }

    private IEnumerator ExitTransition()
    {
        

        Vector3 position = transform.position;

        float duration = 0.5f;
        float elapsed = 0f;

        // Animate to the starting point
        while (elapsed < duration)
        {
            transform.position=Vector3.Lerp(position, inSide.transform.position, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0f;

        // Animate exiting the ghost home
        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(inSide.transform.position, outSide.transform.position, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Pick a random direction left or right and re-enable movement
        movement.SetDirection(new Vector2(Random.value < 0.5f ? -1f : 1f, 0f));
        movement.rigidbody.isKinematic = false;
        movement.enabled = true;
    }
}
