using UnityEngine;
using System.Collections;

public class Nacao : MonoBehaviour {
    public Objetivo objetivo;
    public Consumo consumo;
    public Producao producao;
    public NacaoArmazem armazem;
    public string name;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public string getNascaoName()
    {
        return name;
    }

    public Objetivo getObjetivo()
    {
        return objetivo;
    }

    public Consumo getConsumo()
    {
        return consumo;
    }

    public Producao getProducao()
    {
        return producao;
    }

    public NacaoArmazem getArmazem()
    {
        return armazem;
    }

    public void setObjetivo(Objetivo objetivo)
    {
        this.objetivo = objetivo;
    }

    public void setNascaoName(string name)
    {
        this.name = name;
    }

    public void setConsumo(Consumo consumo)
    {
        this.consumo = consumo;
    }

    public void setProducao(Producao producao)
    {
        this.producao = producao;
    }

    public void setArmazem(NacaoArmazem armazem)
    {
        this.armazem = armazem;
    }
}
