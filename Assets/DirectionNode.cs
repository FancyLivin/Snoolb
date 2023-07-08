using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionNode : MonoBehaviour
{
    public int x = 1;
    public int y = 0;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(x, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getDirection()
    {
        return direction;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(x, y, 0));
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }
}
