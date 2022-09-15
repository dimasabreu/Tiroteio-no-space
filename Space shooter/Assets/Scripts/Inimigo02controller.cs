using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo02controller : InimigoPai
{   // pegando o rb
    private Rigidbody2D meuRB;
    
    // pegando a posição nova do tiro
    [SerializeField] private Transform posicaoTiro;
    // meu tiro
    [SerializeField] private GameObject meuTiro;
    

    private float esperaTiro = 1f;
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
        // Checar se a sprite esta visivel pegando info do child
        bool visivel = GetComponentInChildren<SpriteRenderer>().isVisible;
        // diminuir a espera
        if (visivel)
        {
            esperaTiro -= Time.deltaTime;
            if (esperaTiro <= 0)
            {
                // Instanciando o tiro
                Instantiate(meuTiro, posicaoTiro.position, transform.rotation);
                // reiniciando o tiro
                esperaTiro = Random.Range(2f, 4f);
            }
        }
    }
}
