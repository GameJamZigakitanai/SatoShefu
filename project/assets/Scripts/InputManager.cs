﻿using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
	private bool draggingItem = false;
	private GameObject draggedObject;
	private Vector2 touchOffset;

	static public string[] ingredients = new string[] {
		"beef",
		"carrot",
		"chicken",
		"honey",
		"mushroom",
		"onion",
		"pork",
		"potato",
		"shrimp",
		"spice",
		"tomato"
	};

	private bool drag;
	Vector3 oldPosition;
	tileItem tempTile;

	private tileFactory tileFactory;

	void Start()
	{
		drag = false;
		tileFactory = GameObject.Find ("PanelTile").GetComponent<tileFactory> ();
	}

	void Update ()
	{
		if (HasInput)
		{
			DragOrPickUp();
		}
		else
		{
			if (drag) {
				drag = !drag;
				DropItem ();
				/*
				if (draggedObject.transform.position.y < tileFactory.Bottom) {
					draggingItem = false;
					tempTile = draggedObject.GetComponent<tileItem>();
					Debug.Log(tempTile.number);

					//Destroy (draggedObject);
					Debug.Log (oldPosition);
				} else {
					draggedObject.transform.position = oldPosition;
					if (draggingItem)
						DropItem();
				}
				*/
			}

		}
	}
	Vector2 CurrentTouchPosition
	{
		get
		{
			return Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
	}
	private void DragOrPickUp()
	{
		var inputPosition = CurrentTouchPosition;
		if (draggingItem)
		{
			if (!drag) {
				drag = !drag;
				oldPosition = new Vector3 (draggedObject.transform.position.x, draggedObject.transform.position.y, draggedObject.transform.position.z);

			}
			draggedObject.transform.position = inputPosition + touchOffset;
		}
		else
		{
			RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f);
			if (touches.Length > 0)
			{
				var hit = touches[0];
				if (hit.transform != null)
				{
					draggingItem = true;
					draggedObject = hit.transform.gameObject;
					touchOffset = (Vector2)hit.transform.position - inputPosition;
					draggedObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
				}
			}
		}
	}
	private bool HasInput
	{
		get
		{
			// returns true if either the mouse button is down or at least one touch is felt on the screen
			return Input.GetMouseButton(0);
		}
	}
	void DropItem()
	{
		draggingItem = false;
		draggedObject.transform.localScale = new Vector3(1.5f, 1.5f, 1);
		Debug.Log (draggedObject.transform.position.y + ", " + tileFactory.Bottom);
		if (draggedObject.transform.position.y < tileFactory.Bottom) {
			tempTile = draggedObject.GetComponent<tileItem>();
			int tempNum = Random.Range (0, InputManager.ingredients.Length-1);
			Debug.Log (tempNum);
			tempTile.tag = InputManager.ingredients[tempNum];
			tempTile.GetComponent<SpriteRenderer> ().sprite = Resources.Load(InputManager.ingredients[tempNum], typeof(Sprite)) as Sprite;
		}
		draggedObject.transform.position = oldPosition;
	}
}
