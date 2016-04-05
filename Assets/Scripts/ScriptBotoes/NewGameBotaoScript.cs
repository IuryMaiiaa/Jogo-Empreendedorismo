using UnityEngine;
using System.Collections;
using System;

public class NewGameBotaoScript : MonoBehaviour,InterfaceBotao {
    public Transform NavePosicao;

    public void botaoAcao()
    {
        Debug.Log("aqui");
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
