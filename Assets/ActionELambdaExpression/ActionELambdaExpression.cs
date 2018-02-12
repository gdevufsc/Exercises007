using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

///Esse script testa um tipo de Delegate chamado Action
///Actions são variáveis para armazenar funções tipo void.
///O script também testa Lambda Expressions. São uma forma simplificada de
///escrever funções.
public class Test : MonoBehaviour {

    float result;

    //Declarando Action que usa um parâmetro float;
    Action<float> myFloatAction;

    void Start () {
        //armazenando a função na variável
        myFloatAction = MyFunction;
        //chamando o método armazenado
        myFloatAction(4f);
    }

    //criando a função chamada no Start, de maneira convencional
    public void MyFunction(float myFloat)
    {
        //fazendo uma conta qualquer e printando o resultado
        result = myFloat * myFloat;
        print(result); //espera-se resultado 16

        //armazenando nova função na variável, criada na mesma linha utilizando Lambda Expression
        myFloatAction = nexus => { result = nexus / 7; print(result); };

        //chamando o novo método.
        myFloatAction(7f); //espera-se resultado 1

        //teste com Lambda Expression sem chaves
        myFloatAction = nexus => result = nexus / 2;
        myFloatAction(4);
        print(result); //espera-se resultado 2
    }

}
