using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spritePrefab; // Reference to the sprite prefab
    public int maxSpawnedItems = 5; // Maximum number of spawned items
    public Vector2 spawnArea = new Vector2(5f, 5f); // Range for random spawning

    private void Start()
    {
        SpawnItems();
    }

    void SpawnItems()
    {
        for (int i = 0; i < maxSpawnedItems; i++)
        {
            SpawnSprite();
        }
    }

    void SpawnSprite()
    {
        // Generate a random position within the specified range
        Vector3 randomPosition = transform.position + new Vector3(Random.Range(-spawnArea.x / 2f, spawnArea.x / 2f), 0f, Random.Range(-spawnArea.y / 2f, spawnArea.y / 2f));

        // Instantiate a new sprite at the random position
        Instantiate(spritePrefab, randomPosition, Quaternion.identity, transform);
    }

    // Call this method when an item is destroyed or removed
    public void ItemDestroyed()
    {
        // Check if the number of spawned items is below the limit
        if (transform.childCount < maxSpawnedItems)
        {
            // Spawn a new item
            SpawnSprite();
        }
    }
}