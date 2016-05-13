using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

public class ArmazemGerenciamento : MonoBehaviour,SaveInterface {
    public int recursoPlantaArmazenado;
    public int recursoMelecaArmazenado;
    public int recursoCouroArmazenado;
    public int MaximaCapacidade = 2000;

    public SaveAtual saveAtual;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void plantAdicionar(int valor)
    {
        recursoPlantaArmazenado += valor;
        if(recursoPlantaArmazenado>=MaximaCapacidade)
        {
            recursoPlantaArmazenado = MaximaCapacidade;
        }
    }

    public void melecaAdicionar(int valor)
    {
        recursoMelecaArmazenado += valor;
        if(recursoMelecaArmazenado>=MaximaCapacidade)
        {
            recursoMelecaArmazenado = MaximaCapacidade;
        }
    }

    public void couroAdicionar(int valor)
    {
        recursoCouroArmazenado += valor;
    }

    public void plantaRemover(int valor)
    {
        recursoPlantaArmazenado -= valor;
    }

    public void melecaRemover(int valor)
    {
        recursoMelecaArmazenado -= valor;
    }

    public void couroRemover(int valor)
    {
        recursoCouroArmazenado -= valor;
    }

    public void save()
    {
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + "ArmazenamentoData.dat");
        ArmazenamentoData armazenamentoData = new ArmazenamentoData();

        armazenamentoData.recursoPlantaArmazenado = recursoPlantaArmazenado;
        armazenamentoData.recursoMelecaArmazenado = recursoMelecaArmazenado;
        armazenamentoData.recursoCouroArmazenado = recursoCouroArmazenado;
        armazenamentoData.maximaCapacidade = MaximaCapacidade;

        bf.Serialize(file, armazenamentoData);
        file.Close();

    }

    public void criarEstoque()
    {
        save();
    }

    public void loadEstoque()
    {
        load();
    }

    public void load()
    {
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
        if (File.Exists(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + "ArmazenamentoData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + "ArmazenamentoData.dat", FileMode.Open);
            ArmazenamentoData armazenamentoData = new ArmazenamentoData();

            armazenamentoData = (ArmazenamentoData)bf.Deserialize(file);
            file.Close();
            recursoPlantaArmazenado = armazenamentoData.recursoPlantaArmazenado;
            recursoMelecaArmazenado = armazenamentoData.recursoMelecaArmazenado;
            recursoCouroArmazenado = armazenamentoData.recursoCouroArmazenado;
            MaximaCapacidade = armazenamentoData.maximaCapacidade;
        }

    }

}

[System.Serializable]
class ArmazenamentoData
{
    public int maximaCapacidade;
    public int recursoPlantaArmazenado;
    public int recursoMelecaArmazenado;
    public int recursoCouroArmazenado;
}
