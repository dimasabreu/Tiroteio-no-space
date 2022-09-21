using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPai : MonoBehaviour
{
    // Start is called before the first frame update
    // atributos que todos os inimigos tem
    [SerializeField] protected float velocidade;
    [SerializeField] protected int vida;
    [SerializeField] protected float esperaTiro = 1f;
    [SerializeField] protected float velocidadeTiro = 5f;
    [SerializeField] protected GameObject meuTiro;
    [SerializeField] protected GameObject explosao;

    [SerializeField] protected float yDEAD = -7f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // metodo de perder vida
    public void PerdeVida(int dano)
    {
        vida -= dano;

        if (vida <= 0)
        {
            Destroy(gameObject);

            Instantiate(explosao, transform.position, transform.rotation);
        }
    }


    // metodo de se matar
    public void seMata()
    {
        if(transform.position.y < yDEAD)
            {
                Destroy(gameObject);
            }
    }


    // metodo de colisao
    private void OnCollisionEnter2D(Collision2D other) 
    {
        // checando se eu colidi com o player
        if (other.gameObject.CompareTag("Jogador"))
        {
            other.gameObject.GetComponent<PlayerController>().PerdeVida(1);
            Destroy(gameObject);
            // criando o impacto da batida
            Instantiate(explosao, transform.position, transform.rotation);
        }
    }
    

}
