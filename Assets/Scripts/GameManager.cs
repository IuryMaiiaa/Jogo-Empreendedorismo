using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static string PLANTA = "PLANTA";
    public static string MELECA = "MELECA";
    public static string NENHUM = "NENHUM";
    public string recursoAtual;

    public static string COLOCAR = "COLOCAR";
    public static string UPGRADE = "UPGRADE";
    public static string REMOVER = "REMOVER";
    public string acaoAtual;


	// Use this for initialization
	void Start () {
        recursoAtual = NENHUM;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void mudarRecurso(int id)
    {
        if(id == 1)
        {
            recursoAtual = MELECA;
        } else if(id == 2)
        {
            recursoAtual = PLANTA;
        }
    }

    public void mudarAcao(int id)
    {
        if(id == 1)
        {
            acaoAtual = COLOCAR;
        } else if(id == 2)
        {
            acaoAtual = UPGRADE;
        } else
        {
            acaoAtual = REMOVER;
        }

    }
}
