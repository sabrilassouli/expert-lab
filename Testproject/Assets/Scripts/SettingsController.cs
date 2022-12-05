using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SettingsController : MonoBehaviour
{
    //
    [Header("Volume Settings")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 1.0f;

    [Header("Gameplay Settings")]
    [SerializeField] private TMP_Text controllerTextValue = null;
    [SerializeField] private Slider controllersenSlider = null;
    [SerializeField] private float defaultSen = 4;
    public int mainControllerSen = 4;

    [Header("Toggle Settings")]
    [SerializeField] private Toggle invertYToggle = null;
    [SerializeField] private Toggle invertXToggle = null;

    [Header("Graphics Settings")]

    [SerializeField] private TMP_Text brightnessTextValue = null;
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private float defaultBrightness = 1;

    [Space(10)]
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private Toggle FullScreenToggle;

    private int _qualityLevel;
    private bool _isFullScreen;
    private float _brightnessLevel;

    [Header("Confirmation")]
    [SerializeField] private GameObject confirmationPrompt = null;

    [Header("Levels To Load")]
    public string _newGameLevel;
    private string levelToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;

    [Header("Resolution Dropdowns")]
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            Debug.Log("QUIT GAME");
        }

    }

    public void SetResolution(int resoltionIndex)
    {
        Resolution resolution = resolutions[resoltionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }

    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    //if player clicks yes load game
    public void LoadGameDialogYes()
    {
        //does player have file called saved level
        if (PlayerPrefs.HasKey("savedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            noSavedGameDialog.SetActive(true);
        }
    }
    // turns game off
    public void ExitButton()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        //show Prompt
        StartCoroutine(ConfirmationBox());
    }

    //will have to incorporate in my controls script later
    public void SetControllerSen(float sensitivity)
    {
        mainControllerSen = Mathf.RoundToInt(sensitivity);
        controllerTextValue.text = sensitivity.ToString("0");
    }


    //will have to incorporate in my controls script later
    public void GameplayApply()
    {
        if (invertYToggle.isOn)
        {
            PlayerPrefs.SetInt("masterInvertY", 1);
        }
        else
        {
            PlayerPrefs.SetInt("masterInvertY", 0);
        }
        if (invertXToggle.isOn)
        {
            PlayerPrefs.SetInt("masterInvertX", 1);
        }
        else
        {
            PlayerPrefs.SetInt("masterInvertX", 0);
        }
        PlayerPrefs.SetFloat("masterSen", mainControllerSen);
        StartCoroutine(ConfirmationBox());

    }

    public void SetBrightness(float brightness)
    {
        _brightnessLevel = brightness;
        brightnessTextValue.text = brightness.ToString("0.0");

    }

    public void SetFullscreen(bool isFullscreen)
    {
        _isFullScreen = isFullscreen;
    }

    public void SetQuality(int qualityIndex)
    {
        _qualityLevel = qualityIndex;
    }

    public void GraphicsApply()
    {
        PlayerPrefs.SetFloat("masterBrightness", _brightnessLevel);
        // will need to add a way to change brightness level here if i have the time

        PlayerPrefs.SetInt("masterQuality", _qualityLevel);
        QualitySettings.SetQualityLevel(_qualityLevel);

        PlayerPrefs.SetInt("masterFullscreen", (_isFullScreen ? 1 : 0));
        Screen.fullScreen = _isFullScreen;

        StartCoroutine(ConfirmationBox());
    }

    public void ResetButton(string MenuType)
    {
        if (MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeTextValue.text = defaultVolume.ToString("0.0");
            VolumeApply();
        }
        if (MenuType == "Gameplay")
        {
            controllerTextValue.text = defaultSen.ToString("0.0");
            controllersenSlider.value = defaultSen;
            invertYToggle.isOn = false;
            invertXToggle.isOn = false;
            GameplayApply();
        }
        if (MenuType == "Graphics")
        {
            brightnessSlider.value = defaultBrightness;
            brightnessTextValue.text = defaultBrightness.ToString("0.0");

            qualityDropdown.value = 1;
            QualitySettings.SetQualityLevel(1);

            FullScreenToggle.isOn = false;
            Screen.fullScreen = false;

            Resolution currentResolution = Screen.currentResolution;
            Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);
            resolutionDropdown.value = resolutions.Length;
            GraphicsApply();
        }
    }

    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);

    }

}