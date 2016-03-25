using UnityEngine;
using System.Collections;

public class Objetivo : MonoBehaviour {
    public string recurso;
    public int meta;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
