using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake() 
    {
        // garantindo q só tem 1
        int quantidade = FindObjectsOfType<GameManager>().Length;
        if (quantidade > 1)
        {
            Destroy(gameObject);
        }
        // nao destruindo quando trocar de cena
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    // criando o metodo para ir para o jogo
    public void IniciaJogo()
    {
        SceneManager.LoadScene(1);
    }

    // colocando delay na morte com uma corotina
    IEnumerator PrimeiraCena()
    {
         yield return new WaitForSeconds(2f);
         SceneManager.LoadScene(0);
   }
    public void Inicio()
    {
        StartCoroutine(PrimeiraCena());
    }
    public void Sair()
    {
        Application.Quit();
    }
}
