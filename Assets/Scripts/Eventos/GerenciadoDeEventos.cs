using UnityEngine;
using System.Collections;

public class GerenciadoDeEventos : MonoBehaviour {
    public scriptGameTutorial tutorial;
    public bool tutorialCompleto;

    public SaveAtual saveAtual;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void iniciarEventos()
    {
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
    }

    public void loadEventos()
    {
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
    }

    public void save()
    {
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
    }

    public void load()
    {
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
    }
}
