using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo01Controller : MonoBehaviour
{   // pegando o rb
    private Rigidbody2D meuRB;
    [SerializeField] private float velocidade = -3f;
    // meu tiro
    [SerializeField] private GameObject meuTiro;
    // delay do tiro
    private float esperaTiro = 1f;
    // Start is called before the first frame update
    void Start()
    {
        // pegnado o rb
        meuRB = GetComponent<Rigidbody2D>();
        // colocando a velocidade no rb
        meuRB.velocity = new Vector2(0f, velocidade);
    }

    // Update is called once per frame
    void Update()
    {
        // diminuir a espera
        esperaTiro -= Time.deltaTime;
        if (esperaTiro <= 0)
        {
            // Instanciando o tiro
            Instantiate(meuTiro, transform.position, transform.rotation);
            // reiniciando o tiro
            esperaTiro = 1f;
        }
        
    }
}
