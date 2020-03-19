using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class Demo : MonoBehaviour
{

		//public List<GameObject> shields;
		public List<GameObject> hand;
		//public Stack<GameObject> energyDeck;
		//public Stack<GameObject> actionDeck;
		//public Stack<GameObject> discardPile;
    // Start is called before the first frame update
    void Start()
    {
			DirectoryInfo dir = new DirectoryInfo("Assets/Resources/Cards/Action/Offense");
			FileInfo[] info = dir.GetFiles("*.png");
			foreach(FileInfo f in info) {
				GameObject newCard = Instantiate(Resources.Load("Prefabs/Card")) as GameObject;
				//(newCard.GetComponent<Transform>().
				newCard.GetComponent<SpriteRenderer>().sprite = (Sprite) AssetDatabase.LoadAssetAtPath("Assets" + f.FullName.Substring(Application.dataPath.Length), typeof(Sprite));
				hand.Add(newCard);
				break;
			}
    }

    // Update is called once per frame
    void Update()
    {
		
    }
}
