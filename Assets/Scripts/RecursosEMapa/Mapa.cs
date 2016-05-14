using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

public class Mapa : MonoBehaviour {
    public Transform largura;
    public Transform altura;
    public ArrayList celulasLosango = new ArrayList();
    public GameObject LosangoBase;
    public Celula losangoCelulaBase;
    public SaveAtual saveAtual;

	// Use this for initialization  
	void Start () {
        celulasLosango = new ArrayList();
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
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
                losango.transform.parent = this.gameObject.transform;
            }
            losango = GameObject.Instantiate(LosangoBase) as GameObject;
            losango.transform.position = new Vector3(-mapLargura(),
                                                    (mapAltura() - (cont2 * losango.GetComponent<Celula>().GetAltura()) + losango.GetComponent<Celula>().GetAltura()),
                                                    this.transform.position.z+cont3);
            celulasLosango.Add(losango);
            losango.transform.parent = this.gameObject.transform;
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
                losango.transform.parent = this.gameObject.transform;
            }
            losango = GameObject.Instantiate(LosangoBase) as GameObject;
            losango.transform.position = new Vector3((-mapLargura() + losangoCelulaBase.GetLargura()),
                                                    (mapAltura() - (cont2 * losangoCelulaBase.GetAltura())),
                                                      this.transform.position.z+cont3);
            celulasLosango.Add(losango);
            losango.transform.parent = this.gameObject.transform;
            cont3 = cont3 - 0.2f;
        }
    }

    public void LoadLista(int codigo1, int codigo2, ArrayList list)
    {
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
        if (File.Exists(Application.persistentDataPath + "/"+ saveAtual.getSaveAtualId() + "" + codigo1 + "" + codigo2 + "MapaData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + "" + codigo1 + "" + codigo2 + "MapaData.dat", FileMode.Open);

            MapaData mapaData = (MapaData)bf.Deserialize(file);
            file.Close();
            foreach (CelulaData celulas in mapaData.celulasLosango)
            {
                GameObject celula = GameObject.Instantiate(LosangoBase) as GameObject;
                celula.transform.position = celulas.posicaoCelula.V3;
                celula.GetComponent<Celula>().recurso.setRecurso(celulas.Recurso, celulas.recursoLv);
                celula.GetComponent<Celula>().recurso.setTempoDecorrido(celulas.tempoDecorrido);
                list.Add(celula);
                celula.transform.parent = this.gameObject.transform;

            }
        }
    }

    public GameObject Load(int codigo1, int codigo2)
    {
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
        if (File.Exists(Application.persistentDataPath+"/" + saveAtual.getSaveAtualId() + "" + codigo1 + "" +codigo2+ "MapaData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + "" + codigo1 + "" + codigo2 + "MapaData.dat",FileMode.Open);

            MapaData mapaData = (MapaData)bf.Deserialize(file);
            file.Close();
            this.largura.position = mapaData.largura.V3;
            this.altura.position = mapaData.altura.V3;
            celulasLosango = new ArrayList();
            foreach (CelulaData celulas in mapaData.celulasLosango)
            {
                GameObject celula  = GameObject.Instantiate(LosangoBase) as GameObject;
                celula.transform.position = celulas.posicaoCelula.V3;
                celula.GetComponent<Celula>().recurso.setRecurso(celulas.Recurso, celulas.recursoLv);
                celula.GetComponent<Celula>().recurso.setTempoDecorrido(celulas.tempoDecorrido);
                celulasLosango.Add(celula);
                celula.transform.parent = this.gameObject.transform;
            }
            return this.gameObject;
        }
        return null;
        
    }

    public void destroiCelulas()
    {
        
        foreach (GameObject obj in celulasLosango)
        {
            Destroy(obj);
        }
        celulasLosango.Clear();
    }

    public void destroiTODASCelulasJOGO()
    {
        foreach (Celula obj in celulasLosango) {
            Destroy(obj.gameObject);
        }
        celulasLosango.Clear();

    }

    public ArrayList findArray()
    {
        ArrayList list = new ArrayList();
        Celula[] celulas = (Celula[])GameObject.FindObjectsOfType<Celula>();
        foreach (Celula c in celulas)
        {
            list.Add(c.gameObject);
        }

        return list;
    }

    public void Save(int codigo1, int codigo2)
    {
        saveAtual = GameObject.FindObjectOfType<SaveAtual>();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + saveAtual.getSaveAtualId() + "" + codigo1 + "" + codigo2 + "MapaData.dat");
        MapaData data = new MapaData();
        
        data.altura = new Vector3Seri(this.altura.position);
        data.largura = new Vector3Seri(this.largura.position);
        Celula[] celulasLosangoFilhas = this.gameObject.GetComponentsInChildren<Celula>();
        CelulaData[] celulas = new CelulaData[celulasLosangoFilhas.Length];
        int cont = 0;
        foreach (Celula obj in celulasLosangoFilhas)
        {
            CelulaData celuladata = new CelulaData();
            celuladata.posicaoCelula = new Vector3Seri(obj.transform.position);
            celuladata.Recurso = obj.recurso.recurso;
            celuladata.recursoLv = obj.recurso.lv;
            celuladata.tempoDecorrido = obj.recurso.tempoDecorrido;
            celulas[cont] = celuladata;
            cont++;
        }
        data.celulasLosango = celulas;
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

}

[System.Serializable]
class CelulaData
{
    public int tempoDecorrido;
    public String Recurso;
    public int recursoLv;
    public Vector3Seri posicaoCelula;
}