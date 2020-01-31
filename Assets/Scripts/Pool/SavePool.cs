using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePool : MonoBehaviour
{
    public Button SaveButton;
    public GameObject SaveReaction;
    [Space]
    public Button LoadButton;

    IEnumerator saveReactionCorutine;

    private void Awake()
    {
        SaveReaction.SetActive(false);
        SaveButton.onClick.AddListener(() => Saving());
        LoadButton.onClick.AddListener(() => Loading());
    }

    [ContextMenu("Saving")]
    public void Saving()
    {
        Data data = new Data();
        for (int i = 0; i <Pool.instance.poolingObjects.Length; i++)
        {
            SavingData temp = new SavingData();
            temp.name = Pool.instance.poolingObjects[i].name;
            temp.pos = new List<Vector3>();
            for (int t = 0; t < Pool.instance.poolingObjects[i].listPoolObjects.Count; t++)
            {
                if (Pool.instance.poolingObjects[i].listPoolObjects[t].gameObject.activeInHierarchy)
                {
                    temp.pos.Add(Pool.instance.poolingObjects[i].listPoolObjects[t].transform.position);
                }
            }
            data.data.Add(temp);
        }
        PlayerPrefs.SetString("data", JsonUtility.ToJson(data));
        print(PlayerPrefs.GetString("data"));
        if (saveReactionCorutine != null) StopCoroutine(saveReactionCorutine);
        saveReactionCorutine = ShowSaveReaction();
        StartCoroutine(saveReactionCorutine);
    }
    
    IEnumerator ShowSaveReaction()
    {
        SaveReaction.SetActive(true);
        yield return new WaitForSeconds(1f);
        SaveReaction.SetActive(false);
    }

    [ContextMenu("Loading")]
    public void Loading()
    {
        Pool.instance.ReturnAllToPool();
        Data data = new Data();
        data = (Data)JsonUtility.FromJson(PlayerPrefs.GetString("data"), typeof(Data));
        for (int i = 0; i < data.data.Count; i++)
        {
            for (int t = 0; t < data.data[i].pos.Count; t++)
            {
                Pool.instance.GetObject(data.data[i].name, data.data[i].pos[t]);
            }
        }
    }



    [System.Serializable]
    public class Data
    {
        public List<SavingData> data = new List<SavingData>();
    }
    [System.Serializable]
    public class SavingData
    {
        public string name;
        public List<Vector3> pos = new List<Vector3>();
    }
}
