using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoOption : MonoBehaviour
{
    public static VideoOption Instance;
    FullScreenMode screenMode;
    public Dropdown resolutionDropdown;
    public Toggle fullscreenBtn;
    List<Resolution> resolutions = new List<Resolution>();
    public int resolutionNum;
    // 사용자 컴퓨터에서 받아오는 드롭다운 메뉴 생성
    void InitUI()
    {
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            resolutions.Add(Screen.resolutions[i]);
        }
        resolutionDropdown.options.Clear();

        int optionNum = 0;
        foreach (Resolution item in resolutions)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = item.width + "x" + item.height + " " + item.refreshRateRatio + "hz";
            resolutionDropdown.options.Add(option);

            if(item.width == Screen.width && item.height == Screen.height)
                resolutionDropdown.value = optionNum;
            optionNum++;
        }
        resolutionDropdown.RefreshShownValue();

        fullscreenBtn.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow)?true:false;
    }
    public void DropboxOptionChange(int x)
    {
        resolutionNum = x;
    }
    public void FullScreenBtn(bool isFull)
    {
        screenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }
    public void ApplyBtnClick()
    {
        Screen.SetResolution(resolutions[resolutionNum].width,resolutions[resolutionNum].height,screenMode);
    }
    void Start()
    {
        Instance = this;
        InitUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
