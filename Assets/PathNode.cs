using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    public GameObject nextPathNode;
    public bool final = false;
    private float distToEnd;

    // Start is called before the first frame update
    void Start()
    {
        if (final)
        {
            distToEnd = 0f;
        } else
        {
            distToEnd = nextPathNode.GetComponent<PathNode>().GetDistToEnd() + ((Vector2)nextPathNode.transform.position - (Vector2)transform.position).magnitude;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetDistToEnd()
    {
        return distToEnd;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if (!final) {
            Gizmos.DrawLine(transform.position, transform.position + (Vector3) ((Vector2)nextPathNode.transform.position - (Vector2)transform.position).normalized * 0.5f);
        }
        Gizmos.DrawCube(transform.position, new Vector3(0.1f, 0.1f, 1));
    }
}
