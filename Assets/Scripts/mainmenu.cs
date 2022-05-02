using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class mainmenu : MonoBehaviour
{
    
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI platformSizeText;

    public Slider volSlider;
    public Slider speedSlider;
    private void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        volSlider.value = PlayerPrefs.GetFloat("Volume", 1);
        speedSlider.value = PlayerPrefs.GetFloat("SpawnerSpeed", 2);

        switch (PlayerPrefs.GetInt("PlatformSize", 2))
        {
            case 1:
                {
                    platformSizeText.text = "Platform Size: Small";
                    break;
                }

            case 2:
                {
                    platformSizeText.text = "Platform Size: Normal";
                    break;
                }

            case 3:
                {
                    platformSizeText.text = "Platform Size: Large";
                    break;
                }

            default:
                {
                    platformSizeText.text = "Platform Size: Normal";
                    break;
                }
        }
    }

    public void updateVolume()
    {
        PlayerPrefs.SetFloat("Volume", volSlider.value);
    }

    public void updateSpawnerSpeed(float newVal)
    {
        PlayerPrefs.SetFloat("SpawnerSpeed", newVal);
    }

    public void updatePlatformSize(int sizeIndex)
    {
        PlayerPrefs.SetInt("PlatformSize", sizeIndex);
        switch (sizeIndex)
        {
            case 1:
                {
                    platformSizeText.text = "Platform Size: Small";
                    break;
                }

            case 2:
                {
                    platformSizeText.text = "Platform Size: Normal";
                    break;
                }

            case 3:
                {
                    platformSizeText.text = "Platform Size: Large";
                    break;
                }

            default:
                {
                    platformSizeText.text = "Platform Size: Normal";
                    break;
                }
        }
    }

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
