using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

public class Consumo : SaveInterface {
    public string recurso;
    public string nascaoNome;
    public int consumoPeriodico;
    public SaveAtual saveAtual;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void realizarConsumo(NacaoArmazem armazem)
    {
        int quantidadeRecurso = armazem.getQuantidadeRecurso(recurso);
        if(quantidadeRecurso >= consumoPeriodico)
        {
            quantidadeRecurso -= consumoPeriodico;
        } else {
            quantidadeRecurso = 0;
        }
        armazem.setQuantidadeRecurso(recurso, quantidadeRecurso);
    }

    public void save()
    {
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + nascaoNome + "ConsumoNascaoData.dat");
        ConsumoNascaoData data = new ConsumoNascaoData();

        data.nascaoNome = this.nascaoNome;
        data.consumoPeriodico = this.consumoPeriodico;
        data.recurso = this.recurso;

        Debug.Log(data.nascaoNome + "" + data.consumoPeriodico +  "" + data.recurso);

        bf.Serialize(file, data);
        file.Close();
    }

    public void load()
    {
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
        if (File.Exists(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + nascaoNome + "ConsumoNascaoData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + nascaoNome + "ConsumoNascaoData.dat", FileMode.Open);

            ConsumoNascaoData consumoNascaoData = (ConsumoNascaoData)bf.Deserialize(file);
            file.Close();
            this.setConsumoPeriodico(consumoNascaoData.consumoPeriodico);
            this.setNascaoNome(consumoNascaoData.nascaoNome);
            this.setRecurso(consumoNascaoData.recurso);
            
        }
    }

    public void setNascaoNome(string nome)
    {
        nascaoNome = nome;
    }

    public string getNascaoNome()
    {
        return nascaoNome;
    }

    public void setRecurso(string recursoNome)
    {
        this.recurso = recursoNome;
    }

    public void setConsumoPeriodico(int consumoPeriodico)
    {
        this.consumoPeriodico = consumoPeriodico;
    }

    public string getRecurso()
    {
        return recurso;
    }

    public int getConsumoPeriodico()
    {
        return consumoPeriodico;
    }
}

[System.Serializable]
class ConsumoNascaoData
{
    public string nascaoNome;
    public string recurso;
    public int consumoPeriodico;

}
