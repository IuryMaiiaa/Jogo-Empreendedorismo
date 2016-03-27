using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

public class Consumo : MonoBehaviour, SaveInterface {
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

    public void save()
    {
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + nascaoNome + "ConsumoNascaoData.dat");
        ConsumoNascaoData data = new ConsumoNascaoData();

        data.nascaoNome = this.nascaoNome;
        data.consumoPeriodico = this.consumoPeriodico;
        data.recurso = this.recurso;

        bf.Serialize(file, data);
        file.Close();
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
