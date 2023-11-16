using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Character_move : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _velocity;
    private bool _grounded;
    private float _walking;
    [SerializeField] private float speed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpHeight;
    private float _gravity = -9.81f;
    
    [SerializeField] private float horizontalSpeed = 20f;
    [SerializeField] private float verticalSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(0, h, 0);

        _walking = 0;
        _grounded = _controller.isGrounded;
        if (_grounded && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }
        
        //Vector3 move = new Vector3(_controller.transform.forward.x * Input.GetAxis("Horizontal"), 0, _controller.transform.forward.z * Input.GetAxis("Vertical"));
        // Vector3 move = new Vector3(_controller.transform.forward.x * Input.GetAxis("Horizontal"), _controller.transform.forward.y,  _controller.transform.forward.z * Input.GetAxis("Vertical"));
        // _controller.Move(move * Time.deltaTime * speed);

        /*if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }*/
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _walking = 1f;
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            _controller.Move(_controller.transform.forward * Time.deltaTime * (speed - walkSpeed * _walking));
        }

        if (Input.GetKey(KeyCode.A))
        {
            _controller.Move(Quaternion.Euler(0, -90, 0) * _controller.transform.forward * Time.deltaTime * (speed - walkSpeed * _walking));
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            _controller.Move(Quaternion.Euler(0, 90, 0) * _controller.transform.forward * Time.deltaTime * (speed - walkSpeed * _walking));
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            _controller.Move(-_controller.transform.forward * Time.deltaTime * (speed - walkSpeed * _walking));
        }

        if (Input.GetButtonDown("Jump") && _grounded)
        {
            _velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * _gravity);
        }

        if (!_grounded)
        {
            _velocity.y += _gravity * Time.deltaTime;
        }

        _controller.Move(_velocity * Time.deltaTime);
    }
}
