using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followingCamera : MonoBehaviour
{
    public playerController playerController;
    public Vector3 playerDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Makes the camera follow the player by matching its positions every frame
        // (playerDistance is a vector that contains the distance we want between the camera and the player)
        this.transform.position = playerController.transform.position + playerDistance;
    }
}
