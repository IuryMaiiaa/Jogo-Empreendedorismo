using UnityEngine;
using System.Collections;

public class GerenciadorRecursos : MonoBehaviour {
    public Sprite plantalv1;
    public Sprite plantalv2;
    public Sprite plantalv3;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Sprite GetRecursoSprite(string recursoNome,int lv)
    {
        if(recursoNome == "PLANTA")
        {
            return GetPlantaSprite(lv);
        } else
        {
            return GetPlantaSprite(lv);
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
