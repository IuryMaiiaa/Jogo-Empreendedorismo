using UnityEngine;
using System.Collections;

public class PanelPadraoMenuOpcoes : MonoBehaviour {
    public Transform largura;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public float getLargura() {
        return largura.transform.position.x - this.transform.position.x;
    }
}
