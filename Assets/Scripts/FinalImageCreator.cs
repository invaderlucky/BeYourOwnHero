using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class FinalImageCreator : MonoBehaviour {
	[DllImport("__Internal")]
	private static extern string PrintFrameJs(byte[] img, int size);

	public int resWidth = 512;
	public int resHeight = 512;
	public Camera charCamera;

	string url;

	public void TakeScreenshot() {
//		RenderTexture rt = new RenderTexture (resWidth, resHeight, 24);
//		charCamera.targetTexture = rt;
//		charCamera.Render ();
//		charCamera.targetTexture = null;
//		Texture2D screenShot = new Texture2D (resWidth, resHeight, TextureFormat.RGB24, false);
//		RenderTexture.active = rt;
//		screenShot.ReadPixels (new Rect (0, 0, resWidth, resHeight), 0, 0);
//		RenderTexture.active = null; // JC: added to avoid errors
//		Destroy (rt);
//		byte[] img = screenShot.EncodeToPNG ();
//
//		PrintFrameJs (img, img.Length);
		StartCoroutine(MyScreenShot());
	}

	IEnumerator MyScreenShot() {
		yield return new WaitForEndOfFrame ();
		var tex = new Texture2D( Screen.width, Screen.height, TextureFormat.RGB24, false );

		tex.ReadPixels( new Rect(0, 0, Screen.width, Screen.height), 0, 0 );
		tex.Apply();
		byte[] img = tex.EncodeToPNG ();
		url = PrintFrameJs (img, img.Length);
		Debug.Log ("After MyScreenshot: " + url);
	}

	public void OpenOnClick() {
		Debug.Log ("On click: " + url);
		Application.OpenURL (url);
	}
}
