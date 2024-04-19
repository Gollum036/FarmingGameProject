using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
   [SerializeField] private string nomeDoLevelDeJogo;
   [SerializeField] private GameObject painelMenuInicial;
   [SerializeField] private GameObject painelOption;

    public void Start()
    {
        SceneManager.LoadScene("AlienGame");
    }

    public void OpenOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOption.SetActive(true);

    }

    public void CloseOption()
    {
        painelOption.SetActive(false);
        painelMenuInicial.SetActive(true);

    }
    public void LeaveGame()
    {
        Debug.Log("Leave the Game");
        Application.Quit();

    }
}

