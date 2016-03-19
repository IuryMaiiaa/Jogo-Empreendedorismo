using UnityEngine;
using System.Collections;

public class NacaoFactory : MonoBehaviour,SaveInterface {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Nacao[] criarNacoes()
    {
        Nacao[] nacoes = new Nacao[5];
        return nacoes;
    }

    public void save()
    {
        
    }

    public void load()
    {

    }
}
