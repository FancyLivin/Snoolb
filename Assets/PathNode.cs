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
}
