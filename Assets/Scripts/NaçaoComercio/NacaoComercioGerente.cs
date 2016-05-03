using UnityEngine;
using System.Collections;
using System;

public class NacaoComercioGerente : SaveInterface {
    public int melecaPreco;
    public int couroPreco;
    public int plantaPreco;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
        throw new NotImplementedException();
    }
}
