using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public void saveDataNow(string json)
    {
        //En este vamos a traducir el texto al lenguaje maquina
        BinaryFormatter formatter = new BinaryFormatter();
        //Aqui abrimos la direccion de nuestro archivo para poder escribir en el
        FileStream file = File.Create(Application.persistentDataPath + "/data.json");
        //Guardamos la informacion
        formatter.Serialize(file, json);
        //Cerramos el archivo para evitar errores
        file.Close();
    }

    public DataGuardable LoadData()
    {
        //revisamos si existe el archivo
        if (File.Exists(Application.persistentDataPath + "/data.json"))
        {
            //Iniciamos el formater
            BinaryFormatter formater = new BinaryFormatter();
            //Abrimos el archivo para poder leerlo
            FileStream file = File.Open(Application.persistentDataPath + "/data.json", FileMode.Open);
            //Obtenemos el json
            var json = formater.Deserialize(file).ToString();
            //Para revisar el retorno
            Debug.Log(json);
            //Estamos cerrando el archivo
            file.Close();

            //Estoy regresando al informacion
            return JsonUtility.FromJson<DataGuardable>(json);
        }
        //si no existe el archivo regreso un archivo limpio
        return new DataGuardable();
    }

    public void SaveScores()
    {

    }
}

[Serializable]
public class DataGuardable
{
    public string nombre;
    public int puntaje;
    public float tiempoJuego;
}
