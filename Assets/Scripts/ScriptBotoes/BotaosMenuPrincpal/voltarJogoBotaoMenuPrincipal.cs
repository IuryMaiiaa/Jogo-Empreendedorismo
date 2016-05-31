using UnityEngine;
using System.Collections;
using System;

public class voltarJogoBotaoMenuPrincipal : MonoBehaviour,InterfaceBotao {
    public Transform posicaoNave;


    public void botaoAcao()
    {
        GameObject.FindObjectOfType<ControladorMenu>().fecharMenus();
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
