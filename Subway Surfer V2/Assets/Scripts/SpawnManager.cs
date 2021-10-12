using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] tilePrefab;
    [SerializeField] private float zSpawn = 0;
    [SerializeField] private float tileLength = 30;
    [SerializeField] private int numberOfTiles = 5;
    [SerializeField] private Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
            SpawnTile(Random.Range(0, tilePrefab.Length));
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - 35 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefab.Length));
            DeleteTile();
        }
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefab[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }
}
