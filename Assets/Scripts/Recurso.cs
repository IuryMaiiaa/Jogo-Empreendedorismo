using UnityEngine;
using System.Collections;

public class Recurso : MonoBehaviour {
    private GerenciadorRecursos gerenciadorRecurso;
    public SpriteRenderer recursoSprite;
    public int lv;
    public string recurso;

	// Use this for initialization
	void Start () {
        lv = 1;
        recurso = null;
        gerenciadorRecurso = GameObject.FindObjectOfType<GerenciadorRecursos>();
	}
	
	// Update is called once per frame
	void Update () {
	
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

    }


}
