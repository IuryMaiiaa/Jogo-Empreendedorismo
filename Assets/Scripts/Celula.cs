using UnityEngine;
using System.Collections;

public class Celula : MonoBehaviour {
    public Transform largura;
    public Transform altura;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public float GetLargura() {
        return largura.position.x - this.transform.position.x;
    }

    public float GetAltura() {
        return altura.position.y - this.transform.position.y;
    }
}
