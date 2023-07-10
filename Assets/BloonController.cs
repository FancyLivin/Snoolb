using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonController : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 direction;

    public delegate void DestroyBloon(GameObject bloon);
    public DestroyBloon destroyHandler;

    private GameObject targetPathNode;

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
            destroyHandler(gameObject);
        }

        if (other.tag == "pathnode")
        {
            if (other.gameObject.GetComponent<PathNode>().final)
            {
                destroyHandler(gameObject);
            } else
            {
                setTargetPos(other.gameObject.GetComponent<PathNode>().nextPathNode);
            }
        }
    }

    public void setTargetPos(GameObject target)
    {
        targetPathNode = target;
        direction = ((Vector2)targetPathNode.transform.position - (Vector2)transform.position).normalized;
        Debug.Log(direction);
    }

    public float GetDistToEnd()
    {
        return ((Vector2)targetPathNode.transform.position - (Vector2)transform.position).magnitude + targetPathNode.GetComponent<PathNode>().GetDistToEnd();
    }
}
