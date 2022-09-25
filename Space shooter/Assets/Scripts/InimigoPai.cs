using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPai : MonoBehaviour
{
    // Start is called before the first frame update
    // atributos que todos os inimigos tem
    [Header("Informações do Pai")]
    [SerializeField] protected float velocidade;
    [SerializeField] public int vida = 1;
    [SerializeField] protected float esperaTiro = 1f;
    [SerializeField] protected float velocidadeTiro = 5f;
    [SerializeField] protected GameObject meuTiro;
    [SerializeField] protected GameObject explosao;
    [SerializeField] protected AudioClip somTiro;

    [SerializeField] protected float yDEAD = -7f;
    protected float xDEAD = 9.26f;
    [SerializeField] public int pontos = 10;

    // criando o drop do power up
    [SerializeField] protected GameObject powerUP;
    [SerializeField] protected float dropPowerUP;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //metodo de som do tiro
    protected void TocaTiro()
    {
        AudioSource.PlayClipAtPoint(somTiro, Vector3.zero);
    }
    // metodo de perder vida
    public void PerdeVida(int dano)
    {
        // so perde vida se o y for menor do q 5
        if (transform.position.y < 5.38f)
        {
            vida -= dano;

            if (vida <= 0)
            {
                Destroy(gameObject);

                Instantiate(explosao, transform.position, transform.rotation);
                if (powerUP)
                {
                    var chancePowerUP = Random.Range(0f, 1f);
                    if(chancePowerUP > dropPowerUP)
                    {
                        
                        GameObject pU = Instantiate(powerUP, transform.position, transform.rotation);
                        Destroy(pU, 3f);
                        
                        
                    }
                }
                // ganhando pontos
                var gerador = FindObjectOfType<GeradorInimigos>();
                if (gerador)
                {
                    gerador.GanhaPontos(pontos);
                }

            }
        }
    }

    // evento de quando se destruir
    private void OnDestroy() 
    {
        var gerador = FindObjectOfType<GeradorInimigos>();
        if (gerador)
        {
            gerador.DiminuiQuantidade();
        }
    }

    // metodo de se matar
    public void seMata()
    {
        if(transform.position.y < yDEAD | transform.position.x > xDEAD | transform.position.x < -xDEAD)
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
            var gerador = FindObjectOfType<GeradorInimigos>();
            gerador.GanhaPontos(pontos);
            var chancePowerUP = Random.Range(0f, 1f);
                if(chancePowerUP > dropPowerUP)
                {
                    
                    GameObject pU = Instantiate(powerUP, transform.position, transform.rotation);
                    Destroy(pU, 3f);
                    
                }
            Destroy(gameObject);
            // criando o impacto da batida
            Instantiate(explosao, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Escudo"))
        {
            Destroy(gameObject);
            Instantiate(explosao, transform.position, transform.rotation);
            var gerador = FindObjectOfType<GeradorInimigos>();
            gerador.GanhaPontos(pontos);
            var chancePowerUP = Random.Range(0f, 1f);
                if(chancePowerUP > dropPowerUP)
                {
                    
                    GameObject pU = Instantiate(powerUP, transform.position, transform.rotation);
                    Destroy(pU, 3f);
                    
                }

        }
    }
    

}
