using System.Collections;
using System.Collections.Generic;
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
    [SerializeField]
    private GameObject objectPrefab;

    [SerializeField]
    private RandomForceAndAngle forceAndAngle;

    [SerializeField]
    private float spawnInterval = 2f;

    [SerializeField]
    private float xOffset = 5.0f;

    private float timer = 0f;

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

        // Instantiate a new object at the random x position
        GameObject newObject = Instantiate(objectPrefab, new Vector3(randomX, transform.position.y, transform.position.z), Quaternion.identity);


        // Apply random force and angle
        Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();
        float force = Random.Range(forceAndAngle.minForce, forceAndAngle.maxForce);
        float angle = Random.Range(forceAndAngle.minAngle, forceAndAngle.maxAngle);
        Vector2 forceVector = Quaternion.Euler(0, 0, angle) * Vector2.right * force;
        rb.AddForce(forceVector, ForceMode2D.Impulse);
    }
}