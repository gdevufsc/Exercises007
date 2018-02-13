using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class NewChangeTextValue : MonoBehaviour
{

    //tValue é o objeto texto usado para mostrar o valor do slider
    public Text tValue;

    //defaultText é o texto padrão que sempre se repete, ou seja, "Value: "
    string defaultText;

    Slider slider;

    //declarando gameController, que é um script de um objeto que não é destruido ao trocar de cena
    public GameController gameController; //é usado para armazenar informação através de cenas

    private void Start()
    {
        slider = GetComponent<Slider>();

        //o slider recebe a informação guardada na gameController
        slider.value = gameController.health;

        //configurando defaultText
        defaultText = "Health: ";

        //o texto a ser mostrado recebe o defaultText + o valor registrado na gameController
        tValue.text = defaultText + gameController.health.ToString();
    }

    //Essa função é chamada pelo objeto slider do editor da Unity sempre que o valor do slider é modificado
    public void ChangeValue() //esse nome é arbitrário, mas linkado no editor com o slider
    {
        //o texto mostrado na tela recebe o defaultText + o valor do slider
        tValue.text = defaultText + slider.value.ToString();

        //registra o valor na gameController
        gameController.health = slider.value;
    }

    public void OnValuesLoaded ()
    {
        //atualiza o valor do slider
        slider.value = gameController.health;

        //o texto mostrado na tela recebe o defaultText + o valor do slider
        tValue.text = defaultText + slider.value.ToString();
    }
}
