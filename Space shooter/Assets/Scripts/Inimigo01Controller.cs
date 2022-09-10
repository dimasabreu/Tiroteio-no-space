using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo01Controller : MonoBehaviour
{   // pegando o rb
    private Rigidbody2D meuRB;
    [SerializeField] private float velocidade = -3f;
    // pegando a posição nova do tiro
    [SerializeField] private Transform posicaoTiro;
    // meu tiro
    [SerializeField] private GameObject meuTiro;
    // minha explosão
    [SerializeField] private GameObject explosao;
    // delay do tiro
    [SerializeField] private int vida = 1;

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
                esperaTiro = Random.Range(1.5f, 2f);
            }
        }
    }
    // metodo perde vida
    public void PerdeVida(int dano)
    {
        // perdendo vida
        vida -= dano;
        // checando a morte
        if (vida <= 0)
        {
            
            Destroy(gameObject);
            // instanciado a explosão
            Instantiate(explosao, transform.position, transform.rotation);
        }
        
    }
}
