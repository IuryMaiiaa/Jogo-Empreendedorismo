using UnityEngine;
using System.Collections;
using System;

public class ExitBotaoScript : MonoBehaviour, InterfaceBotao {

    public Transform NavePosicao;

    public void botaoAcao()
    {
        Application.Quit();
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
