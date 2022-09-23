using System;
using UnityEngine;

public class BossController : InimigoPai
{   
    [Header("Informações Básicas")]
    [SerializeField] private string estado = "estado1";
    
    [SerializeField] private Rigidbody2D meuRB;
    [SerializeField] private bool direita = true;
    [SerializeField] private float limite = 6f;
    [Header("Informações dos tiros")]
    [SerializeField] private Transform posicaoTiro1;
    [SerializeField] private Transform posicaoTiro1_2;
    [SerializeField] private Transform posicaoTiro2;
    [SerializeField] private GameObject tiro1;
    [SerializeField] private GameObject tiro2;
    [SerializeField] private float delayTiro = 1f;

    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (estado)
        {
            case "estado1":
                Estado1();
                break;
            case "estado2":
                Estado2();
                break;
            case "estado3":
                Estado3();
                break;
        }
    }

    private void Estado3()
    {
        // espera do tiro
        if (esperaTiro <= 0f)
        {
            Tiro1();
            Tiro2();
            esperaTiro = delayTiro;
        }
        else
        {
            esperaTiro -= Time.deltaTime;
        }
        // isntanciando a velocidade do boss
        if (direita)
        {
            meuRB.velocity = new Vector2(velocidade, 0f);
        }
        else
        {
            meuRB.velocity = new Vector2(-velocidade, 0f);
        }
        // prendendo o boss na tela
        if (transform.position.x >= limite)
        {
            direita = false;
        }
        else if (transform.position.x <= -limite)
        {
            direita = true;
        }
    }

    private void Estado2()
    {
        // espera do tiro
        if (esperaTiro <= 0f)
        {
            Tiro2();
            esperaTiro = delayTiro / 2f;
        }
        else
        {
            esperaTiro -= Time.deltaTime;
        }
        
    }

    private void Estado1()
    {
        // espera do tiro
        if (esperaTiro <= 0f)
        {
            Tiro1();
            esperaTiro = delayTiro * 0.8f;
        }
        else
        {
            esperaTiro -= Time.deltaTime;
        }
        // isntanciando a velocidade do boss
        if (direita)
        {
            meuRB.velocity = new Vector2(velocidade, 0f);
        }
        else
        {
            meuRB.velocity = new Vector2(-velocidade, 0f);
        }
        // prendendo o boss na tela
        if (transform.position.x >= limite)
        {
            direita = false;
        }
        else if (transform.position.x <= -limite)
        {
            direita = true;
        }
        
    }

    private void Tiro1()
    {
        GameObject tiro =  Instantiate(tiro1, posicaoTiro1.position, transform.rotation);
        tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -velocidadeTiro);
        tiro = Instantiate(tiro1, posicaoTiro1_2.position, transform.rotation);
        tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -velocidadeTiro);
    }

    private void Tiro2()
    {
        // encontrando o player
        var player = FindObjectOfType<PlayerController>();
        // so fazer qualquer coisa se o player existir
        if (player)
        {
            // Instanciando o tiro
            var tiro = Instantiate(tiro2, posicaoTiro2.position, transform.rotation);
            // encontrando o valor da direção
            Vector2 direcao = player.transform.position - tiro.transform.position;
            // normalizando a velocidade do tiro 
            direcao.Normalize();
            // dando a direcao e velo do tiro
            tiro.GetComponent<Rigidbody2D>().velocity = direcao * velocidadeTiro;
            // colocando o angulo do tiro
            float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
            //passando o angulo para o tiro
            tiro.transform.rotation = Quaternion.Euler(0f, 0f, angulo + 90f);
        }
    }
}
