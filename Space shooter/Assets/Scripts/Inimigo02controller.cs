using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo02controller : InimigoPai
{   // pegando o rb
    private Rigidbody2D meuRB;
    
    // pegando a posição nova do tiro
    [SerializeField] private Transform posicaoTiro;
    [SerializeField] private float yMax = 2.5f;
    [SerializeField] private float xMin = 0f;
   
    private bool possoMover = true;

 
    // Start is called before the first frame update
    void Start()
    {
        // pegnado o rb
        meuRB = GetComponent<Rigidbody2D>();
        // colocando a velocidade no rb
        meuRB.velocity = new Vector2(0f, velocidade);
        // deixando espera do tiro aleatoria
        esperaTiro = Random.Range(0.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        Atirando();
        seMovendo();
        seMata();
    }

    // atirando
    private void Atirando()
    {
        // Checar se a sprite esta visivel pegando info do child
        bool visivel = GetComponentInChildren<SpriteRenderer>().isVisible;
        
        // diminuir a espera
        if (visivel)
        {
            // encontrando o player
            var player = FindObjectOfType<PlayerController>();
            // so fazer qualquer coisa se o player existir
            if (player)
            {
                esperaTiro -= Time.deltaTime;
            if (esperaTiro <= 0)
            {
                // Instanciando o tiro
                var tiro = Instantiate(meuTiro, posicaoTiro.position, transform.rotation);
                
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
                
                // reiniciando o tiro
                esperaTiro = Random.Range(2f, 4f);
                //tocando o som do tiro
                TocaTiro();
            }   
            }
            
        }
    }

    // movendo
    private void seMovendo()
    {
         // chegando se ja estou no meio da tela
        if(transform.position.y < yMax && possoMover)
        {
            if(transform.position.x > xMin)
            {
                meuRB.velocity = new Vector2(velocidade, velocidade);

                //falando que eu não posso mais me mover
                possoMover = false;
            }
            if(transform.position.x < xMin)
            {
                meuRB.velocity = new Vector2(-velocidade, velocidade);
                possoMover = false;
            }
        }
    }

}

