using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private Rigidbody2D meuRB;
    [SerializeField] private float velocidade = 5f;
    // iniciando o tiro
    [SerializeField] private GameObject meuTiro;
    // pegando a posição nova do tiro
    [SerializeField] private Transform posicaoTiro;
    // vida do player
    [SerializeField] private int vida = 3;
    // iniciando a explosao qnd morrer
    [SerializeField] private GameObject explosao;
    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // pegando o input horizontal
        float horizontal = Input.GetAxisRaw("Horizontal");
        // pegando o input vertical
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 minhaVelocidade = new Vector2(horizontal, vertical);
        // normalizando a velocidade diagonal
        minhaVelocidade = minhaVelocidade.normalized;
        // passando a velocidade para o rb
        meuRB.velocity = minhaVelocidade * velocidade;

        // testando o tiro
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(meuTiro, posicaoTiro.position, transform.rotation);
        }    
    }

    public void PerdeVida(int dano)
    {
        vida -= dano;
        // instanciando a explosao de destruição
        if(vida <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosao, transform.position, transform.rotation);
        }
    }
}
