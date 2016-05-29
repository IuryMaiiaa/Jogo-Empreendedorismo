using UnityEngine;
using System.Collections;
using System;

public class scriptMenuBotaoVoltar : MonoBehaviour,InterfaceBotao {
    public Transform posicaoNave;
    public GameObject panelAnterior;


    public void botaoAcao()
    {
        FindObjectOfType<MenuGerenciamento>().ativarPanel(panelAnterior);
    }

    public Transform getPosicaoNave()
    {
        return posicaoNave;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
