using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInteraction : MonoBehaviour
{
		GameObject card;

		void Start() {
			card = this.gameObject;
			Debug.Log("Awoken");
		}

    void OnMouseEnter() {
			Debug.Log("Enter");
			card.GetComponent<Transform>().localScale += new Vector3(0.01f, 0.01f, 0);
		}

		void OnMouseExit() {
			Debug.Log("exit");
			card.GetComponent<Transform>().localScale -= new Vector3(0.01f, 0.01f, 0);
		}

		void update() {
			Vector2 size = card.GetComponent<SpriteRenderer>().sprite.bounds.size;
			card.GetComponent<BoxCollider2D>().size = size;
		}
}
