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
    public RecursoEnum recursoEnum;
    public NacaoComercioGerente nacaoComercioGerente;
    public string nascaoNome;
    public int melecaPreco;
    public int couroPreco;
    public int plantaPreco;

	// Use this for initialization
	void Start () {
        recursoEnum = new RecursoEnum();
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
        data.plantaPreco = this.plantaPreco;
        data.couroPreco = this.couroPreco;
        data.melecaPreco = this.melecaPreco;
        bf.Serialize(file, data);
        file.Close();
        producao.save();
        consumo.save();
        objetivo.save();
        armazem.save();
    }

    public void load()
    {
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
        if (File.Exists(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + nascaoNome + "NascaoData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + nascaoNome + "NascaoData.dat", FileMode.Open);

            NascaoData nascaoData = (NascaoData)bf.Deserialize(file);
            file.Close();
            this.setNascaoName(nascaoData.nascaoNome);
            this.setCouroPreco(nascaoData.couroPreco);
            this.setPlantaPreco(nascaoData.plantaPreco);
            this.setMelecaPreco(nascaoData.melecaPreco);
            setNacaoNoObjetivos();
            producao.load();
            consumo.load();
            objetivo.load();
            armazem.load();
        }        
    }

    private void setNacaoNoObjetivos()
    {
        producao.setNascaoNome(nascaoNome);
        consumo.setNascaoNome(nascaoNome);
        objetivo.setNascaoNome(nascaoNome);
        armazem.setNascaoNome(nascaoNome);
    }

    public void realizarComercio(ArrayList nacoes)
    {
        
    }

    public void comprarRecursoObjetivo(ArrayList nacoes)
    {
        Nacao nascaoMenorPreco = new Nacao();
        foreach(Nacao nacao in nacoes)
        {
            
        }
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

    public int getPrecoRecurso(String recurso)
    {
        if(recurso.Equals(recursoEnum.getPlantaRecursoString()))
        {
            return getPlantaPreco();
        } else if(recurso.Equals(recursoEnum.getMelecarRecursoString()))
        {
            return getMelecaPreco();
        } else if (recurso.Equals(recursoEnum.getCouroRecursoString()))
        {
            return getCouroPreco();
        }
        return Int32.MaxValue;
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

    public void setCouroPreco(int valorPadrao)
    {
        this.couroPreco = alterarPrecoRecurso(recursoEnum.getCouroRecursoString(), valorPadrao);
    }

    public void setPlantaPreco(int valorPadrao)
    {
        this.plantaPreco = alterarPrecoRecurso(recursoEnum.getPlantaRecursoString(),valorPadrao);
    }

    public void setMelecaPreco(int valorPadrao)
    {
        this.melecaPreco = alterarPrecoRecurso(recursoEnum.getMelecarRecursoString(), valorPadrao);
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

    public int alterarPrecoRecurso(string recurso,int valor)
    {
        if(recurso.Equals(objetivo.getRecurso()))
        {
            valor += 100;
        }
        if (recurso.Equals(consumo.getRecurso()))
        {
            valor += 50;
        }
        if(recurso.Equals(producao.getRecurso()))
        {
            valor -= 100;
        }
        return valor;
    }
}

[System.Serializable]
class NascaoData
{
    public string nascaoNome;
    public int melecaPreco;
    public int couroPreco;
    public int plantaPreco;
}
