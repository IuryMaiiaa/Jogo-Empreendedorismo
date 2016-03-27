using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

public class Producao : MonoBehaviour, SaveInterface
{
    public string nascaoNome;
    public string recurso;
    public int producao;
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
        FileStream file = File.Create(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + nascaoNome + "ProducaoNascaoData.dat");
        ProducaoNascaoData data = new ProducaoNascaoData();

        data.nascaoNome = this.nascaoNome;
        data.producao = this.producao;
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

[System.Serializable]
class ProducaoNascaoData
{
    public string nascaoNome;
    public string recurso;
    public int producao;

}
