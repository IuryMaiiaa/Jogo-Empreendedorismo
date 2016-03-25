using UnityEngine;
using System.Collections;

public class GerenciadoDeNacoes : MonoBehaviour,SaveInterface {

    private Nacao[] nacoes;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setNacoes(Nacao[] nacoes)
    {
        this.nacoes = nacoes;
    }

    public void save()
    {

    }

    public void turnoCormercioNacoes()
    {

    }

    public void definirPrecoPadraoRecurso()
    {

    }

}
