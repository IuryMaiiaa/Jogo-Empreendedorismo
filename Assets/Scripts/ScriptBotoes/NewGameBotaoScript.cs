using UnityEngine;
using System.Collections;
using System;

public class NewGameBotaoScript : MonoBehaviour,InterfaceBotao {
    public Transform NavePosicao;
    public GameObject saveSlotPanel;

    public void botaoAcao()
    {
        GameObject.FindObjectOfType<MenuGerenciamento>().ativarPanel(saveSlotPanel);
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
