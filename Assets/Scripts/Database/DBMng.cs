using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBMng
{
    private const string LEVEL_DATA = "level-data-";
    private const string HABILITA_LEVEL = "habilita-level-";

    public static void SalvarDadosLevel(int idLevel, int qtdFrutas){
        PlayerPrefs.SetInt(LEVEL_DATA+idLevel,qtdFrutas);
        PlayerPrefs.SetInt(HABILITA_LEVEL + (idLevel+1),1);
    }

    public static int BuscarQtdFrutasLevel(int idLevel){
        return PlayerPrefs.GetInt(LEVEL_DATA+idLevel);
    }

    public static int BuscarLevelHabilitado(int idLevel){
        return PlayerPrefs.GetInt(HABILITA_LEVEL+idLevel);
    }

}
