using UnityEngine;
using System.Collections;

public class AtualizacaoRecursoMenu : MonoBehaviour {
    public UnityEngine.UI.Text PlantaText;
    public UnityEngine.UI.Text MelecaText;
    public UnityEngine.UI.Text CouroText;
    public UnityEngine.UI.Text DinheiroText;

    public ArmazemGerenciamento armazem;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        PlantaText.text = ""+armazem.recursoPlantaArmazenado+"/"+armazem.MaximaCapacidade;
        MelecaText.text = "" + armazem.recursoMelecaArmazenado+"/"+armazem.MaximaCapacidade;
        CouroText.text = "" + armazem.recursoCouroArmazenado+"/"+armazem.MaximaCapacidade;
	}
}
