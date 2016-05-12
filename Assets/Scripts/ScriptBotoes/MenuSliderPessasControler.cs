using UnityEngine;
using System.Collections;

public class MenuSliderPessasControler : MonoBehaviour {
    public Animator sliderAnimacao;

	// Use this for initialization
	void Start () {
        sliderAnimacao.SetBool("BotaoPrecionado",false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
