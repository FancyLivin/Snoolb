using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject bloonPrefab;

    private List<GameObject> activeBloons;

    [SerializeField] private GameObject firstPathNode;

    private void Start()
    {
        activeBloons = new List<GameObject>();
    }

    public void Spawn()
    {
        if (activeBloons.Count < 5)
        {
            var rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
            var spawnedBloon = Instantiate(bloonPrefab, transform.position, rotation);

            spawnedBloon.GetComponent<BloonController>().destroyHandler = DestroyBloon;
            spawnedBloon.GetComponent<BloonController>().setTargetPos(firstPathNode);

            activeBloons.Add(spawnedBloon);
        }
    }

    public void DestroyAllBloons()
    {
        foreach (var bloon in activeBloons)
        {
            Destroy(bloon);
        }
        activeBloons.Clear();
    }

    private void DestroyBloon(GameObject bloon)
    {
        Destroy(bloon);
    }

    private void Update()
    {
        for (int i = activeBloons.Count - 1; i >= 0; --i)
        {
            var bloon = activeBloons[i];
            if (bloon.activeSelf)
            {
                if (bloon.transform.position.y > 5)
                {
                    Destroy(bloon);
                    activeBloons.RemoveAt(i);
                }
            }
            else
            {
                activeBloons.RemoveAt(i);
            }
        }
    }
}
