using UnityEngine;
using System.Collections;
using System;

public class Recurso : MonoBehaviour {
    private GerenciadorRecursos gerenciadorRecurso;
    public SpriteRenderer recursoSprite;
    public int lv;
    public string recurso;

	// Use this for initialization
	void Start () {
        lv = 1;
        recurso = "NENHUM";
        gerenciadorRecurso = GameObject.FindObjectOfType<GerenciadorRecursos>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setRecurso(string recurso,int lv)
    {
        this.lv = lv;
        this.recurso = recurso;
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
        recurso = "NENHUM";
        lv = 1;
        recursoSprite.sprite = null;
    }


}
