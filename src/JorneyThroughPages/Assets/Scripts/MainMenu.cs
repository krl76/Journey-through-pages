using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Toggle = UnityEngine.UI.Toggle;

public class MainMenu : MonoBehaviour
{
    [Header("Main Settings")] 
    [SerializeField] private string _nameOfGameScene;
    [SerializeField] private TMP_Dropdown _resolution;
    [SerializeField] private TMP_Dropdown _quality;
    [SerializeField] private Slider _volumeEffect;
    [SerializeField] private Slider _volumeMusic;
    [SerializeField] private Toggle _fullScreenToggle;
    [SerializeField] private TMP_InputField _sensevity;

    [Header("Settings of sound")] 
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _nameOfMusicGroup;
    [SerializeField] private string _nameOfSFXGroup;
    
    private Resolution[] resolutions;
    private int currentResolutionIndex;
    
    private void Start()
    {
        _resolution.ClearOptions();
        resolutions = Screen.resolutions;
        
        List<string> options = new List<string>();
        currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + Math.Round(resolutions[i].refreshRateRatio.value) +
                            "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        
        _resolution.AddOptions(options);
        _resolution.RefreshShownValue();
        LoadSettings();
    }
    
    public void SetFullScreen()
    {
        Screen.fullScreen = _fullScreenToggle.isOn;
    }

    public void SetResolution()
    {
        Resolution resolution = resolutions[_resolution.value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(_quality.value);
    }

    public void IfNumber()
    {
        float number;
        bool success = float.TryParse(_sensevity.text, out number);
        if (!success)
        {
            _sensevity.text = "1,0";
        }
    }

    public void SetMusicVolume()
    {
        _audioMixer.SetFloat(_nameOfMusicGroup, Mathf.Log10(_volumeMusic.value)*20);
    }
    
    public void SetSFXVolume()
    {
        _audioMixer.SetFloat(_nameOfSFXGroup, Mathf.Log10(_volumeEffect.value)*20);
    }
    
    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettings", _quality.value);
        PlayerPrefs.SetInt("ResolutionSettings", _resolution.value);
        PlayerPrefs.SetInt("FullScreenSettings", Convert.ToInt32(_fullScreenToggle.isOn));
        PlayerPrefs.SetFloat("VolumeEffectsSettings", _volumeEffect.value);
        PlayerPrefs.SetFloat("VolumeMusicSettings", _volumeMusic.value);
        PlayerPrefs.SetFloat("SensevitySettings", float.Parse(_sensevity.text));
    }
    
    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("QualitySettings"))
        {
            _quality.value = PlayerPrefs.GetInt("QualitySettings");
        }
        else
            _quality.value = 3;
        if (PlayerPrefs.HasKey("ResolutionSettings"))
        {
            _resolution.value = PlayerPrefs.GetInt("ResolutionSettings");
        }
        else
            _resolution.value = currentResolutionIndex;
        if (PlayerPrefs.HasKey("FullScreenSettings"))
        {
            _fullScreenToggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("FullScreenSettings"));
            Screen.fullScreen = _fullScreenToggle.isOn;
        }
        else
        {
            _fullScreenToggle.isOn = true;
            Screen.fullScreen = true;
        }

        if (PlayerPrefs.HasKey("VolumeEffectsSettings"))
        {
            _volumeEffect.value = PlayerPrefs.GetFloat("VolumeEffectsSettings");
            SetSFXVolume();
        }
        else
        {
            _volumeEffect.value = 1f;
            SetSFXVolume();
        }
        if (PlayerPrefs.HasKey("VolumeMusicSettings"))
        {
            _volumeMusic.value = PlayerPrefs.GetFloat("VolumeMusicSettings");
            SetMusicVolume();
        }
        else
        {
            _volumeMusic.value = 1f;
            SetMusicVolume();
        }
        if (PlayerPrefs.HasKey("SensevitySettings"))
            _sensevity.text = Convert.ToString(PlayerPrefs.GetFloat("SensevitySettings"));
        else
            _sensevity.text = "1,0";
    }

    public void Audio()
    {
        _audioSource.Play();
    }
    
    public void StartGame()
    {
        //FindObjectOfType<LoadScreen>().LoadLevel(_nameOfGameScene);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
