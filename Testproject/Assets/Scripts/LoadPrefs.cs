
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadPrefs : MonoBehaviour
{
    [Header("Volume Settings")]
    [SerializeField] private bool canUse = false;
    [SerializeField] private SettingsController SettingsController;

    [Header("Volume Settings")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;

    [Header("Brightness Settings")]
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private TMP_Text brightnessTextValue = null;

    [Header("Quality Level Settings")]
    [SerializeField] private TMP_Dropdown qualityDropdown;

    [Header("Fullscreen Settings")]
    [SerializeField] private Toggle FullScreenToggle;

    [Header("Sensitivity Settings")]
    [SerializeField] private TMP_Text controllerTextValue = null;
    [SerializeField] private Slider controllersenSlider = null;

    [Header("invert Y Settings")]
    [SerializeField] private Toggle invertYToggle = null;

    [Header("invert X Settings")]
    [SerializeField] private Toggle invertXToggle = null;

    private void Awake()
    {
        if (canUse)
        {
            if (PlayerPrefs.HasKey("masterVolume"))
            {
                float localVolume = PlayerPrefs.GetFloat("masterVolume");

                volumeTextValue.text = localVolume.ToString("0.0");
                volumeSlider.value = localVolume;
                AudioListener.volume = localVolume;
            }
            else
            {
                {
                    SettingsController.ResetButton("Audio");
                }
            }
            if (PlayerPrefs.HasKey("masterQuality"))
            {
                int localQuality = PlayerPrefs.GetInt("masterQuality");
                qualityDropdown.value = localQuality;
                QualitySettings.SetQualityLevel(localQuality);
            }
            if (PlayerPrefs.HasKey("masterFullscreen"))
            {
                int localFullscreen = PlayerPrefs.GetInt("masterFullscreen");

                if (localFullscreen == 1)
                {
                    Screen.fullScreen = true;
                    FullScreenToggle.isOn = true;
                }
                else
                {
                    Screen.fullScreen = false;
                    FullScreenToggle.isOn = false;
                }
            }
            if (PlayerPrefs.HasKey("masterBrightness"))
            {
                float localBrightness = PlayerPrefs.GetFloat("masterBrightness");

                brightnessTextValue.text = localBrightness.ToString("0.0");
                brightnessSlider.value = localBrightness;
                //change the brightness settings here as well
            }
            if (PlayerPrefs.HasKey("masterSen"))
            {
                float localSensitivity = PlayerPrefs.GetFloat("masterSen");

                controllerTextValue.text = localSensitivity.ToString("0");
                controllersenSlider.value = localSensitivity;
                SettingsController.mainControllerSen = Mathf.RoundToInt(localSensitivity);
            }
            if (PlayerPrefs.HasKey("masterInvertY"))
            {
                if (PlayerPrefs.GetInt("masterInvertY") == 1)
                {
                    invertYToggle.isOn = true;
                }
                else
                {
                    invertYToggle.isOn = false;
                }
            }
            if (PlayerPrefs.HasKey("masterInvertX"))
            {
                if (PlayerPrefs.GetInt("masterInvertX") == 1)
                {
                    invertXToggle.isOn = true;
                }
                else
                {
                    invertXToggle.isOn = false;
                }
            }
        }
    }
}