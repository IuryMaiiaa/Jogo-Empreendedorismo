using UnityEngine;
using System.Collections;
using System;

public class SaveBotaoMenuPrincipal : MonoBehaviour,InterfaceBotao {
    public Transform referenciaNave;

    public void botaoAcao()
    {
        GameObject.FindObjectOfType<GameManager>().saveGame();
    }

    public Transform getPosicaoNave()
    {
        return referenciaNave;
    }



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
