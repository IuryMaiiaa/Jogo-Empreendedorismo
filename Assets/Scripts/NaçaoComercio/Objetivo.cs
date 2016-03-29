using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

public class Objetivo : MonoBehaviour, SaveInterface {
    public string nascaoNome;
    public string recurso;
    public int meta;
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
        FileStream file = File.Create(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + nascaoNome + "ObjetivoNascaoData.dat");
        ObjetivoNascaoData data = new ObjetivoNascaoData();

        data.nascaoNome = this.nascaoNome;
        data.meta = this.meta;
        data.recurso = this.recurso;

        bf.Serialize(file, data);
        file.Close();
    }

    public void load()
    {
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
        if (File.Exists(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + nascaoNome + "ObjetivoNascaoData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + nascaoNome + "ObjetivoNascaoData.dat", FileMode.Open);

            ObjetivoNascaoData objetivoNascaoData = (ObjetivoNascaoData)bf.Deserialize(file);
            file.Close();
            this.setNascaoNome(objetivoNascaoData.nascaoNome);
            this.setMeta(objetivoNascaoData.meta);
            this.setRecurso(objetivoNascaoData.recurso);
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

    public void setMeta(int meta)
    {
        this.meta = meta;
    }

    public void setRecurso(string recurso)
    {
        this.recurso = recurso;
    }

    public string getRecurso()
    {
        return recurso;
    }

    public int getMeta()
    {
        return meta;
    }


}


[System.Serializable]
class ObjetivoNascaoData
{
    public string nascaoNome;
    public string recurso;
    public int meta;

}

