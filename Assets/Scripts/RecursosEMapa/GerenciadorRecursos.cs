using UnityEngine;
using System.Collections;

public class GerenciadorRecursos : MonoBehaviour {
    //plantas
    public Sprite plantalv1;
    public Sprite plantalv2;
    public Sprite plantalv3;

    //Sparkunglax ciberiano
    public Sprite Sparkunglaxlv1;

    //Cebolinha de couro.
    public Sprite cebolinhalv1;

    private RecursoEnum recursoEnum;
    
    // Use this for initialization
    void Start () {
        recursoEnum = new RecursoEnum();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Sprite GetRecursoSprite(string recursoNome,int lv)
    {
        if (recursoNome == recursoEnum.getPlantaRecursoString())
        {
            return GetPlantaSprite(lv);
        }
        else if (recursoNome == recursoEnum.getMelecarRecursoString())
        {
            return GetMelecaSprite(lv);
        } else if(recursoNome == recursoEnum.getCouroRecursoString())
        {
            return GetCouroSprite(lv);
        } else
        {
            return null;
        }
    }

    public Sprite GetCouroSprite(int lv)
    {
        if (lv == 3)
        {
            return cebolinhalv1;
        }
        else if (lv == 2)
        {
            return cebolinhalv1;
        }
        else
        {
            return cebolinhalv1;
        }
    }

    public Sprite GetMelecaSprite(int lv)
    {
        if (lv == 3)
        {
            return Sparkunglaxlv1;
        }
        else if (lv == 2)
        {
            return Sparkunglaxlv1;
        }
        else
        {
            return Sparkunglaxlv1;
        }
    }

    public Sprite GetPlantaSprite(int lv)
    {
        if(lv == 3)
        {
            return plantalv3;
        } else if ( lv == 2)
        {
            return plantalv2;
        } else
        {
            return plantalv1;
        }
    }
}
