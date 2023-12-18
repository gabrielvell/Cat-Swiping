using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool redLightgreen = true;
    public float timerDuration = 5f; // Set the duration in seconds
    public Color falseColor = Color.red; // Set the color when the boolean is false
    private Color originalColor;
    
    private float timer;
    private SpriteRenderer spriteRenderer;
    
    // Store the original color for later use

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        // Check if the timer has elapsed
        if (timer <= 0f)
        {
            // Change the boolean variable to false
            redLightgreen = !redLightgreen;

            // Optionally, you can reset the timer for continuous toggling
            timer = timerDuration;
            
            // Change the sprite color to falseColor
            spriteRenderer.color = falseColor;
        }
        else
        {
            // Decrease the timer by the elapsed time since the last frame
            timer -= Time.deltaTime;
            
            // Change the sprite color back to the original color when the boolean is true
            if (redLightgreen)
            {
                spriteRenderer.color = originalColor;
            }
        }
    }
}
