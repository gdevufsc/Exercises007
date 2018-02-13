using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//Esse script faz com que um objeto persista entre as cenas, preservando informação. Ele também salva essa informação
//em um arquivo no método criado Save

public class GameController : MonoBehaviour {

    //criando uma variável estática dessa própria classe
    public static GameController control;

    //declarando valores a serem salvos
    public float health, experience;

    //Awake acontece antes da Start
    void Awake()
    {
        //se control é nula
        if(control == null)
        { //não destrua ao trocar de cena
            DontDestroyOnLoad(gameObject);
            control = this; //e armazene esse objeto-script na variável control
        } else if(control != this) //mas se control existir, e não for esse objeto-script aqui...
        { //destrua esse objeto, pois ele não é o control oficial.
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        //Esse BinaryFormatter é para codificar os dados
        BinaryFormatter bf = new BinaryFormatter();

        //essa linha cria um arquivo, armazena na variável file, usa o caminho padrão do dispositivo, atribuindo o nome
        //playerInfo.dat ; 
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat"); 

        //cria uma PlayerData da classe escrita depois dessa
        PlayerData data = new PlayerData
        {
            health = health,
            experience = experience
        };

        //codifica o arquivo, no que envolve data
        bf.Serialize(file, data);

        //fecha o arquivo;
        file.Close();
    }

    public void Load()
    {
        //caso o arquivo exista
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {
            //crie um codificador
            BinaryFormatter bf = new BinaryFormatter();
            //abra o arquivo. FileMode.Open é o modo que abre, e throw exeption se não existe tal arquivo
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            //decodifique e guarde na variável data
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close(); //feche o arquivo

            //armazene os valores nas variáveis locais
            health = data.health;
            experience = data.experience;
        }
    }
}

//PlayerData é uma classe serializavel, ou seja, que dá para codificar. Ela guarda as informações que serão codificadas
[Serializable]
class PlayerData
{
    public float health, experience;
}
