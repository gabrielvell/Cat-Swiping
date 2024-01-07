using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spritePrefab; // Reference to the sprite prefab
    public int maxSpawnedItems = 5; // Maximum number of spawned items
    int mask = LayerMask.GetMask("spriteLayer");

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
        float yBounds = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y,
            Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float xBounds = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x,
            Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        Vector2 spawnPos = new Vector2(xBounds, yBounds);

        Collider2D spriteCollision = Physics2D.OverlapBox(spawnPos, new Vector2(1.0f,1.0f), mask);
        if (spriteCollision != null)
        {
            Instantiate(spritePrefab, spawnPos, Quaternion.identity);
        }





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