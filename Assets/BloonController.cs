using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonController : MonoBehaviour
{
    public float speed = 1.0f;

    public delegate void DestroyBloon(GameObject bloon);
    public DestroyBloon destroyHandler;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Border")
        {
            destroyHandler(gameObject);
        }
    }
}
