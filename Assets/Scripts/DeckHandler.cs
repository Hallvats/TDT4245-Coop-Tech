using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class DeckHandler : MonoBehaviour
{

		public Stack<string> stringDeck;
		public Sprite back;

		private Transform transform;
		private SpriteRenderer spriteRenderer;
		private BoxCollider2D collider;

		private bool hover = false;

		private DirectoryInfo dir;

    // Start is called before the first frame update
    void Start()
    {
			dir = new DirectoryInfo("Assets/Resources/Cards");

			gameObject.AddComponent<SpriteRenderer>();
			gameObject.AddComponent<BoxCollider2D>();

			transform = gameObject.GetComponent<Transform>();
			spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
			collider = gameObject.GetComponent<BoxCollider2D>();

			transform.localScale = new Vector2(0.03f, 0.03f);

			stringDeck = new Stack<string>();
			if(name == "Deck") {
				CreateDeck();
			} else if (name == "DiscardPile") {
				CreateDiscardPile();
			} else if (name == "EnergyDeck") {
				CreateEnergyDeck();
			}
    }

		void CreateDeck()
		{
			FileInfo pileInfo = dir.GetFiles("Misc/Deck.png")[0];

			spriteRenderer.sprite = (Sprite) AssetDatabase.LoadAssetAtPath("Assets" + pileInfo.FullName.Substring(Application.dataPath.Length), typeof(Sprite));
			collider.size = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
		}

		void CreateDiscardPile()
		{
			FileInfo pileInfo = dir.GetFiles("Misc/Discard.png")[0];

			spriteRenderer.sprite = (Sprite) AssetDatabase.LoadAssetAtPath("Assets" + pileInfo.FullName.Substring(Application.dataPath.Length), typeof(Sprite));
			collider.size = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
		}

		void CreateEnergyDeck()
		{
			FileInfo energyInfo = dir.GetFiles("Energy/Energy.png")[0];
			FileInfo doubleEnergyInfo = dir.GetFiles("Energy/Double Energy.png")[0];
			FileInfo pileInfo = dir.GetFiles("Misc/Energy.png")[0];

			spriteRenderer.sprite = (Sprite) AssetDatabase.LoadAssetAtPath("Assets" + pileInfo.FullName.Substring(Application.dataPath.Length), typeof(Sprite));
			collider.size = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;

			for(int i = 0; i < 100; i++) {
				if(Random.value <= 0.1f) {
					stringDeck.Push("Assets" + doubleEnergyInfo.FullName.Substring(Application.dataPath.Length));
				} else {
					stringDeck.Push("Assets" + energyInfo.FullName.Substring(Application.dataPath.Length));
				}
			}
		}

		void OnMouseEnter()
		{
			hover = true;
			gameObject.GetComponent<Transform>().localScale += new Vector3(0.01f, 0.01f, 0);
		}

		void OnMouseExit()
		{
			hover = false;
			gameObject.GetComponent<Transform>().localScale -= new Vector3(0.01f, 0.01f, 0);
		}

		Vector3 getMouseWorldPosition()
		{
			Camera cam = Camera.main;
			Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
			return cam.ScreenToWorldPoint(mouse);
		}

		void DrawFromDeck()
		{
			GameObject newCard = Instantiate(Resources.Load("Prefabs/Card")) as GameObject;
			string cardPath = stringDeck.Pop();
			newCard.GetComponent<SpriteRenderer>().sprite = (Sprite) AssetDatabase.LoadAssetAtPath(cardPath, typeof(Sprite));
			CardInteraction cardInteraction = newCard.GetComponent<CardInteraction>();
			cardInteraction.hover = true;
			cardInteraction.drag = true;
			Vector3 mousePosition = getMouseWorldPosition();
			newCard.GetComponent<Transform>().position = new Vector3(mousePosition.x, mousePosition.y, 0);
		}

    // Update is called once per frame
    void Update()
    {
			if(Input.GetKeyDown(KeyCode.Mouse0)) {
				if(hover) {
					hover = false;
					DrawFromDeck();
				}
			}
    }
}
