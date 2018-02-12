using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Esse script é um teste de salvar informação de uma sessão para usar na próxima vez que o usuário
/// abrir o jogo. As informações são salvas no regedit, no caso do windows. Para abrir o regedit,
/// basta ir na area de pesquisa e digitar regedit. O caminho para os registros é HKEY_CURRENT_USER
/// - Software - Company Name - Product Name - registros.
/// </summary>

public class Save : MonoBehaviour {

    //ColorBlock é um conjunto de cores usado em botões
    ColorBlock cb;

    //Essa Color é pública para ser definida no editor
    public Color newColor;

    //criando variável para botão e objeto de texto.
    Button btn;
    Text btnText;

    private void Start()
    {
        //armazena o btn e o btnText
        btn = GetComponent<Button>();
        btnText = btn.GetComponentInChildren<Text>();

        //carrega do regedit a string com a chave "S" e põe no btnText.text
        btnText.text = PlayerPrefs.GetString("S");

        //confere se o texto é Saved. Caso seja, troca a cor do botão chamando o método OnButton;
        if (btnText.text == "Saved") {
            OnButton();
        } else { //caso não seja Saved, deve ser nulo, então configura para o padrão que é Save.
            PlayerPrefs.SetString("S", "Save");
            btnText.text = "Save";
        }
    }

    //troca as cores do botão, e o texto para Saved;
    public void OnButton()
    {
        cb = btn.colors;
        print("ok");
        cb.highlightedColor = newColor;
        cb.normalColor = newColor;
        btn.colors = cb;
        btnText.text = "Saved";
        
        //salva esse texto no regedit
        PlayerPrefs.SetString("S", "Saved");
    }

}
