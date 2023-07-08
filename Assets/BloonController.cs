using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonController : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 direction;

    public delegate void DestroyBloon(GameObject bloon);
    public DestroyBloon destroyHandler;

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        transform.position += direction * Time.fixedDeltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Border")
        {
            destroyHandler(gameObject);
        }

        if (other.tag == "directionnode")
        {
            direction = other.GetComponent<DirectionNode>().getDirection();
        }
    }
}
