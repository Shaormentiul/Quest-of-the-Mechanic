using UnityEngine;

public class Gust : MonoBehaviour
{
    public float forceStrength = 10f; // Adjust as needed
    public GameObject fan;

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb != null)
        {
            // Get the forward direction of the fan
            Vector3 forceDirection = fan.transform.forward;
            
            // Apply force to the object
            rb.AddForce(forceDirection * forceStrength, ForceMode.Force);
        }
    }
}
