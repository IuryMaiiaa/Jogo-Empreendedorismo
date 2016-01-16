using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

public class Mapa : MonoBehaviour {
    public Transform largura;
    public Transform altura;
    public ArrayList celulasLosango;
    public GameObject LosangoBase;
    public Celula losangoCelulaBase;

	// Use this for initialization  
	void Start () {
        celulasLosango = new ArrayList();
        CriarMapa();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void GerarGradienteLosango() {
        int cont = 0;
        int cont2 = 0;
        float cont3 = -0.1f;
        GameObject losango = GameObject.Instantiate(LosangoBase) as GameObject;
        losango.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,
                                                this.transform.position.z);
        losangoCelulaBase = losango.GetComponent<Celula>();
        float disposicaoCelularVertical = (mapLargura()/ losangoCelulaBase.GetLargura());
        float disposicaoCelularHorizontal =  (mapAltura() /  losangoCelulaBase.GetAltura());
        Destroy(losango.gameObject);
            
        for (cont2 = 2; cont2 <= 2 * disposicaoCelularHorizontal; cont2 = cont2 + 2)
        {

            for (cont = 2; cont <= 2*disposicaoCelularVertical; cont = cont + 2)
            {
                
                losango = GameObject.Instantiate(LosangoBase) as GameObject;
                losango.transform.position = new Vector3(-mapLargura() + (cont * losango.GetComponent<Celula>().GetLargura()),
                                                        (mapAltura() - (cont2 * losango.GetComponent<Celula>().GetAltura())) + losango.GetComponent<Celula>().GetAltura(),
                                                        this.transform.position.z+cont3);
                celulasLosango.Add(losango);
            }
            losango = GameObject.Instantiate(LosangoBase) as GameObject;
            losango.transform.position = new Vector3(-mapLargura(),
                                                    (mapAltura() - (cont2 * losango.GetComponent<Celula>().GetAltura()) + losango.GetComponent<Celula>().GetAltura()),
                                                    this.transform.position.z+cont3);
            celulasLosango.Add(losango);
            cont3 = cont3 - 0.2f;
        }
    }

    private void GerarGradienteLosangoInterno()
    {
        int cont = 0;
        int cont2 = 0;
        float cont3 = -0.2f;
        GameObject losango = GameObject.Instantiate(LosangoBase) as GameObject;
        losango.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,
                                                this.transform.position.z);
        losangoCelulaBase = losango.GetComponent<Celula>();
        float disposicaoCelularVertical = (mapLargura()-losangoCelulaBase.GetLargura()) / losangoCelulaBase.GetLargura();
        float disposicaoCelularHorizontal = (mapAltura() - losangoCelulaBase.GetAltura()) / losangoCelulaBase.GetAltura();
        Destroy(losango.gameObject);

        for (cont2 = 2; cont2 <= 2 * disposicaoCelularHorizontal; cont2 = cont2 + 2)
        {

            for (cont = 2; cont <= 2 * disposicaoCelularVertical; cont = cont + 2)
            {
                losango = GameObject.Instantiate(LosangoBase) as GameObject;
                losango.transform.position = new Vector3((-mapLargura() + losangoCelulaBase.GetLargura()) + (cont * losangoCelulaBase.GetLargura()),
                                                        (mapAltura() - cont2 * losangoCelulaBase.GetAltura()),
                                                        this.transform.position.z+cont3);
                celulasLosango.Add(losango);
            }
            losango = GameObject.Instantiate(LosangoBase) as GameObject;
            losango.transform.position = new Vector3((-mapLargura() + losangoCelulaBase.GetLargura()),
                                                    (mapAltura() - (cont2 * losangoCelulaBase.GetAltura())),
                                                      this.transform.position.z+cont3);
            celulasLosango.Add(losango);
            cont3 = cont3 - 0.2f;
        }
    }

    public void Load(int codigo1, int codigo2)
    {
        if(File.Exists(Application.persistentDataPath+"/" +codigo1 +"" +codigo2+ "MapaData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + codigo1 + "" + codigo2 + "MapaData.dat",FileMode.Open);

            MapaData mapaData = (MapaData)bf.Deserialize(file);
            file.Close();

            this.largura.position = mapaData.largura.V3;
            this.altura.position = mapaData.altura.V3;

            Debug.Log("log");

            foreach (GameObject losango in celulasLosango)
            {
                GameObject celula = Instantiate(losango) as GameObject;
                Debug.Log("printLosango");
            }
        }
        
    }

    public void Save(int codigo1, int codigo2)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + codigo1 + "" + codigo2 + "MapaData.dat");
        MapaData data = new MapaData();
        
        data.altura = new Vector3Seri(this.altura.position);
        data.largura = new Vector3Seri(this.largura.position);
        CelulaData[] celulas = new CelulaData[this.celulasLosango.Count];
        Debug.Log(this.celulasLosango.Count);
        foreach(GameObject objeto in this.celulasLosango)
        {
            CelulaData celuladata = new CelulaData();
            celuladata.posicaoCelula.x = objeto.transform.position.x;
            celuladata.posicaoCelula.y = objeto.transform.position.y;
            celuladata.posicaoCelula.z = objeto.transform.position.z;
            celuladata.Recurso = objeto.GetComponent<Celula>().recurso.recurso;
            celuladata.recursoLv = objeto.GetComponent<Celula>().recurso.lv;
        }

        bf.Serialize(file,data);
        file.Close();
    }

    public void CriarMapa()
    {
        GerarGradienteLosango();
        GerarGradienteLosangoInterno();
    }

    public float mapLargura()
    {
        return largura.transform.position.x - this.transform.position.x;
    }

    public float mapAltura()
    {
        return altura.transform.position.y - this.transform.position.y;
    }
}

[System.Serializable]
class MapaData
{
    public Vector3Seri largura;
    public Vector3Seri altura;
    public CelulaData[] celulasLosango;
    public byte[] losangoCelulaBase;

}

[System.Serializable]
class CelulaData
{
    public String Recurso;
    public int recursoLv;
    public Vector3Seri posicaoCelula;
}