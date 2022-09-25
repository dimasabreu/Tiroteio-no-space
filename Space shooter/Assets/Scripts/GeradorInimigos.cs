using UnityEngine;
using UnityEngine.UI;

public class GeradorInimigos : MonoBehaviour
{
    // pegando os inimigos que vão ser criados
    [SerializeField] private GameObject[] inimigos;

    // pegando os pontos q os inimigos dao
    [SerializeField] private int pontos = 0;

    // level
    [SerializeField] public int level = 1;

    // tanto para lvl up
    [SerializeField] private float levelUp = 100;

    // quantidade de inimigos
    [SerializeField] private int qtdInimigo = 0;

    private float esperaInimigo = 0f;
    [SerializeField] private float tempoEspera = 5f;

    // criando o bg
    [SerializeField] private GameObject[] fundo;
    private int qtdFundo = 0;

    //criando o boss
    [SerializeField] private GameObject bossAnimation;
    private bool animacaoBoss = false;
    private GameObject animBoss;
    
    // acessando os inimigos
    public Inimigo01Controller Inimigo01script;
    public Inimigo02controller Inimigo02script;

    // colocando os pontos na tela
    [SerializeField] private Text pontuacaoTexto;

    // Start is called before the first frame update
    void Start()
    {
        pontuacaoTexto.text = pontos.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        pontuacaoTexto.text = pontos.ToString();
        if (level < 10)
        {
            GeraInimigos();
        }
        else
        {
            criaBoss();
        }
        
    }

    public void GanhaPontos(int pontos)
    {
        this.pontos += pontos * level;
        if(this.pontos > levelUp)
        {
            level++;
            levelUp *= 2;
        }
    }




    // checando a quantidade de inimigos
    public void DiminuiQuantidade()
    {
        qtdInimigo--;
    }

    private void GeraInimigos()
    {
        // diminuindo o tempo de espera
        if (esperaInimigo > 0)
        {
            esperaInimigo -= Time.deltaTime;
        }
        // checando o tempo de espera
        if (esperaInimigo <= 0f && qtdInimigo <= 0)
        {
            int quantidade = level * 4;
            
            // criando varios inimigos
            while(qtdInimigo < quantidade)
            {
                GameObject inimigoCriado;
                // dicidindo qual inimigo criar
                float chance = Random.Range(0f, level);
                if (chance < 2f)
                {
                    inimigoCriado = inimigos[0];
                    Inimigo01script.vida = 1;
                    if (level == 4)
                    {
                        Inimigo01script.vida = 2;
                    }
                    if (level >= 5)
                    {
                        Inimigo01script.vida = 3;
                    }
                }
                else
                {
                    inimigoCriado = inimigos[1];
                    Inimigo02script.vida = 1;
                    if (level == 5)
                    {
                        Inimigo02script.vida = 2;
                    }
                    if (level >= 6)
                    {
                        Inimigo02script.vida = 3;
                    }
                }

                // posiccao do inimigo
                Vector3 posicao = new Vector3(Random.Range(-8.4f, 8.40f), Random.Range(6f, 17f), 0f);
                // criando o inimigo
                Instantiate(inimigoCriado, posicao, transform.rotation);
                qtdInimigo++;

                // reiniciando a espera
                esperaInimigo = tempoEspera;
            }
        }
    }


    private void criaBoss()
    {
        if ( qtdInimigo <= 0 && tempoEspera > 0)
        {
            tempoEspera -= Time.deltaTime;
        }

        
        if(!animacaoBoss && tempoEspera <= 0)
        {
            animBoss = Instantiate(bossAnimation, Vector3.zero, transform.rotation);
            animacaoBoss = true;
            
        }
        
    }

}
