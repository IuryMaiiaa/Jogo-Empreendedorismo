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

    public void abrirSlider()
    {
        if(sliderAnimacao.GetBool("BotaoPrecionado")==false)
        {
            sliderAnimacao.SetBool("BotaoPrecionado", true);
        } else if (sliderAnimacao.GetBool("BotaoPrecionado") == true)
        {
            sliderAnimacao.SetBool("BotaoPrecionado", false);
        }
        
    }
}
