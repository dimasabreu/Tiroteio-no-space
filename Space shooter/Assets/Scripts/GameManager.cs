using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake() 
    {
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
    public void Inicio()
    {
        SceneManager.LoadScene(0);
    }
    public void Sair()
    {
        Application.Quit();
    }
}
