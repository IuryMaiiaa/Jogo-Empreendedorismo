using UnityEngine;
using System.Collections;
using System;

public class NacaoComercioGerente : SaveInterface {
    public int melecaPreco;
    public int couroPreco;
    public int plantaPreco;
    public RecursoEnum recursoEnum;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getPrecoRecurso(String recurso)
    {
        recursoEnum = new RecursoEnum();
        if (recurso.Equals(recursoEnum.getPlantaRecursoString()))
        {
            return plantaPreco;
        }
        else if (recurso.Equals(recursoEnum.getMelecarRecursoString()))
        {
            return melecaPreco;
        }
        else if (recurso.Equals(recursoEnum.getCouroRecursoString()))
        {
            return couroPreco;
        }
        return 0;
    }

    public void setPlantaPreco(int valor)
    {
        plantaPreco = valor;
    }

    public void setMelecaPreco(int valor)
    {
        melecaPreco = valor;
    }

    public void setCouroPreco(int valor)
    {
        couroPreco = valor;
    }

    public int getPlantaPreco()
    {
        return this.plantaPreco;
    }

    public int getCouroPreco()
    {
        return this.couroPreco;
    }

    public int getMelecaPreco()
    {
        return this.melecaPreco;
    }

    public void save()
    {
       
    }
}
