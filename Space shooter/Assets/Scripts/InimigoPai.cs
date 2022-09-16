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

}
