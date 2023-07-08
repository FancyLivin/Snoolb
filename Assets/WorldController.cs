using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    [SerializeField]
    private Spawner bloonSpawner;

    [SerializeField]
    private const float spawnTimer = 1.0f;
}
