using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homemove : MonoBehaviour
{
    public float spercent;
    public float speed = 5f;
    public float finalSpeed;
    public float percent;
    public float IdleRandom;
    Animator _animator;
    public CharacterController _controller;
    Camera _camera;
    public float smoothness = 10f;
    

    // Start is called before the first frame update
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _controller = this.GetComponent<CharacterController>();
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetLayerWeight(3, 0.9f);
        InputMovement();
        Vector3 playerRotate = Vector3.Scale(_camera.transform.forward, new Vector3(1,0,1));
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerRotate), Time.deltaTime * smoothness);
    }

    void InputMovement()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        Vector3 moveDirection = forward * v + right * h;
        moveDirection = moveDirection.normalized;

        finalSpeed = speed / 10f;

        if(v < 0)
        {
            percent = -1.0f;
        }
        else if(v == 0)
        {
            percent = 0.0f;

        }
        else
        {
            percent = 0.5f;
        }

        if(h > 0)
        {
            spercent =  0.5f;
        }
        else if(h < 0)
        {
            spercent =  -0.5f;
        }
        else
        {
            spercent = 0;
        }


        IdleRandom = 1.75f;


        _animator.SetFloat("LR", spercent, 0.1f, Time.deltaTime);
        _animator.SetFloat("Side", IdleRandom, 0.1f, Time.deltaTime/10.0f);
        _animator.SetFloat("Blend", percent, 0.1f, Time.deltaTime);
        _controller.Move(moveDirection * finalSpeed * Time.deltaTime);
    }
}
