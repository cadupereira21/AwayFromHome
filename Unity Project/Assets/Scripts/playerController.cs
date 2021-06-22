using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody rb;
    public GameController gameController;

    public int sidesForce;
    public int forwardForce;
    public int MaxVelocity;

    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------
    // FixesUpdated() is the best choice when using physics in Unity.
    // Time.deltaTime stores the time of a single frame. We'll use it to balance the force applied to the player, once it can be different depending on the number
    //of frames the game is running due to the Update(), as it is called once every frame.
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------
    void FixedUpdate()
    {
        if (gameOver) return;

        if (rb.velocity.z < MaxVelocity)
        {
            // Makes the player move forward
            rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime);
        }

        // Makes the player move left when pressing "a"
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidesForce * Time.fixedDeltaTime, 0, 0);
        }

        // Makes the player move right when pressing "d"
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidesForce * Time.fixedDeltaTime, 0, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("Eu colidi com " + collision.collider.name);
            gameController.GameOver();
        }
    }
}
