using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

public class Nacao : MonoBehaviour,SaveInterface {
    public Objetivo objetivo;
    public Consumo consumo;
    public Producao producao;
    public NacaoArmazem armazem;
    public SaveAtual saveAtual;
    public string nascaoNome;

	// Use this for initialization
	void Start () {
        objetivo = new Objetivo();
        consumo = new Consumo();
        producao = new Producao();
        armazem = new NacaoArmazem();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void save()
    {
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + nascaoNome + "NascaoData.dat");
        NascaoData data = new NascaoData();

        data.nascaoNome = this.nascaoNome;

        bf.Serialize(file, data);
        file.Close();
        producao.save();
        consumo.save();
        objetivo.save();
        armazem.save();
    }

    public void load()
    {
        producao.load();
    }

    private void setNacaoNoObjetivos()
    {
        producao.setNascaoNome(nascaoNome);
        consumo.setNascaoNome(nascaoNome);
        objetivo.setNascaoNome(nascaoNome);
        armazem.setNascaoNome(nascaoNome);
    }

    public string getNascaoName()
    {
        return nascaoNome;
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

    public void setNascaoName(string nascaoNome)
    {
        this.nascaoNome = nascaoNome;
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

[System.Serializable]
class NascaoData
{
    public string nascaoNome;
}
