using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SettingData
{
    public enum Resolution
    {
        p1440,
        p1080,
        p720,
        p360
    }

    public Resolution resolution;
    public FullScreenMode screenMode;

    public SettingData()
    {
        resolution = Resolution.p1080;
        screenMode = FullScreenMode.ExclusiveFullScreen;
    }
}
