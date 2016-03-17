using UnityEngine;
using System.Collections;

public class GerenciadorDeMapas : MonoBehaviour,SaveInterface {
    public GameObject[,] Mapas;
    public GameObject MapaPadrao;
    public int posX;
    public int posY;
    public float tempo;

	// Use this for initialization
	void Start () {
        
	}

    public void criarMapas()
    {
        
        Mapas = new GameObject[3, 3];
        for (int cont = 0; cont < 3; cont++)
        {
            for (int cont2 = 0; cont2 < 3; cont2++)
            {
                GameObject mapa = GameObject.Instantiate(MapaPadrao) as GameObject;
                mapa.GetComponent<Mapa>().CriarMapa();
                //mapa.GetComponent<Mapa>().Save(cont,cont2);
                Mapas[cont, cont2] = mapa;
            }
        }
        saveMapas();
        destroiMapas();
        load(1, 1);
    }

    public void loadNewMap(string posicao)
    {
        if(posicao == "00")
        {
            salvarMapaAtual();
            destroiMapaAtual();
            load(0, 0);
        } else if(posicao == "01")
        {
            salvarMapaAtual();
            destroiMapaAtual();
            load(0, 1);
        }
        else if (posicao == "02")
        {
            salvarMapaAtual();
            destroiMapaAtual();
            load(0, 2);
        }
        else if (posicao == "10")
        {
            salvarMapaAtual();
            destroiMapaAtual();
            load(1, 0);
        }
        else if (posicao == "11")
        {
            salvarMapaAtual();
            destroiMapaAtual();
            load(1, 1);
        }
        else if (posicao == "12")
        {
            salvarMapaAtual();
            destroiMapaAtual();
            load(1, 2);
        }
        else if (posicao == "20")
        {
            salvarMapaAtual();
            destroiMapaAtual();
            load(2, 0);
        }
        else if (posicao == "21")
        {
            salvarMapaAtual();
            destroiMapaAtual();
            load(2, 1);
        }
        else if (posicao == "22")
        {
            salvarMapaAtual();
            destroiMapaAtual();
            load(2, 2);
        }
        
    }
    public void criarMapasLoad()
    {
        Mapas = new GameObject[3, 3];
        load(1, 1);
    }

    // Update is called once per frame
    void Update () {
	}

    public void saveMapas()
    {
        for (int cont = 0; cont < 3; cont++)
        {
            for (int cont2 = 0; cont2 < 3; cont2++)
            {
                Mapas[cont, cont2].GetComponent<Mapa>().Save(cont, cont2);
                Debug.Log("saveMapa");
            }
        }
    }

    public void destroiMapas()
    {
        for (int cont = 0; cont < 3; cont++)
        {
            for (int cont2 = 0; cont2 < 3; cont2++)
            {
                Mapas[cont, cont2].GetComponent<Mapa>().destroiCelulas();
                Destroy(Mapas[cont,cont2]);
            }
        }
    }

    public void destroiMapaAtual()
    {
        Mapas[posX, posY].GetComponent<Mapa>().destroiCelulas();
        Destroy(Mapas[posX, posY]);
    }

    public void loadmapa()
    {
        if (Mapas[1,1]==null) {
            load(1, 1);
        }
    }

    public void load(int posX,int posY)
    {
        Debug.Log("aqui");
        this.posX = posX;
        this.posY = posY;
        GameObject mapa = Instantiate(MapaPadrao) as GameObject;
        mapa.GetComponent<Mapa>().destroiTODASCelulasJOGO();
        Mapas[posX, posY] = mapa.GetComponent<Mapa>().Load(posX,posY);
    }

    public void save()
    {
        Debug.Log("aqui");
        Mapa mapa = Mapas[posX, posY].GetComponent<Mapa>();
        mapa.Save(posX, posY);
    }

    public void salvarMapaAtual()
    {
        Mapa mapa = Mapas[posX, posY].GetComponent<Mapa>();
        mapa.Save(posX, posY);
    }
    

}
