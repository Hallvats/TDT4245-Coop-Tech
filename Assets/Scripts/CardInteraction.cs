using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInteraction : MonoBehaviour
{
		GameObject card;
		Transform cardT;
		Vector3 oldMouse;
		bool hover = false;
		bool drag = false;

		void Start() {
			oldMouse = getMouseWorldPosition();
			card = this.gameObject;
			cardT = card.GetComponent<Transform>();
			BoxCollider2D bc = card.AddComponent<BoxCollider2D>() as BoxCollider2D;
			Debug.Log("Awoken");
			Vector2 spriteSize = card.GetComponent<SpriteRenderer>().sprite.bounds.size;
			Debug.Log(spriteSize);
			Vector2 collSize = card.GetComponent<BoxCollider2D>().size;
			Debug.Log(collSize);
			collSize = spriteSize;
			Debug.Log(collSize);
		}

		Vector3 getMouseWorldPosition() {
			Camera cam = Camera.main;
			Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
			return cam.ScreenToWorldPoint(mouse);
		}

		Vector3 getMouseDelta() {
			Vector3 mouse = getMouseWorldPosition();
			return mouse - oldMouse;
		}

    void OnMouseEnter() {
			Debug.Log("Enter");
			hover = true;
			card.GetComponent<Transform>().localScale += new Vector3(0.01f, 0.01f, 0);
		}

		void OnMouseExit() {
			Debug.Log("exit");
			hover = false;
			card.GetComponent<Transform>().localScale -= new Vector3(0.01f, 0.01f, 0);
		}

		void Update() {
			if(Input.GetKey(KeyCode.Mouse0)) {
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
