using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonController : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        transform.position += direction * Time.fixedDeltaTime * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "directionnode")
        {
            direction = other.GetComponent<DirectionNode>().getDirection();
        }
    }
}
