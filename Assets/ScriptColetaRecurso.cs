using UnityEngine;
using System.Collections;

public class ScriptColetaRecurso : MonoBehaviour {
    public Recurso recursoAtual;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void adicionarRecurso(Recurso recurso)
    {
        recursoAtual = recurso;
    }

    public void coletarRecurso()
    {
        recursoAtual.colherRecurso();
    }

    public void deletaRecurso()
    {
        recursoAtual.remover();
    }

}
