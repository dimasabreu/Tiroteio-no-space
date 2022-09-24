using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{   
    private Rigidbody2D meuRB;
    [SerializeField] private float velocidade = 5f;
    // iniciando o tiro
    [SerializeField] private GameObject meuTiro;
    [SerializeField] private GameObject meuTiro2;
    // pegando o escudo
    [SerializeField] private GameObject meuEscudo;
    private GameObject escudoAtual;
    // pegando a posição nova do tiro
    [SerializeField] private Transform posicaoTiro;
    // vida do player
    [SerializeField] private int vida = 3;
    // escudos
    [SerializeField] private int escudo = 3;
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

    [SerializeField] public int levelTiro = 1;
    [SerializeField] private Text vidaTexto;
    [SerializeField] private Text escudoTexto;
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();
        vidaTexto.text = vida.ToString();
        escudoTexto.text = escudo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Movendo();
        Atirando();
        SaindoTela();
        Escudo();
        
    }

    private void Atirando()
    {
        if(levelTiro == 1)
        {
            if (Input.GetButton("Fire1"))
            {
                esperaTiro -= Time.deltaTime;
                if (esperaTiro <= 0)
                {
                    CriaTiro(meuTiro, posicaoTiro.position);
                }
            }
            if (Input.GetButtonUp("Fire1"))
            {
                CriaTiro(meuTiro, posicaoTiro.position);
            }
        }
        if(levelTiro == 2)
        {
            if (Input.GetButton("Fire1"))
            {
                esperaTiro -= Time.deltaTime;
                if (esperaTiro <= 0)
                {
                    // criando 2 tiros nas asas
                    Vector3 posicaoe = new Vector3(transform.position.x - 0.45f, transform.position.y + 0.1f, 0f);
                    Vector3 posicaod = new Vector3(transform.position.x + 0.45f, transform.position.y + 0.1f, 0f);
                    CriaTiro(meuTiro2, posicaoe);
                    CriaTiro(meuTiro2, posicaod);
                }
            }
            if (Input.GetButtonUp("Fire1"))
            {
                Vector3 posicaoe = new Vector3(transform.position.x - 0.45f, transform.position.y + 0.1f, 0f);
                Vector3 posicaod = new Vector3(transform.position.x + 0.45f, transform.position.y + 0.1f, 0f);
                CriaTiro(meuTiro2, posicaoe);
                CriaTiro(meuTiro2, posicaod);
            }
        }
         if(levelTiro == 3)
        {
            if (Input.GetButton("Fire1"))
            {
                esperaTiro -= Time.deltaTime;
                if (esperaTiro <= 0)
                {
                    // criando 2 tiros nas asas
                    Vector3 posicaoe = new Vector3(transform.position.x - 0.45f, transform.position.y + 0.1f, 0f);
                    Vector3 posicaod = new Vector3(transform.position.x + 0.45f, transform.position.y + 0.1f, 0f);
                    CriaTiro(meuTiro, posicaoTiro.position);
                    CriaTiro(meuTiro2, posicaoe);
                    CriaTiro(meuTiro2, posicaod);
                }
            }
            if (Input.GetButtonUp("Fire1"))
            {
                Vector3 posicaoe = new Vector3(transform.position.x - 0.45f, transform.position.y + 0.1f, 0f);
                Vector3 posicaod = new Vector3(transform.position.x + 0.45f, transform.position.y + 0.1f, 0f);
                CriaTiro(meuTiro, posicaoTiro.position);
                CriaTiro(meuTiro2, posicaoe);
                CriaTiro(meuTiro2, posicaod);
            }
        }
        

    }

    private void CriaTiro(GameObject tiroCriado, Vector3 posicao)
    {
        GameObject tiro = Instantiate(tiroCriado, posicao, transform.rotation);
        //direção e velo do tiro
        tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, velocidadeTiro);
        esperaTiro = (0.1f);
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

    private void Escudo()
    {
        
        if (Input.GetButtonDown("Shield") && escudo > 0)
        {
            // Instanciando o escudo
            
            if (!escudoAtual)
            {
                escudoAtual = Instantiate(meuEscudo, transform.position, transform.rotation);
                Destroy(escudoAtual, 3.2f);
                escudo--;
                escudoTexto.text = escudo.ToString();
            }
                
        }
        if (escudoAtual)
            {
                escudoAtual.transform.position = transform.position;
            }
        
        
    }



    public void PerdeVida(int dano)
    {
        vida -= dano;

        //atualizando a vida 
        vidaTexto.text = vida.ToString();
        // instanciando a explosao de destruição
        if(vida <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosao, transform.position, transform.rotation);
        }
    }

    
    public void Upando(int xp)
    {
        if (levelTiro < 3)
        {
            levelTiro += xp;
        }
        else
        {
            escudo += xp;
            escudoTexto.text = escudo.ToString();
        }    
    }

    public void Curando(int cura)
    {
        vida += cura;
        vidaTexto.text = vida.ToString();
    }

    public void ganhaVelo(float velo)
    {
        velocidade += velo;
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

