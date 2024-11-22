using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Para trabalhar com o TextMeshPro


public class PlantioTerreno : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject arvorePrefab; // Prefab da árvore a ser plantada
    public TextMeshProUGUI pontuacaoTexto; // Texto para exibir a pontuação
    public TextMeshProUGUI sementesTexto; // Texto para exibir o número de sementes
    public AudioSource treePlantingSound; // Referência ao som de plantio
    public int sementes = 10; // Número inicial de sementes
    public int totalArvoresParaVencer = 10; // Número necessário de árvores para vencer
    public TextMeshProUGUI textoVitoria; // Texto para exibir a mensagem de vitória

    private int pontuacao = 0; // Armazena a pontuação atual

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && sementes > 0) // Garante que só acontece no clique do mouse
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject) // Confirma que está clicando no terreno
            {
                Instantiate(arvorePrefab, mousePos, Quaternion.identity); // Planta a árvore

                sementes -= 1; //Reduz uma semente
                sementesTexto.text = "Sementes: " + sementes; // Atualiza o texto das sementes

                pontuacao += 1; // Incrementa a pontuação
                pontuacaoTexto.text = "Pontuação: " + pontuacao; // Atualiza o texto
                
                treePlantingSound.Play(); // Reproduz o som de plantio
                if (pontuacao >= totalArvoresParaVencer)
                {
                    Vitoria();
                }

            }
        }
    }

    // Método para exibir a mensagem de vitória
    void Vitoria()
    {
        textoVitoria.text = "Parabéns! Você venceu!";
        Debug.Log("Você venceu!"); // Apenas para verificar no console
    }

}
