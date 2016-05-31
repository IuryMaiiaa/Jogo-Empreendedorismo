using UnityEngine;
using System.Collections;
using System;

public class FechaJogoBotaoMenuPrincipal : MonoBehaviour,InterfaceBotao {
    public Transform posicaoNave;


    public void botaoAcao()
    {
        GameObject.FindObjectOfType<GameManager>().saveGame();
        Application.Quit();
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

    void InterfaceBotao.botaoAcao()
    {
        throw new NotImplementedException();
    }
}
