using UnityEngine;
using System.Collections;
using System;

public class SairJogoBotaoMenuPrincipal : MonoBehaviour,InterfaceBotao {

    public Transform posicaoNave;

    public void botaoAcao()
    {
        GameObject.FindObjectOfType<GameManager>().saveGame();
        Application.LoadLevel(0);
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
