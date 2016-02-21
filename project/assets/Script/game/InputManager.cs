using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
	// メンバ変数
	//--------------------------------------------------------------------
	[SerializeField]
	private zairyouFactory zairyou;     // 材料ファクトリ
	[SerializeField]
	private tileFactory       tile;     // タイルファクトリ
	[SerializeField]
	private nabe	   	nabe;     // 鍋

	private dragZairyou draggedObject;		// ドラックするオブジェクト
	private Vector2 touchOffset;		// オフセット

	private bool drag;
	Vector3 oldPosition;
	zairyou tempTile;

	void Awake()
	{
		drag = false;
	}

	void Update ()
	{
		if (HasInput)
		{
			DragOrPickUp();
		}
		else
		{
			if (drag)
			{
				drag = !drag;
				DropItem ();
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
		if (draggedObject)
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
					var obj = hit.transform.gameObject;
					draggedObject = obj.AddComponent<dragZairyou>();
					draggedObject.Zairyou = zairyou;
					draggedObject.Tile = tile;
					draggedObject.Nabe = nabe;
					touchOffset = (Vector2)hit.transform.position - inputPosition;
				}
			}
		}
	}
	private bool HasInput
	{
		get
		{
			return Input.GetMouseButton(0);
		}
	}
	void DropItem()
	{
		draggedObject.OnDrop();
	}
}
