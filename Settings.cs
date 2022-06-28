using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    GameObject menu;
    GameObject settings2;
    [SerializeField]
    private Slider volumeSlider;
    [SerializeField]
    private Slider sensitivitySlider;
    [SerializeField]
    Text volumeSliderText;
    [SerializeField]
    Text sensitivitySliderText;

    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("MainMenu");
        settings2 = GameObject.FindGameObjectWithTag("Settings");
        settings2.SetActive(false);
        LoadValuesOnStart();
    }
    void Update()
    {
        VolumeSliderValue();
        SensitivitySliderValue();
        IfValuesInPrefsNULL();
    }
    public void VolumeSliderValue()
    {
        float volumeValue = volumeSlider.value;
        volumeSliderText.text = volumeValue.ToString("0.0");
        
    }
    public void SensitivitySliderValue()
    {
        float sensitivityValue = sensitivitySlider.value;
        sensitivitySliderText.text = sensitivityValue.ToString("0.0");
    }
    public void BackToMainMenu()
    {
        menu.SetActive(true);
        settings2.SetActive(false);
    }

    public void Save()
    {
        float volumeValue = volumeSlider.value;
        float sensitivityValue = sensitivitySlider.value;
        PlayerPrefs.SetFloat("volumeValue", volumeValue);
        PlayerPrefs.SetFloat("sensitivityValue", sensitivityValue);
        LoadValues();
    }
    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("volumeValue");
        float sensitivityValue = PlayerPrefs.GetFloat("sensitivityValue");
        volumeSlider.value = volumeValue;
        sensitivitySlider.value = sensitivityValue;
        AudioListener.volume = volumeValue;
    }
    void LoadValuesOnStart()
    {
        float volumeValue = PlayerPrefs.GetFloat("volumeValue");
        float sensitivityValue = PlayerPrefs.GetFloat("sensitivityValue");
        volumeSlider.value = volumeValue;
        sensitivitySlider.value = sensitivityValue;
    }
    void IfValuesInPrefsNULL()
    {
        if (PlayerPrefs.HasKey("volumeValue"))
        {

        }
        else
        {
            volumeSliderText.text = "default";

        }
        if (PlayerPrefs.HasKey("sensitivityValue"))
        {

        }
        else
        {
            sensitivitySliderText.text = "default";

        }
    }
}

