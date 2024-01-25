using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventHandler 
{
    public static event Action<string> UpdateInventoryUI;
    public static void CallUpdateInventoryUI(string sceneName)
    {
        UpdateInventoryUI?.Invoke(sceneName);
    }

    // 对话
    public static event Action ShowNextDialogueEvent;
    public static void CallShowNextDialogueEvent()
    {
        ShowNextDialogueEvent?.Invoke();
    }

    // 选项
    public static event Action<bool> ShowOptionEvent;
    public static void CallShowOptionEvent(bool isLeft)
    {
        ShowOptionEvent?.Invoke(isLeft);
    }
    public static event Action<bool> HideOptionEvent;
    public static void CallHideOptionEvent(bool isLeft)
    {
        HideOptionEvent?.Invoke(isLeft);
    }

    // 选择选项
    public static event Action<bool> SelectOptionEvent;
    public static void CallSelectOptionEvent(bool isLeft)
    {
        SelectOptionEvent?.Invoke(isLeft);
    }

    // 渐隐
    public static event Action<float> FadeInEvent;
    public static void CallFadeInEvent(float duration)
    {
        FadeInEvent?.Invoke(duration);
    }
    // 渐现
    public static event Action<float> FadeOutEvent;
    public static void CallFadeOutEvent(float duration)
    {
        FadeOutEvent?.Invoke(duration);
    }
}