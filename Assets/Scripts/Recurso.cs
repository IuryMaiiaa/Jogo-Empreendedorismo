﻿using UnityEngine;

public class Recurso : MonoBehaviour {
    private GerenciadorRecursos gerenciadorRecurso;
    public SpriteRenderer recursoSprite;
    public int tempoDecorrido;
    public double tempoAtual;
    public int lv;
    public string recurso;
 
	// Use this for initialization
	void Start () {
        tempoAtual = Time.time;
        tempoDecorrido = 0;
        gerenciadorRecurso = GameObject.FindObjectOfType<GerenciadorRecursos>();
    }
	
	// Update is called once per frame
	void Update () {
	    if( recurso != "NENHUM")
        {
            if(Time.time > tempoAtual+1f)
            {
                tempoDecorrido++;
                tempoAtual = Time.time;
                if (tempoDecorrido == 60)
                {
                    upgrade();
                } else if(tempoDecorrido == 120)
                {
                    upgrade();
                }
            }
        }
	}

    public void colherRecurso()
    {
        if(recurso == "PLANTA")
        {
            colherPlanta();
        } else if(recurso == "MELECA")
        {
            colherSparkunglax();
        } else if(recurso == "COURO")
        {
            colherCebolinha();
        }
        remover();
        
    }

    private void colherSparkunglax()
    {
        if(lv==1)
        {
            GameObject.FindObjectOfType<ArmazemGerenciamento>().melecaAdicionar(5);
        } else if(lv==2)
        {
            GameObject.FindObjectOfType<ArmazemGerenciamento>().melecaAdicionar(10);
        } else  if (lv==3)
        { 
            GameObject.FindObjectOfType<ArmazemGerenciamento>().melecaAdicionar(15);

        } 
    }

    private void colherCebolinha()
    {
        if (lv == 1)
        {
            GameObject.FindObjectOfType<ArmazemGerenciamento>().couroAdicionar(5);
        }
        else if (lv == 2)
        {
            GameObject.FindObjectOfType<ArmazemGerenciamento>().couroAdicionar(10);
        }
        else if (lv == 3)
        {
            GameObject.FindObjectOfType<ArmazemGerenciamento>().couroAdicionar(15);
        }
    }

    private void colherPlanta()
    {
        if (lv == 1)
        {
            GameObject.FindObjectOfType<ArmazemGerenciamento>().plantAdicionar(5);
        }
        else if (lv == 2)
        {
            GameObject.FindObjectOfType<ArmazemGerenciamento>().plantAdicionar(10);
        }
        else if (lv == 3)
        {
            GameObject.FindObjectOfType<ArmazemGerenciamento>().plantAdicionar(15);
        }
    }


    public void setTempoDecorrido(int tempo)
    {
        tempoDecorrido = tempo;
    }

    public double getTempoDecorrido()
    {
        return tempoDecorrido;
    }

    private double getTempoDecoridoMinutos()
    {
        return tempoDecorrido / 60;
    }

    public void setRecurso(string recursoNovo,int lvNovo)
    {
        lv = lvNovo;
        recurso = recursoNovo;
        recursoSprite.sprite = GameObject.FindObjectOfType<GerenciadorRecursos>().GetRecursoSprite(this.recurso, lv);
    }

    public void colocar(string recurso)
    {
        lv = 1;
        this.recurso = recurso;
        recursoSprite.sprite = gerenciadorRecurso.GetRecursoSprite(this.recurso,lv);
    }

    public void upgrade()
    {
        if(recurso!=null && lv<3)
        {
            lv++;
            recursoSprite.sprite = gerenciadorRecurso.GetRecursoSprite(this.recurso, lv);
        }
    }

    public void remover()
    {
        tempoDecorrido = 0;
        recurso = "NENHUM";
        lv = 1;
        recursoSprite.sprite = null;
    }


}
