using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInteraction : MonoBehaviour
{
		GameObject card;
		Transform cardT;
		Vector3 oldMouse;
		public bool hover = false;
		public bool drag = false;

		void Start()
		{
			oldMouse = getMouseWorldPosition();
			card = this.gameObject;
			cardT = card.GetComponent<Transform>();
			cardT.localScale = new Vector2(0.03f, 0.03f);
			BoxCollider2D bc = card.AddComponent<BoxCollider2D>() as BoxCollider2D;
			Vector2 spriteSize = card.GetComponent<SpriteRenderer>().sprite.bounds.size;
			Vector2 collSize = card.GetComponent<BoxCollider2D>().size;
			collSize = spriteSize;
		}

		Vector3 getMouseWorldPosition()
		{
			Camera cam = Camera.main;
			Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
			return cam.ScreenToWorldPoint(mouse);
		}

		Vector3 getMouseDelta()
		{
			Vector3 mouse = getMouseWorldPosition();
			return mouse - oldMouse;
		}

    void OnMouseEnter()
		{
			hover = true;
			card.GetComponent<Transform>().localScale += new Vector3(0.005f, 0.005f, 0);
		}

		void OnMouseExit()
		{
			hover = false;
			card.GetComponent<Transform>().localScale -= new Vector3(0.005f, 0.005f, 0);
		}

		void Update()
		{
			if(Input.GetKeyDown(KeyCode.Mouse0)) {
				if(hover) {
					drag = true;
				}
			}
			if(drag) {
				if(!Input.GetKey(KeyCode.Mouse0)) {
					drag = false;
				} else {
					Vector3 delta = getMouseDelta();
					cardT.Translate(new Vector3(delta.x, delta.y, 0));
				}
			}
			oldMouse = getMouseWorldPosition();
		}
}
