using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

public class Producao : SaveInterface
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

    public void produziRecurso(NacaoArmazem armazem)
    {
        int quantidadeRecurso = armazem.getQuantidadeRecurso(recurso);
        quantidadeRecurso += producao;
        armazem.setQuantidadeRecurso(recurso, quantidadeRecurso);
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

    public void load()
    {
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
        if (File.Exists(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + nascaoNome + "ProducaoNascaoData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + nascaoNome + "ProducaoNascaoData.dat", FileMode.Open);

            ProducaoNascaoData producaoNascaoData = (ProducaoNascaoData)bf.Deserialize(file);
            file.Close();
            this.setNascaoNome(producaoNascaoData.nascaoNome);
            this.setProducao(producaoNascaoData.producao);
            this.setRecurso(producaoNascaoData.recurso);
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
