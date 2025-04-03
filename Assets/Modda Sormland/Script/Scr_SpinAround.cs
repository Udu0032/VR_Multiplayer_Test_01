using UnityEngine;

public class Scr_SpinAround : MonoBehaviour
{
    // Speed of rotation in degrees per second
    public float rotationSpeed = 45f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around the y-axis
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    
    }
}
