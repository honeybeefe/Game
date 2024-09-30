using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadLine
{
    LEFT =-1,
    MIDDLE,
    RIGHT
}

public class Runner : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] RoadLine roadLine;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] float speed = 25.0f;
    [SerializeField] float positionX = 2.5f; 

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        InputManager.Instance.action += OnKeyUpdate;
    }

    void Start()
    {
        roadLine = RoadLine.MIDDLE;
    }

    void OnKeyUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(roadLine!=RoadLine.LEFT)
            {
                animator.Play("Left Avoid");

                roadLine --;
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(roadLine!=RoadLine.RIGHT)
            {
                animator.Play("Right Avoid");

                roadLine++;
            }
        }
    }

    private void Move()
    {
        rigidbody.position= Vector3.Lerp
         (
            rigidbody.position,
            new Vector3((int)roadLine * positionX, 0, 0),
            speed*Time.fixedDeltaTime
            );
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnDisable()
    {
        InputManager.Instance.action -= OnKeyUpdate;
    }
}