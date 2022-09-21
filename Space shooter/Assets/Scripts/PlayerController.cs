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
    // velocidade do tiro 
    [SerializeField] private float velocidadeTiro = 10f;
    // iniciando a explosao qnd morrer
    [SerializeField] private GameObject explosao;

    // delay do tiro
    [SerializeField] public float esperaTiro = 0f;
    // Start is called before the first frame update
    [SerializeField] private float xMin;
    [SerializeField] private float xMax;
    [SerializeField] private float yMin;
    [SerializeField] private float yMax;

    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movendo();
        Atirando();
        SaindoTela();
    }

    private void Atirando()
    {
        if (Input.GetButton("Fire1"))
        {
            esperaTiro -= Time.deltaTime;
            if (esperaTiro <= 0)
            {
                var tiro = Instantiate(meuTiro, posicaoTiro.position, transform.rotation);
                //direção e velo do tiro
                tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, velocidadeTiro);
                esperaTiro = (0.1f);
            }
        }
        // testando o tiro
        if (Input.GetButtonUp("Fire1"))
        {
            var tiro = Instantiate(meuTiro, posicaoTiro.position, transform.rotation);
            //direção e velo do tiro
            tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, velocidadeTiro);
        }
        
    }

    private void Movendo()
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
    public void SaindoTela()
    {
        if(gameObject.transform.position.x < xMin)
            {
                var yAtual = gameObject.transform.position.y;
                gameObject.transform.position = new Vector3(xMax, yAtual, 0f);
            }
        if(gameObject.transform.position.x > xMax)
            {
                var yAtual = gameObject.transform.position.y;
                gameObject.transform.position = new Vector3(xMin, yAtual, 0f);
            }
        if(gameObject.transform.position.y < yMin)
            {
                var xAtual = gameObject.transform.position.x;
                gameObject.transform.position = new Vector3(xAtual, yMax, 0f);
            }
        if(gameObject.transform.position.y > yMax)
            {
                var xAtual = gameObject.transform.position.x;
                gameObject.transform.position = new Vector3(xAtual, yMin, 0f);
            }
    }
}

