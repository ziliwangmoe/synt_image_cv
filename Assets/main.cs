using UnityEngine;
using System.Collections;
using System.IO;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class main : MonoBehaviour {

	private Mesh mesh;
	int numPoints = 20;
	string fileAddress = "/Users/test/Documents/opti_least_square/pointsData.csv"; 
	static int saveCount=0;
	// Use this for initialization
	void Start () {
		mesh = new Mesh();

		GetComponent<MeshFilter>().mesh = mesh;
		CreateMesh();
	}

	void CreateMesh() {
		FileStream fs = new FileStream (fileAddress, FileMode.OpenOrCreate, FileAccess.Write);  
		StreamWriter sw = new StreamWriter(fs); 
		Vector3[] points = new Vector3[numPoints];
		int[] indecies = new int[numPoints];
		Color[] colors = new Color[numPoints];
		for(int i=1;i<points.Length;++i) {
			points[i] = new Vector3(Random.Range(-10f,10f), Random.Range (-10f,10f), Random.Range (10f,30f));
			string pointData = string.Format("{0:0.0000}, {1:0.0000}, {2:0.0000}",points[i].x, points[i].y ,points[i].z);
			sw.WriteLine(pointData); 
			indecies[i] = i;
			float val= (i*10)/255.0f;
			colors[i] = new Color(val,val,val,1.0f);
			//colors[i] = new Color(1.0f, 0.0f, 0.0f ,1.0f);
		}

		mesh.vertices = points;
		mesh.colors = colors;
		mesh.SetIndices(indecies, MeshTopology.Points,0);
		   
		sw.Flush ();  
		sw.Close (); 

	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			saveCount = saveCount + 1;
			string fileName = string.Format ("/Users/test/Documents/opti_least_square/Screenshot_{0}.png", saveCount);
			Debug.Log(fileName);
			UnityEngine.Application.CaptureScreenshot(fileName);
		}
	}
}

