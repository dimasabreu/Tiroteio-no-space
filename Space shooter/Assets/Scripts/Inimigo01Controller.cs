using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo01Controller : InimigoPai
{   // pegando o rb
    private Rigidbody2D meuRB;
    
    // pegando a posição nova do tiro
    [SerializeField] private Transform posicaoTiro;
    
    
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
        seMata();
    }

    private void Atirando()
    {
        // Checar se a sprite esta visivel pegando info do child
        bool visivel = GetComponentInChildren<SpriteRenderer>().isVisible;
        
        // diminuir a espera
        if(visivel)
        {
            esperaTiro -= Time.deltaTime;
            if (esperaTiro <= 0)
            {
                // Instanciando o tiro
                var tiro = Instantiate(meuTiro, posicaoTiro.position, transform.rotation);
                tiro.GetComponent<Rigidbody2D>().velocity = Vector2.down * velocidadeTiro;
                // reiniciando o tiro
                esperaTiro = Random.Range(1.5f, 2f);
                //tocando o som do tiro
                TocaTiro();
            }
        }
    }
}
