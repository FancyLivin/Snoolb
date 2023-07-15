using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletController : MonoBehaviour
{
    private GameObject targetBloon;

    [SerializeField] private float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.position += (Vector3) ((Vector2) targetBloon.transform.position - (Vector2) transform.position).normalized * Time.fixedDeltaTime * speed;
    }

    public void SetTarget(GameObject bloon) {
        targetBloon = bloon;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "bloon")
        {
            Destroy(gameObject);
        }
    }
}
