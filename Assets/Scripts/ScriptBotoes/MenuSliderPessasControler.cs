using UnityEngine;
using System.Collections;

public class MenuSliderPessasControler : MonoBehaviour {
    public Animator sliderAnimacao;
    public GameObject objetosNave;

	// Use this for initialization
	void Start () {
        objetosNave.SetActive(false);
        sliderAnimacao.SetBool("BotaoPrecionado",false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void abrirSlider()
    {
        if(sliderAnimacao.GetBool("BotaoPrecionado")==false)
        {
            objetosNave.SetActive(true);
            sliderAnimacao.SetBool("BotaoPrecionado", true);
        } else if (sliderAnimacao.GetBool("BotaoPrecionado") == true)
        {
            objetosNave.SetActive(false);
            sliderAnimacao.SetBool("BotaoPrecionado", false);
        }
        
    }
}
