using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ChangeTextValue : MonoBehaviour {

    //tValue é o objeto texto usado para mostrar o valor do slider
    public Text tValue;

    //defaultText é o texto padrão que sempre se repete, ou seja, "Value: "
    string defaultText;

    Slider slider;

    //declarando persistentInformation, que é um script de um objeto que não é destruido ao trocar de cena
    PersistentInformation persistentInformation; //é usado para armazenar informação através de cenas

    //é o referido objeto que não é destruído ao trocar de cena
    GameObject PersistentBox;

    private void Start()
    {
        //Define o objeto-script do tipo PersistentInformation para ser usado na sequencia
        DefinepersistentInformation();

        slider = GetComponent<Slider>();

        //o slider recebe a informação guardada na persistentInformation
        slider.value = persistentInformation.value;

        //configurando defaultText
        defaultText = "Value: ";

        //o texto a ser mostrado recebe o defaultText + o valor registrado na persistentInformation
        tValue.text = defaultText + persistentInformation.value.ToString();
    }

    //Essa função é chamada pelo objeto slider do editor da Unity sempre que o valor do slider é modificado
    public void ChangeValue() //esse nome é arbitrário, mas linkado no editor com o slider
    {
        //o texto mostrado na tela recebe o defaultText + o valor do slider
        tValue.text = defaultText + slider.value.ToString();

        //registra o valor na persistentInformation
        persistentInformation.value = slider.value;
    }

    void DefinepersistentInformation()
    {
        //primeiramente ele procura se já tem esse objeto. Só vai instanciar se não tiver.
        PersistentBox = GameObject.FindGameObjectWithTag("GameController");

        //caso não tenha, instancia-se uma PersistantBox
        if (PersistentBox == null)
        {
            //carrega da pasta resources
            PersistentBox = Resources.Load("PersistentBox") as GameObject;
            PersistentBox = Instantiate(PersistentBox); //Instancia
            PersistentBox.name = "PersistentBox"; // muda o nome porque PersistentBox (Clone) é feio
        }

        //armazena o componente script, PersistentInformation na variável devida
        persistentInformation = PersistentBox.GetComponent<PersistentInformation>();
    }

}
