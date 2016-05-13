using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

public class NacaoArmazem : SaveInterface {
    private int recursoPlanta;
    private int recursoMeleca;
    private int recursoCouro;
    private string nascaoNome;
    private int dinheiro;
    private RecursoEnum recursoEnum;
    private SaveAtual saveAtual;
    private int maximoSuportado = 2000;
    
    public NacaoArmazem()
    {
        recursoEnum = new RecursoEnum();
    }

    public void setQuantidadeRecurso(String recurso, int valor)
    {
        if(valor> maximoSuportado)
        {
            valor = maximoSuportado;
        }
        recursoEnum = new RecursoEnum();
        if (recurso.Equals(recursoEnum.getPlantaRecursoString()))
        {
            recursoPlanta = valor;
        }
        else if (recurso.Equals(recursoEnum.getMelecarRecursoString()))
        {
            recursoMeleca = valor;
        }
        else if (recurso.Equals(recursoEnum.getCouroRecursoString()))
        {
            recursoCouro = valor;
        }
    }

    public int getQuantidadeRecurso(String recurso)
    {
        recursoEnum = new RecursoEnum();
        if (recurso.Equals(recursoEnum.getPlantaRecursoString()))
        {
            return recursoPlanta;
        } else if (recurso.Equals(recursoEnum.getMelecarRecursoString()))
        {
            return recursoMeleca;
        } else if(recurso.Equals(recursoEnum.getCouroRecursoString()))
        {
            return recursoCouro;
        }
        return 0;
    }

    public string getNascaoNome()
    {
        return nascaoNome;
    }

    public void setNascaoNome(string nascaoNome)
    {
        this.nascaoNome = nascaoNome;
    }

    public void setRecursoPlanta(int quanidade)
    {
        if (quanidade > maximoSuportado)
        {
            quanidade = maximoSuportado;
        }
        this.recursoPlanta = quanidade;
    }

    public void setRecursoMeleca(int quanidade)
    {
        if (quanidade > maximoSuportado)
        {
            quanidade = maximoSuportado;
        }
        this.recursoMeleca = quanidade;
    }

    public void setRecursoCouro(int quanidade)
    {
        if (quanidade > maximoSuportado)
        {
            quanidade = maximoSuportado;
        }
        this.recursoCouro = quanidade;
    }

    public void setDinheiro(int quanidade)
    {
        this.dinheiro = quanidade;
    }

    public int getPlantas()
    {
        return recursoPlanta;
    }

    public int getMeleca()
    {
        return recursoMeleca;
    }

    public int getCouro()
    {
        return recursoCouro;
    }

    public int getDinheiro()
    {
        return dinheiro;
    }

    public void save()
    {
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + nascaoNome + "ArmazemNascaoData.dat");
        ArmazemNascaoData data = new ArmazemNascaoData();

        data.nascaoNome = this.getNascaoNome();
        data.dinheiro = this.getDinheiro();
        data.recursoCouro = this.getCouro();
        data.recursoMeleca = this.getMeleca();
        data.recursoPlanta = this.getPlantas();

        bf.Serialize(file, data);
        file.Close();
    }

    public void load()
    {
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
        if (File.Exists(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + nascaoNome + "ArmazemNascaoData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + nascaoNome + "ArmazemNascaoData.dat", FileMode.Open);
            ArmazemNascaoData armazemNascaoData = (ArmazemNascaoData)bf.Deserialize(file);

            this.setDinheiro(armazemNascaoData.dinheiro);
            this.setNascaoNome(armazemNascaoData.nascaoNome);
            this.setRecursoCouro(armazemNascaoData.recursoCouro);
            this.setRecursoMeleca(armazemNascaoData.recursoMeleca);
            this.setRecursoPlanta(armazemNascaoData.recursoPlanta);
        }
    }
}

[System.Serializable]
class ArmazemNascaoData
{
    public int recursoPlanta;
    public int recursoMeleca;
    public int recursoCouro;
    public string nascaoNome;
    public int dinheiro;

}
