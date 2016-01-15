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
            this.losangoCelulaBase = (Celula)mapaData.ByteArrayToObject(mapaData.losangoCelulaBase);
            this.celulasLosango = (ArrayList)mapaData.ByteArrayToObject(mapaData.celulasLosango);

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
        data.celulasLosango = data.ObjectToByteArray(this.celulasLosango);
        data.losangoCelulaBase = data.ObjectToByteArray(this.losangoCelulaBase);

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

[Serializable]
class MapaData
{
    public Vector3Seri largura;
    public Vector3Seri altura;
    public byte[] celulasLosango;
    public byte[] losangoCelulaBase;

    public byte[] ObjectToByteArray(System.Object obj)
    {
        if (obj == null)
            return null;

        BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream())
        {
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }
    }

    public System.Object ByteArrayToObject(byte[] arrBytes)
    {
        MemoryStream memStream = new MemoryStream();
        BinaryFormatter binForm = new BinaryFormatter();
        memStream.Write(arrBytes, 0, arrBytes.Length);
        memStream.Seek(0, SeekOrigin.Begin);
        System.Object obj = (System.Object)binForm.Deserialize(memStream);
        return obj;
    }

}