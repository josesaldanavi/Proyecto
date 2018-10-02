using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Pausa_script : MonoBehaviour {
    bool activado;
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdowm;
    Resolution[] resolutions;
   public static Canvas canvas;
	// Use this for initialization
	void Start () {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        resolutions = Screen.resolutions;

        resolutionDropdowm.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width==Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdowm.AddOptions(options);
        resolutionDropdowm.value = currentResolutionIndex;
        resolutionDropdowm.RefreshShownValue();
	}
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            activado = !activado;
            canvas.enabled = activado;
            Time.timeScale = (activado) ? 0 : 1f;
        }
	}
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);   
    }

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }   

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
