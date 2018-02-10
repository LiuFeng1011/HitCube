using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] 
public class GameBg : MonoBehaviour {
    public Material bgMaterial = null;
	// Use this for initialization
	void Start () {
        //bgMaterial = GetComponent<Renderer>().material;
        Color c1 = new Color(Random.Range(0f, 1f),Random.Range(0.7f, 0.9f),Random.Range(0f, 1f));
        Color c2 = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0.7f, 0.9f));

        bgMaterial.SetColor("_Color1", c1);
        bgMaterial.SetColor("_Color2", c2);
        bgMaterial.SetFloat("_Weights",2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
    {
        Graphics.Blit(sourceTexture, destTexture, bgMaterial);

    }
}
