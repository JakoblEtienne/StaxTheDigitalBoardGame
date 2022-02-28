using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinnerDisplay : MonoBehaviour
{
    public Text winnerText;

    public void OnBackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
