using UnityEngine;
using System.Collections;
using System;

public class LoadGameBotaoScript : MonoBehaviour, InterfaceBotao {

    public Transform NavePosicao;
    public GameObject loadPanelSlots;

    public void botaoAcao()
    {
        GameObject.FindObjectOfType<MenuGerenciamento>().ativarPanel(loadPanelSlots);
    }

    public Transform getPosicaoNave()
    {
        return NavePosicao;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
