using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //speed camera follows
    public float speed = 5f;
    
    //set the Z away so it is zoomed out
    public Vector3 offsetCamera = new Vector3(0, 0, -5);

    private Transform playerTransform; 



    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        
        if (player != null)
        {
            playerTransform = player.transform;
        }
        if (playerTransform != null)
        {
            //update camera position with that of the player but offset by the camera
            Vector3 targetPosition = playerTransform.position + offsetCamera;
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed);
        }
    }
}
