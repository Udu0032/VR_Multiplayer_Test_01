using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRBrush : MonoBehaviour
{
    [SerializeField] private int brushSize = 5; // Brush size adjustable in the editor
    [SerializeField] private Color brushColor = Color.red; // Brush color adjustable in the editor

    private Renderer brushRenderer;
    private RaycastHit hitInfo;

    void Start()
    {
        // Set the brush color to the material of the capsule
        brushRenderer = GetComponent<Renderer>();
        if (brushRenderer != null)
        {
            brushRenderer.material.color = brushColor;
        }
    }

    void Update()
    {
        Paint();
    }

    private void Paint()
    {
        // Cast a ray from the brush's position forward
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo))
        {
            // Check if the ray hits a paintable surface
            if (hitInfo.collider.CompareTag("Paintable"))
            {
                // Get the texture of the paintable surface
                Texture2D texture = hitInfo.collider.GetComponent<Renderer>().material.mainTexture as Texture2D;
                if (texture != null)
                {
                    // Convert hit point to texture coordinates
                    Vector2 pixelUV = hitInfo.textureCoord;
                    pixelUV.x *= texture.width;
                    pixelUV.y *= texture.height;

                    // Draw a square at the hit point
                    DrawSquare(texture, (int)pixelUV.x, (int)pixelUV.y, brushSize, brushColor);
                    texture.Apply();
                }
            }
        }
    }

    private void DrawSquare(Texture2D texture, int centerX, int centerY, int size, Color color)
    {
        for (int y = -size; y <= size; y++)
        {
            for (int x = -size; x <= size; x++)
            {
                int pixelX = centerX + x;
                int pixelY = centerY + y;

                if (pixelX >= 0 && pixelX < texture.width && pixelY >= 0 && pixelY < texture.height)
                {
                    texture.SetPixel(pixelX, pixelY, color);
                }
            }
        }
    }
}