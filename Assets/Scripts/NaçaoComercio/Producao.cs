using UnityEngine;
using System.Collections;

public class Producao : MonoBehaviour {
    public string recurso;
    public int producao;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void setRecurso(string recursoNome)
    {
        this.recurso = recursoNome;
    }

    public void setProducao(int producao)
    {
        this.producao = producao;
    }

    public string getRecurso()
    {
        return recurso;
    }

    public int getProducao()
    {
        return producao;
    }
}
