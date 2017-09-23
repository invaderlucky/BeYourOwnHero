using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour {
	public GameObject representation;
	public Color [] colors;

	// Use this for initialization
	void Start() 
	{
		
	}

	public void ChangeToPressed(Sprite newImage) {
		Image image = representation.GetComponent<Image> ();
		image.sprite = newImage;
	}

	public void ChangeToColor(int i) {
		Image image = representation.GetComponent<Image> ();
		image.color = this.colors[i];
		Debug.Log ("Color changed for " + representation.name);
	}
}
