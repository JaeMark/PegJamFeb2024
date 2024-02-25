using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormChanger : MonoBehaviour
{
    [SerializeField]
    private GameObject newForm;

    public void ChangeForm()
    {
        // Find the child object called "Body" under newForm
        Transform newFormBodyTransform = newForm.transform.Find("Body");

        // Check if the child object exists
        if (newFormBodyTransform != null)
        {
            // Find the child object called "Body" under the current GameObject
            Transform currentBodyTransform = transform.Find("Body");

            // Check if the child object exists under the current GameObject
            if (currentBodyTransform != null)
            {
                // Store the current transform and velocity
                Vector3 currentPosition = transform.position;
                Vector3 currentVelocity = currentBodyTransform.gameObject.GetComponent<Rigidbody2D>().velocity;
                Quaternion currentRotation = transform.rotation;

                // Destroy the current "Body" object
                Destroy(currentBodyTransform.gameObject);

                // Instantiate the new "Body" object from newForm and set it as a child of the current GameObject
                GameObject newBodyInstance = Instantiate(newFormBodyTransform.gameObject, transform);
                newBodyInstance.name = "Body"; // Ensure the new body has the correct name

                // Restore the original transform and velocity
                transform.position = currentPosition;
                newBodyInstance.GetComponent<Rigidbody2D>().velocity = currentVelocity;
                transform.rotation = currentRotation;
            }
            else
            {
                Debug.LogWarning("No child object named 'Body' found under the current GameObject.");
            }
        }
        else
        {
            Debug.LogWarning("No child object named 'Body' found under the newForm GameObject.");
        }
    }
}