﻿using UnityEngine;
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
    public string posicao;

    
	// Use this for initialization
	void Start () {
        recursoEnum = new RecursoEnum();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public Nacao getNacao()
    {
        return this;
    }

    public void GerarProducaoConsumo()
    {
        realizarConsumo();
        produziRecurso();
    }

    public void realizarConsumo()
    {
        consumo.realizarConsumo(armazem);
    }

    public void produziRecurso()
    {
        producao.produziRecurso(armazem);
    }

    public void save()
    {
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + nascaoNome + "NascaoData.dat");
        NascaoData data = new NascaoData();
        setNacaoNoObjetivos();
        data.nascaoNome = this.nascaoNome;
        data.plantaPreco = nacaoComercioGerente.getPlantaPreco();
        data.couroPreco = nacaoComercioGerente.getCouroPreco();
        data.melecaPreco = nacaoComercioGerente.getMelecaPreco();
        data.posicao = this.posicao;
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
            nacaoComercioGerente = new NacaoComercioGerente();
            producao = new Producao();
            consumo = new Consumo();
            objetivo = new Objetivo();
            armazem = new NacaoArmazem();
            recursoEnum = new RecursoEnum();
            this.setNascaoName(nascaoData.nascaoNome);
            this.setCouroPreco(nascaoData.couroPreco);
            this.setPlantaPreco(nascaoData.plantaPreco);
            this.setMelecaPreco(nascaoData.melecaPreco);
            this.posicao = nascaoData.posicao;
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
        comprarRecursoObjetivo(nacoes);
        comprarRecursoConsumo(nacoes);
    }

    public void comprarRecursoConsumo(ArrayList nacoes)
    {
        if(armazem.getQuantidadeRecurso(consumo.recurso) < consumo.getConsumoPeriodico())
        {
            int valorMenorPreco = Int32.MaxValue;
            Nacao nacaoMenorPreco = null;
            foreach (Nacao nacao in nacoes)
            {
                if (nacao != null && nacao.getArmazem().getQuantidadeRecurso(objetivo.getRecurso()) > 0)
                {
                    if (nacao.getPrecoRecurso(objetivo.recurso) < valorMenorPreco)
                    {
                        nacaoMenorPreco = nacao;
                        valorMenorPreco = nacao.getPrecoRecurso(objetivo.recurso);
                    }
                }

            }
            if (nacaoMenorPreco != null)
            {
                Debug.Log("A nascao:" + this.nascaoNome + "Compro da nacao :" + nacaoMenorPreco.getNascaoName() + "esse recurso : " + consumo.recurso);
                nacaoMenorPreco.compraRecurso(objetivo.recurso, armazem);
            }
        }
    }

    public void comprarRecursoObjetivo(ArrayList nacoes)
    {
        int valorMenorPreco = Int32.MaxValue;
        Nacao nacaoMenorPreco = null;
        foreach(Nacao nacao in nacoes)
        {
            if(nacao != null && nacao.getArmazem().getQuantidadeRecurso(objetivo.getRecurso())>0)
            {
                if (nacao.getPrecoRecurso(objetivo.recurso) < valorMenorPreco)
                {
                    nacaoMenorPreco = nacao;
                    valorMenorPreco = nacao.getPrecoRecurso(objetivo.recurso);
                }
            }
            
        }
        if(nacaoMenorPreco!=null)
        {
            Debug.Log("A nascao:" + this.nascaoNome + "Compro da nacao :" + nacaoMenorPreco.getNascaoName() + "esse recurso : " + consumo.recurso);
            nacaoMenorPreco.compraRecurso(objetivo.recurso, armazem);
        }
    }

    public void compraRecurso(String recurso,NacaoArmazem armazem)
    {
        if (recurso.Equals(recursoEnum.getPlantaRecursoString()))
        {
            comprarPlantas(armazem);
        }
        else if (recurso.Equals(recursoEnum.getMelecarRecursoString()))
        {
            comprarMelecas(armazem);
        }
        else if (recurso.Equals(recursoEnum.getCouroRecursoString()))
        {
            comprarCouro(armazem);
        }
    }

    public void comprarPlantas(NacaoArmazem armazem)
    {
        int quantidadeDinheiro = armazem.getDinheiro();
        int valorProduto = nacaoComercioGerente.getPlantaPreco()+1;
        int quantidadeProduto = this.getArmazem().getPlantas();
        int quantidadeComprador = armazem.getPlantas();
        int quantidadeMaximaComprada = quantidadeDinheiro / (valorProduto);
        int quantidadeComprada;
        if (quantidadeMaximaComprada < quantidadeProduto)
        {
            quantidadeComprada = quantidadeMaximaComprada;
        }
        else
        {
            quantidadeComprada = quantidadeProduto;
        }
        quantidadeProduto = quantidadeProduto - quantidadeComprada;
        quantidadeComprador = quantidadeComprador + quantidadeComprada;
        quantidadeDinheiro = quantidadeDinheiro-(quantidadeComprada * valorProduto);
        armazem.setDinheiro(quantidadeDinheiro);
        Debug.Log("status da compra, valor do produto:"+ valorProduto + " quantidade do comprador: " + quantidadeComprador +
                  " quantidade comprada: " + quantidadeComprada + " quantidade de dinheiro comprador: " + this.armazem.getDinheiro() +
                  " quantidadeMaximaComprada " + quantidadeMaximaComprada);
        this.armazem.setDinheiro((quantidadeComprada * valorProduto)+this.getArmazem().getDinheiro());
        armazem.setRecursoPlanta(armazem.getPlantas() + quantidadeComprada);
        this.getArmazem().setRecursoPlanta(this.getArmazem().getPlantas() - quantidadeComprada);
    }

    public void comprarMelecas(NacaoArmazem armazem)
    {
        int quantidadeDinheiro = armazem.getDinheiro();
        int valorProduto = nacaoComercioGerente.getMelecaPreco() + 1;
        int quantidadeProduto = this.getArmazem().getMeleca();
        int quantidadeComprador = armazem.getMeleca();
        int quantidadeMaximaComprada = quantidadeDinheiro / (valorProduto);
        int quantidadeComprada;
        if (quantidadeMaximaComprada < quantidadeProduto)
        {
            quantidadeComprada = quantidadeMaximaComprada;
        }
        else
        {
            quantidadeComprada = quantidadeProduto;
        }
        quantidadeProduto = quantidadeProduto - quantidadeComprada;
        quantidadeComprador = quantidadeComprador + quantidadeComprada;
        quantidadeDinheiro = quantidadeDinheiro - (quantidadeComprada * valorProduto);
        armazem.setDinheiro(quantidadeDinheiro);
        Debug.Log("status da compra, valor do produto:" + valorProduto + " quantidade do comprador: " + quantidadeComprador +
                  " quantidade comprada: " + quantidadeComprada + " quantidade de dinheiro comprador: " + this.armazem.getDinheiro() +
                  " quantidadeMaximaComprada " + quantidadeMaximaComprada);
        this.armazem.setDinheiro((quantidadeComprada * valorProduto) + this.getArmazem().getDinheiro());
        armazem.setRecursoMeleca(armazem.getMeleca() + quantidadeComprada);
        this.getArmazem().setRecursoMeleca(this.getArmazem().getMeleca() - quantidadeComprada);
    }

    public void comprarCouro(NacaoArmazem armazem)
    {
        int quantidadeDinheiro = armazem.getDinheiro();
        int valorProduto = nacaoComercioGerente.getCouroPreco()+1;
        int quantidadeProduto = this.getArmazem().getCouro();
        int quantidadeComprador = armazem.getCouro();
        int quantidadeMaximaComprada = quantidadeDinheiro / (valorProduto);
        int quantidadeComprada;
        if (quantidadeMaximaComprada < quantidadeProduto)
        {
            quantidadeComprada = quantidadeMaximaComprada;
        }
        else
        {
            quantidadeComprada = quantidadeProduto;
        }
        quantidadeProduto = quantidadeProduto - quantidadeComprada;
        quantidadeComprador = quantidadeComprador + quantidadeComprada;
        quantidadeDinheiro = quantidadeDinheiro - (quantidadeComprada * valorProduto);
        armazem.setDinheiro(quantidadeDinheiro);
        Debug.Log("status da compra, valor do produto:" + valorProduto + " quantidade do comprador: " + quantidadeComprador +
                  " quantidade comprada: " + quantidadeComprada + " quantidade de dinheiro comprador: " + this.armazem.getDinheiro() +
                  " quantidadeMaximaComprada " + quantidadeMaximaComprada);
        this.armazem.setDinheiro((quantidadeComprada * valorProduto) + this.getArmazem().getDinheiro());
        armazem.setRecursoCouro(armazem.getCouro() + quantidadeComprada);
        this.getArmazem().setRecursoCouro(this.getArmazem().getCouro() - quantidadeComprada);
    }

    public int getPlantaPreco()
    {
        return nacaoComercioGerente.getPlantaPreco();
    }

    public int getCouroPreco()
    {
        return nacaoComercioGerente.getCouroPreco();
    }

    public int getMelecaPreco()
    {
        return nacaoComercioGerente.getMelecaPreco();
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
        Debug.Log(recurso);
        return Int32.MaxValue;
    }

    public void setPrecoRecurso(String recurso,int valor)
    {
        if (recurso.Equals(recursoEnum.getPlantaRecursoString()))
        {
            nacaoComercioGerente.setPlantaPreco(valor);
        }
        else if (recurso.Equals(recursoEnum.getMelecarRecursoString()))
        {
            nacaoComercioGerente.setMelecaPreco(valor);
        }
        else if (recurso.Equals(recursoEnum.getCouroRecursoString()))
        {
            nacaoComercioGerente.setCouroPreco(valor);
        }

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
        recursoEnum = new RecursoEnum();
        nacaoComercioGerente.setCouroPreco(alterarPrecoRecurso(recursoEnum.getCouroRecursoString(), valorPadrao));
    }

    public void setPlantaPreco(int valorPadrao)
    {
        recursoEnum = new RecursoEnum();
        nacaoComercioGerente.setPlantaPreco(alterarPrecoRecurso(recursoEnum.getPlantaRecursoString(),valorPadrao));
    }

    public void setMelecaPreco(int valorPadrao)
    {
        recursoEnum = new RecursoEnum();
        nacaoComercioGerente.setMelecaPreco(alterarPrecoRecurso(recursoEnum.getMelecarRecursoString(), valorPadrao));
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
        if(valor<=0)
        {
            valor = 10;
        }
        return valor;
    }
}

[System.Serializable]
class NascaoData
{
    public string posicao;
    public string nascaoNome;
    public int melecaPreco;
    public int couroPreco;
    public int plantaPreco;
}