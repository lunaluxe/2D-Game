using UnityEngine;

public class RubyController : MonoBehaviour
{
    Vector2 position; //Vector 2 is a representation of 2D vectors and points, used to represent 2D positions of (our character's) X and Y 
    void Update() //Update() runs every frame - useful for  input compared to FixedUpdate.
    {
        position.x += (Input.GetAxis("x") * 3.0f * Time.deltaTime); //Input ensures position.x, position.y movements are mapped to w, a, s, d and the arrow keys.
        position.y += (Input.GetAxis("y") * 3.0f * Time.deltaTime); // Axes renamed in project settings to x and y for consistency with positioning
        transform.position = position;
    }
}