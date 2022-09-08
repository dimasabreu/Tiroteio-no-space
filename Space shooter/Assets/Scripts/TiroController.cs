using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroController : MonoBehaviour
{
    private Rigidbody2D meuRB;
    [SerializeField] private float vel = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // rigidbody
        meuRB = GetComponent<Rigidbody2D>();
        // indo para cima
        meuRB.velocity = new Vector2(0f, vel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo01"))
        {
            // pegando o metodo perde vida e aplicando o dano
            collision.GetComponent<Inimigo01Controller>().PerdeVida(1);
        }
        // checando se eu colidi com o player
        if (collision.CompareTag("Jogador"))
        {
            collision.GetComponent<PlayerController>().PerdeVida(1);
        }
        Destroy(gameObject);
    }
}
