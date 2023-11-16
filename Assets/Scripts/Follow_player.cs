using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_player : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 cameraDistance = new Vector3(0, 1, -5);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + player.transform.rotation * cameraDistance;
        float v = 5f * Input.GetAxis("Mouse Y");
        Vector3 newRotation = new Vector3(transform.eulerAngles.x, player.transform.eulerAngles.y, player.transform.eulerAngles.z);
        transform.eulerAngles = newRotation;
        transform.Rotate(-v, 0, 0);
        // Quaternion rotation = player.transform.rotation;
        // transform.rotation = rotation;
        
        // float h = 20f * Input.GetAxis("Mouse X");
        // float v = 10f * Input.GetAxis("Mouse Y");
        //transform.Rotate(0, 0, 0);
        //transform.position = player.transform.position + cameraDistance;
        
        if (Input.GetKey(KeyCode.Equals) && cameraDistance.y > 1.0f)
        {
            cameraDistance.y -= 0.01f;
            cameraDistance.z += 0.05f;
        }

        if (Input.GetKey(KeyCode.Minus) && cameraDistance.y < 10.0f)
        {
            cameraDistance.y += 0.01f;
            cameraDistance.z -= 0.05f;
        }
    }
}
