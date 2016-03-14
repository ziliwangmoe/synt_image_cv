using UnityEngine;
using System.Collections;

public class saveSCreen : MonoBehaviour {
	static int saveCount=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q))
		{
			saveCount = saveCount + 1;
			string fileName = string.Format ("/Users/test/Documents/opti_least_square/Screenshot_{0}.png", saveCount);
			Debug.Log(fileName);
			UnityEngine.Application.CaptureScreenshot(fileName);
		}
	
	}
}
