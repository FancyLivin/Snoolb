using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BloonController : MonoBehaviour
{
    // numSpawned and id for debug purposes.
    public static int numSpawned = 0;
    public int id = 0;
    public float speed = 1.0f;
    public Vector3 direction;

    private GameObject targetPathNode;

    public event EventHandler OnDeath;

    void Start()
    {
        OnDeath += OnBloonDeath;
        id = numSpawned;
        numSpawned += 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetDistToEnd());
    }

    void FixedUpdate()
    {
        transform.position += direction * Time.fixedDeltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Border")
        {
            OnDeath?.Invoke(this, EventArgs.Empty);
        }

        if (other.tag == "pathnode")
        {
            if (other.gameObject.GetComponent<PathNode>().final)
            {
                OnDeath?.Invoke(this, EventArgs.Empty);
            } else
            {
                setTargetPos(other.gameObject.GetComponent<PathNode>().nextPathNode);
            }
        }
    }

    private void OnBloonDeath(object sender, EventArgs e) {
        Destroy(gameObject);
    }

    public void setTargetPos(GameObject target)
    {
        targetPathNode = target;
        direction = ((Vector2)targetPathNode.transform.position - (Vector2)transform.position).normalized;
    }

    public float GetDistToEnd()
    {
        return ((Vector2)targetPathNode.transform.position - (Vector2)transform.position).magnitude + targetPathNode.GetComponent<PathNode>().GetDistToEnd();
    }
}
