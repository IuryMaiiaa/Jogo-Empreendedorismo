using UnityEngine;
using System.Collections;

public class NacaoComercioGerente : MonoBehaviour {
    public int melecaPreco;
    public int couroPreco;
    public int plantaPreco;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getPlantaPreco()
    {
        return this.plantaPreco;
    }

    public int getCouroPreco()
    {
        return this.couroPreco;
    }

    public int getMelecaPreco()
    {
        return this.melecaPreco;
    }
}
