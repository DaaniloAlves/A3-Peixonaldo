using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
	[SerializeField] private GameObject player;
	private PlayerInput playerInput;
	private InputAction touchPositionAction;
	private InputAction touchPressAction;

	private void Awake()
	{
		playerInput = GetComponent<PlayerInput>();
		touchPressAction = playerInput.actions["TouchPress"];
		touchPressAction = playerInput.actions["TouchPosition"];
	}

	private void OnEnable()
	{
		touchPressAction.performed += TouchPressed;
	}
	private void OnDisable()
	{
		touchPressAction.performed -= TouchPressed;
	}

	private void TouchPressed(InputAction.CallbackContext context)
	{
		Vector3 position = Camera.main.ScreenToViewportPoint(touchPositionAction.ReadValue<Vector2>());
		position.z = player.transform.position.z;
		player.transform.position = position;
	}

	private void Update()
	{
		if (touchPositionAction.WasPerformedThisFrame())
		{
			Vector3 position = Camera.main.ScreenToWorldPoint(touchPositionAction.ReadValue<Vector2>());
			position.z = player.transform.position.z;
			player.transform.position = position;
		}
	}
}
