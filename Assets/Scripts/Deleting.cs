using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deleting : MonoBehaviour
{
    public static bool deleteMod = false;

    public Button DeleteAnyButton;
    public Button DeleteAllButton;

    private void Start()
    {
        DeleteAnyButton.onClick.AddListener(()=>ChangeDeleteMod());
        DeleteAllButton.onClick.AddListener(()=>DeleteAll());
    }

    public void ChangeDeleteMod()
    {
        deleteMod = !deleteMod;
        if (deleteMod)
        {
            DeleteAnyButton.targetGraphic.color = DeleteAnyButton.colors.pressedColor;
        }
        else
        {
            DeleteAnyButton.targetGraphic.color = DeleteAnyButton.colors.normalColor;
        }
    }

    public void DeleteAll()
    {
        if (deleteMod) ChangeDeleteMod();

        foreach (Rune rune in FindObjectsOfType<Rune>())
        {
            rune.Break();
        }

        AudioManager.instance.PlaySoundOfBreak();
    }
}
