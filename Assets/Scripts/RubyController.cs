using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 3.0f;

    public int maxHealth = 5;
    public float timeInvincible = 2.0f;

    public int health { get { return currentHealth; } }
    int currentHealth;
    bool isInvincible;
    float invincibleTimer;

    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("x");
        float vertical = Input.GetAxis("y");

        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        Debug.Log(currentHealth + "/" + maxHealth);
    }
}


//OLD SCRIPT
//using UnityEngine;

//public class RubyController : MonoBehaviour
//{
//  Vector2 position; //Vector 2 is a representation of 2D vectors and points, used to represent 2D positions of (our character's) X and Y 
//void Update() //Update() runs every frame - useful for input compared to FixedUpdate.
// {
//      position.x += (Input.GetAxis("x") * 3.0f * Time.deltaTime); //Input ensures position.x, position.y movements are mapped to w, a, s, d and the arrow keys.
//    position.y += (Input.GetAxis("y") * 3.0f * Time.deltaTime); // Axes renamed in project settings to x and y for consistency with positioning
//  transform.position = position;
// }
//}
