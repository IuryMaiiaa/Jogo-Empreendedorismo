using UnityEngine;
using System.Collections;

public class RecursoEnum {
    public static string RECURSOPLANTA = "PLANTA" ;
    public static string RECURSOMELECA = "MELECA";
    public static string RECURSOCOURO = "COURO";
    public static string RECURSODINHEIRO = "DINHEIRO";
    public static string RECURSONENHUM = "NENHUM";

    public string getPlantaRecursoString()
    {
        return RECURSOPLANTA;
    }

    public string getCouroRecursoString()
    {
        return RECURSOCOURO;
    }


    public string getMelecarRecursoString()
    {
        return RECURSOMELECA;
    }

    public string getNenhumRecursoString()
    {
        return RECURSONENHUM;
    }

    public string getDinheiroRecursoString()
    {
        return RECURSODINHEIRO;
    }

}
