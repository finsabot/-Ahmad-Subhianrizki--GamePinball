using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public KeyCode input;
    private float targetPressed;
    private float targetRelease;
    private HingeJoint hinge;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();

        targetPressed = hinge.limits.max;
        targetRelease = hinge.limits.min;
    }

    // Update is called once per frame
    private void Update()
    {
            // Read Input
            ReadInput();
            // Move Paddle
    }


    private void ReadInput()
    {
        JointSpring jointSpring = hinge.spring;
        // Read Input Here
        if (Input.GetKey(input))
        {
            jointSpring.targetPosition = targetPressed;
        }
        else
        {
            jointSpring.targetPosition = targetRelease;
        }

        hinge.spring = jointSpring;
    }
}
