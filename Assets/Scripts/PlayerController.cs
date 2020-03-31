using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class PlayerController : MonoBehaviour
{

		private DirectoryInfo dir;

    // Start is called before the first frame update
    void Start()
    {
			dir = new DirectoryInfo("Assets/Resources/Cards");
    }

		void ShieldSetup()
		{
			
		}

		void DeckSetup()
		{

		}

    // Update is called once per frame
    void Update()
    {

    }
}
