using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static string PLANTA = "PLANTA";
    public static string MELECA = "MELECA";
    public static string NENHUM = "NENHUM";
    public string recursoAtual;

    public static string COLOCAR = "COLOCAR";
    public static string UPGRADE = "UPGRADE";
    public static string REMOVER = "REMOVER";
    public static string CANCELAR = "CANCELAR";
    public string acaoAtual;

    public Texture2D[] cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    private int id_butao;

    // Use this for initialization
    void Start () {
        recursoAtual = NENHUM;
        id_butao = 4;
        Cursor.SetCursor(cursorTexture[0], hotSpot, cursorMode);
    }
	
	// Update is called once per frame
	void Update () {

        if (id_butao == 4) {

            if (Input.GetMouseButtonDown(0))
                Cursor.SetCursor(cursorTexture[1], hotSpot, cursorMode);

            if (Input.GetMouseButtonUp(0))
                Cursor.SetCursor(cursorTexture[0], hotSpot, cursorMode);
        }
    }

    public void mudarRecurso(int id)
    {
        if(id == 1)
        {
            recursoAtual = MELECA;
        } else if(id == 2)
        {
            recursoAtual = PLANTA;
        }
    }

    public void mudarAcao(int id)
    {
        id_butao = id;

        if (id == 1)
        {
            acaoAtual = COLOCAR;
            
            Cursor.SetCursor(cursorTexture[2], hotSpot, cursorMode);
        }
        else if (id == 2)
        {
            acaoAtual = UPGRADE;

            Cursor.SetCursor(cursorTexture[2], hotSpot, cursorMode);
        }
        else if (id == 3)
        {
            acaoAtual = REMOVER;

            Cursor.SetCursor(cursorTexture[2], hotSpot, cursorMode);
        }
        else if (id == 4) {

            acaoAtual = CANCELAR;

            Cursor.SetCursor(cursorTexture[0], hotSpot, cursorMode);
        }

    }
}
