﻿using UnityEngine;
using System.Collections;

public class CelulaColider : MonoBehaviour {
    public Touch touch;
    public Ray ray;
    public bool apertarBotao;
    public int cont;
    private GameManager gameManager;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        cont = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
        
    }

    public void intencao(RaycastHit hit)
    {
        if (cont > 2)
        {
            cont = 0;
            if (gameManager.acaoAtual == "COLOCAR")
            {
                hit.collider.gameObject.GetComponent<Recurso>().colocar(gameManager.recursoAtual);
            }
            else if (gameManager.acaoAtual == "UPGRADE")
            {
                hit.collider.gameObject.GetComponent<Recurso>().upgrade();
            }
            else if (gameManager.acaoAtual == "REMOVER")
            {
                hit.collider.gameObject.GetComponent<Recurso>().remover();
            } else if (this.gameObject.GetComponent<Recurso>().recurso.Equals("") ||
                       this.gameObject.GetComponent<Recurso>().recurso.Equals("NENHUM")) 
            {
               
            } else
            {
                ChamarBotao(hit);
            }
        }
        else
        {
            cont++;
        }
        
    }



    public void ChamarBotao(RaycastHit hit)
    {        
        GameObject.FindObjectOfType<MenuControler>().AcinonarMenuOpcoesRecurso(this.gameObject);
        GameObject.FindObjectOfType<ScriptColetaRecurso>().adicionarRecurso(this.gameObject.GetComponent<Recurso>());
    }
}
