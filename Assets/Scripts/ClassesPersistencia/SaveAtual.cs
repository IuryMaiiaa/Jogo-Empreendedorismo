using UnityEngine;
using System.Collections;

public class SaveAtual : MonoBehaviour {
    public string saveAtual;
    public string saveAtualId;

    public string gameStartType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public string getGameStartType()
    {
        return gameStartType;
    }

    public void setGameStartType(string gameStartType)
    {
        this.gameStartType = gameStartType;
    }

    public void setSaveAtualId(string saveId)
    {
        saveAtualId = saveId;
    }

    public string getSaveAtualId()
    {
        return saveAtualId;
    }

    public void setSave(string newSave)
    {
        saveAtual = newSave;
    }

    public string getSave()
    {
        return saveAtual;
    }

    public void dontDestroy()
    {
        Object.DontDestroyOnLoad(this);
    }

    public void iniciarEstoque()
    {
        if (gameStartType == "new")
        {
            GameObject.FindObjectOfType<ArmazemGerenciamento>().criarEstoque();
        }
        else if (gameStartType == "load")
        {
            GameObject.FindObjectOfType<ArmazemGerenciamento>().loadEstoque();
        }
    }

    public void iniciarCriacaoMapas()
    {
        if(gameStartType == "new")
        {
            GameObject.FindObjectOfType<GerenciadorDeMapas>().criarMapas();
        } else if(gameStartType == "load")
        {
            GameObject.FindObjectOfType<GerenciadorDeMapas>().criarMapasLoad();
        }
        
    }

    public void iniciarNaveStatus()
    {
        if (gameStartType == "new")
        {
            GameObject.FindObjectOfType<GerenciadorNaveStatus>().iniciarNaveStatus();
        }
        else if (gameStartType == "load")
        {
            GameObject.FindObjectOfType<GerenciadorNaveStatus>().loadNaveStatus();
        }
    }

    public void iniciarCriacaoNacoes()
    {
        if (gameStartType == "new")
        {
            GameObject.FindObjectOfType<GerenciadoDeNacoes>().criarNascoes();
        }
        else if (gameStartType == "load")
        {
            GameObject.FindObjectOfType<GerenciadoDeNacoes>().criarNascoesLoad();
        }
    }

    public void iniciarGerenciadorEventos()
    {
        if(gameStartType == "new")
        {
            GameObject.FindObjectOfType<GerenciadoDeEventos>().iniciarEventos();
        } else if(gameStartType == "load")
        {
            GameObject.FindObjectOfType<GerenciadoDeEventos>().loadEventos();
        }
    }
}
