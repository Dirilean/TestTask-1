using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deleting : MonoBehaviour
{
    public static bool deleteMod = false;

    public void ChangeDeleteMod(Button buttonDeleteMod)
    {
        deleteMod = !deleteMod;
        if (deleteMod)
        {
            buttonDeleteMod.targetGraphic.color = buttonDeleteMod.colors.pressedColor;
        }
        else
        {
            buttonDeleteMod.targetGraphic.color = buttonDeleteMod.colors.normalColor;
        }
    }

    public void DeleteAll()
    {
        foreach (Rune rune in FindObjectsOfType<Rune>())
        {
            rune.Break();
        }
    }
}
