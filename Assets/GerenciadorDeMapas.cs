using UnityEngine;
using System.Collections;

public class GerenciadorDeMapas : MonoBehaviour {
    public GameObject[,] Mapas;
    public GameObject MapaPadrao;
    public float tempo;

	// Use this for initialization
	void Start () {
        Mapas = new GameObject[3 , 3];
        for(int cont=0;cont<3;cont++)
        {
            for (int cont2=0;cont2<3;cont2++)
            {
                GameObject mapa = GameObject.Instantiate(MapaPadrao) as GameObject;
                //mapa.GetComponent<Mapa>().Save(cont,cont2);
                Mapas[cont , cont2] = mapa;
            }
        }
        tempo = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void botaoIniciar()
    {
        saveMapas();
        destroiMapas();
        load(1, 1);
    }

    public void saveMapas()
    {
        for (int cont = 0; cont < 3; cont++)
        {
            for (int cont2 = 0; cont2 < 3; cont2++)
            {
                Mapas[cont, cont2].GetComponent<Mapa>().Save(cont, cont2);
            }
        }
    }

    public void destroiMapas()
    {
        for (int cont = 0; cont < 3; cont++)
        {
            for (int cont2 = 0; cont2 < 3; cont2++)
            {
                Destroy(Mapas[cont,cont2]);
            }
        }
    }

    public void load(int posX,int posY)
    {
        GameObject mapa = Instantiate(Mapas[posX,posY]) as GameObject;
        mapa.GetComponent<Mapa>().Load(posX,posY);
    }
    

}
