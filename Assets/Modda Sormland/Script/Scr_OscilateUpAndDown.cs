using UnityEngine;

public class Scr_OscilateUpAndDown : MonoBehaviour
{
    public float amplitude = 1f; // The height of the oscillation
    public float frequency = 1f; // The speed of the oscillation
    private float initialY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialY = transform.position.y; // Store the initial y position
    }

    // Update is called once per frame
    void Update()
    {
        float newY = initialY + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
