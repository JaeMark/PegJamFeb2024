using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public struct RandomForceAndAngle
{
    //[Range(0.1f, 10.0f)]
    public float minForce;
    //[Range(0.1f, 10.0f)]
    public float maxForce;
    [Range(0f, 360f)]
    public float minAngle;
    [Range(0f, 360f)]
    public float maxAngle;
}

public class ObjectSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct ObjectPrefabWeight
    {
        public GameObject prefab;
        public float weight;
    }

    [SerializeField]
    private ObjectPrefabWeight[] objectPrefabs;

    [SerializeField]
    private RandomForceAndAngle forceAndAngle;

    [SerializeField]
    private float spawnInterval = 2f;

    [SerializeField]
    private float xOffset = 5.0f;

    private float totalWeight; // Total weight of all object prefabs

    private float timer = 0f;

    private void Start()
    {
        // Calculate the total weight of all object prefabs
        totalWeight = objectPrefabs.Sum(obj => obj.weight);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    private void SpawnObject()
    {
        // Apply offset to the random x position
        float randomX = Random.Range(-xOffset, xOffset);

        // Generate a random value within the total weight range
        float randomWeight = Random.Range(0f, totalWeight);

        // Choose the object prefab based on the weighted probability
        GameObject objectPrefab = ChooseObjectPrefab(randomWeight);

        // Instantiate a new object at the random x position
        GameObject newObject = Instantiate(objectPrefab, new Vector3(randomX, transform.position.y, transform.position.z), Quaternion.identity);

        // Apply random force and angle
        Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();
        float force = Random.Range(forceAndAngle.minForce, forceAndAngle.maxForce);
        float angle = Random.Range(forceAndAngle.minAngle, forceAndAngle.maxAngle);
        Vector2 forceVector = Quaternion.Euler(0, 0, angle) * Vector2.right * force;
        rb.AddForce(forceVector, ForceMode2D.Impulse);
    }

    private GameObject ChooseObjectPrefab(float randomWeight)
    {
        float cumulativeWeight = 0f;

        // Iterate over each object prefab and choose based on weighted probability
        foreach (var obj in objectPrefabs)
        {
            cumulativeWeight += obj.weight;

            // If the random weight falls within the current cumulative weight,
            // choose this object prefab
            if (randomWeight <= cumulativeWeight)
            {
                return obj.prefab;
            }
        }

        // This should not happen under normal circumstances, but just in case,
        // return the last object prefab in the array
        return objectPrefabs[objectPrefabs.Length - 1].prefab;
    }
}