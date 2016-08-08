using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

public class GerenciadorNaveStatus : MonoBehaviour, SaveInterface {

    public UnityEngine.UI.Image geradorAwesomeImage;
    public UnityEngine.UI.Image turbina;
    public UnityEngine.UI.Image silverTape;
    public UnityEngine.UI.Image controleNave;
    public UnityEngine.UI.Image botaoGravidade;

    public bool geradorComprado;
    public bool turbinaComprada;
    public bool silverTapeComprada;
    public bool controleNaveComprado;
    public bool botaoGravidadeComprado;

    public SpriteRenderer geradorAwesomeCompleto;
    public SpriteRenderer turbinaCompleta;
    public SpriteRenderer silverTapeCompleta;
    public SpriteRenderer controleNaveCompleto;
    public SpriteRenderer botaoGravidadeCompleto;

    public SaveAtual saveAtual;
    public ArmazemGerenciamento armazemGerenciamento;

    public GameObject botaoEndGame;

    // Use this for initialization
    void Start () {
        botaoEndGame.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	   if(geradorComprado && turbinaComprada && silverTapeComprada && controleNaveComprado && botaoGravidadeComprado)
        {
            botaoEndGame.SetActive(true);
        }
	}

    public void setImagemPecas()
    {
        if(geradorComprado)
        {
            geradorAwesomeImage.sprite = geradorAwesomeCompleto.sprite;
            geradorAwesomeImage.color = new Vector4(255,255,255,255);
        }
        if (turbinaComprada)
        {
            turbina.sprite = turbinaCompleta.sprite;
            turbina.color = new Vector4(255, 255, 255, 255);
        }
        if (silverTapeComprada)
        {
            silverTape.sprite = silverTapeCompleta.sprite;
            silverTape.color = new Vector4(255, 255, 255, 255);
        }
        if (controleNaveComprado)
        {
            controleNave.sprite = controleNaveCompleto.sprite;
            controleNave.color = new Vector4(255, 255, 255, 255);
        }
        if (botaoGravidadeComprado)
        {
            botaoGravidade.sprite = botaoGravidadeCompleto.sprite;
            botaoGravidade.color = new Vector4(255, 255, 255, 255);
        }
    }


    public void save()
    {
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + "NavePecasData.dat");
        NavePecasData navePecasData = new NavePecasData();

        navePecasData.botaoGravidadeComprado = this.botaoGravidadeComprado;
        navePecasData.controleNaveComprado = this.controleNaveComprado;
        navePecasData.geradorComprado = this.geradorComprado;
        navePecasData.silverTapeComprada = this.silverTapeComprada;
        navePecasData.turbinaComprada = this.turbinaComprada;

        bf.Serialize(file, navePecasData);
        file.Close();
        setImagemPecas();
    }

    public void load()
    {
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
        if (File.Exists(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + "NavePecasData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + "NavePecasData.dat", FileMode.Open);
            NavePecasData navePecasData = new NavePecasData();

            navePecasData = (NavePecasData)bf.Deserialize(file);
            file.Close();
            this.botaoGravidadeComprado = navePecasData.botaoGravidadeComprado;
            this.controleNaveComprado = navePecasData.controleNaveComprado;
            this.geradorComprado = navePecasData.geradorComprado;
            this.silverTapeComprada = navePecasData.silverTapeComprada;
            this.turbinaComprada = navePecasData.turbinaComprada;
            setImagemPecas();
        }
    }

    public void iniciarNaveStatus()
    {
        geradorComprado = false;
        turbinaComprada = false;
        silverTapeComprada = false;
        controleNaveComprado = false;
        botaoGravidadeComprado = false;
        save();
    }

    public void loadNaveStatus()
    {
        load();
    }

    public void comprarGerador()
    {
        if (armazemGerenciamento.dinheiro >= 5000)
        {
            armazemGerenciamento.dinheiro -= 5000;
            geradorComprado = true;
            setImagemPecas();
        }
    }

    public void comprarTurbina()
    {
        if(armazemGerenciamento.dinheiro >= 5000)
        {
            armazemGerenciamento.dinheiro -= 5000;
            turbinaComprada = true;
            setImagemPecas();
        }
    }

    public void comprarSilverTape()
    {
        if (armazemGerenciamento.dinheiro >= 5000)
        {
            armazemGerenciamento.dinheiro -= 5000;
            silverTapeComprada = true;
            setImagemPecas();
        }
    }

    public void comprarControleNave()
    {
        if (armazemGerenciamento.dinheiro >= 5000)
        {
            armazemGerenciamento.dinheiro -= 5000;
            controleNaveComprado = true;
            setImagemPecas();
        }
    }

    public void comprarBotaoGravidade()
    {
        if (armazemGerenciamento.dinheiro >= 5000)
        {
            armazemGerenciamento.dinheiro -= 5000;
            botaoGravidadeComprado = true;
            setImagemPecas();
        }
    }
}

[System.Serializable]
class NavePecasData
{
    public bool geradorComprado;
    public bool turbinaComprada;
    public bool silverTapeComprada;
    public bool controleNaveComprado;
    public bool botaoGravidadeComprado;
}
