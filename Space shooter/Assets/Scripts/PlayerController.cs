using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private Rigidbody2D meuRB;
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private GameObject meuTiro;

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
            Instantiate(meuTiro, transform.position, transform.rotation);
        }    
    }
}
