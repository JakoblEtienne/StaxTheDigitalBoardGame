using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject startGameMenu;
    [SerializeField] GameObject rulesMenu;
    [SerializeField] GameObject rulesScrollViewEng;
    [SerializeField] GameObject rulesScrollViewDeu;
    [SerializeField] Text changeLanguageButton;
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] GameObject muteSound;
    [SerializeField] GameObject playSound;

    public void OnStartGame()
    {
        mainMenu.SetActive(false);
        startGameMenu.SetActive(true);

    }

    public void OnBackToMainMenu()
    {
        startGameMenu.SetActive(false);
        rulesMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnRules()
    {
        mainMenu.SetActive(false);
        rulesMenu.SetActive(true);
    }

    public void ChangeRulesLanguage()
    {
        if (rulesScrollViewEng.activeSelf)
        {
            rulesScrollViewDeu.SetActive(true);
            rulesScrollViewEng.SetActive(false);
            changeLanguageButton.text = "ENG";
        }
        else if (rulesScrollViewDeu.activeSelf)
        {
            rulesScrollViewEng.SetActive(true);
            rulesScrollViewDeu.SetActive(false);
            changeLanguageButton.text = "DE";
        }
    }

    public void ToggleSound()
    {
        if (muteSound.activeSelf)
        {
            backgroundMusic.Stop();
            muteSound.SetActive(false);
            playSound.SetActive(true);
        }
        else if (playSound.activeSelf)
        {
            backgroundMusic.Play();
            playSound.SetActive(false);
            muteSound.SetActive(true);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
