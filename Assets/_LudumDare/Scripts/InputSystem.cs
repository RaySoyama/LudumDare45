﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public enum InputMode
    { 
        Null,
        Keyboard,
        Controller
    }


    public static InputSystem WoofInput;


    [SerializeField] [ReadOnlyField]
    private Vector2 directionalInput;
    public Vector2 DirectionalInput
    {
        get 
        {
            return directionalInput;
        }
    }

    public float ForwadValue
    {
        get 
        {
            return directionalInput.y;
        }
    }

    public float SidewayValue
    {
        get
        {
           return directionalInput.x;
        }
    }

	[SerializeField] [ReadOnlyField]
	private bool isGrabbed = false;
	public bool IsGrabbed
	{
		get
		{
			return isGrabbed;
		}
	}

	[SerializeField]
    private KeyCode forwardKey = KeyCode.W;
    [SerializeField]
    private KeyCode backwardKey = KeyCode.S;
    [SerializeField]
    private KeyCode rightwardKey = KeyCode.D;
    [SerializeField]
    private KeyCode leftwardKey = KeyCode.A;
	[SerializeField]
	private KeyCode grabKey = KeyCode.E;

    [SerializeField]
    private string joystickHorizontal = "Horizontal";
    [SerializeField]
    private string joystickVertical = "Vertical";
    [SerializeField]
    private string grabButton = "XboxA";


    public InputMode inputMode;


    void Start()
    {
        if (WoofInput == null)
        {
            WoofInput = this;
        }
    }


    void Update()
    {
        if (Input.GetAxis(joystickHorizontal) != 0.0f || Input.GetAxis(joystickVertical) != 0.0f || Input.GetButton(grabButton))
        {
            inputMode = InputMode.Controller;
        }

        if (Input.GetKey(forwardKey) || Input.GetKey(backwardKey) || Input.GetKey(rightwardKey) || Input.GetKey(leftwardKey) || Input.GetKey(grabKey)) //Input.GetKey() ||
        {
            inputMode = InputMode.Keyboard;
        }

        if (inputMode == InputMode.Controller)
        {
            ControllerInputLoop();
        }
        else if (inputMode == InputMode.Keyboard)
        {
            KeyboardInputLoop();
        }


    }

    private void ControllerInputLoop()
    {
        directionalInput = new Vector2(Input.GetAxis(joystickHorizontal), Input.GetAxis(joystickVertical)).normalized;
        isGrabbed = Input.GetButton(grabButton);
    }

    private void KeyboardInputLoop()
    {
        Vector2 RawInput = Vector2.zero;

        if ((Input.GetKey(forwardKey)) == true)
        {
            RawInput.y += 1.0f;
        }
        if ((Input.GetKey(backwardKey)) == true)
        {
            RawInput.y -= 1.0f;
        }
        if ((Input.GetKey(rightwardKey)) == true)
        {
            RawInput.x += 1.0f;
        }
        if ((Input.GetKey(leftwardKey)) == true)
        {
            RawInput.x -= 1.0f;
        }
     
        isGrabbed = Input.GetKey(grabKey);


        directionalInput = RawInput.normalized;
    }
}
