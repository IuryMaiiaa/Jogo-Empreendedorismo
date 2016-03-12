using UnityEngine;
using System.Collections;

public class ArmazemGerenciamento : MonoBehaviour {
    public int recursoPlantaArmazenado;
    public int recursoMelecaArmazenado;
    public int recursoCouroArmazenado;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void plantAdicionar(int valor)
    {
        recursoPlantaArmazenado += valor;
    }

    public void melecaAdicionar(int valor)
    {
        recursoMelecaArmazenado += valor;
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

    }

    public void load()
    {

    }

}

[System.Serializable]
class ArmazenamentoData
{

    public int recursoPlantaArmazenado;
    public int recursoMelecaArmazenado;
    public int recursoCouroArmazenado;
}
