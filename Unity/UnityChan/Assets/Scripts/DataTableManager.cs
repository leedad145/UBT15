using UnityEngine;
using System.Collections.Generic;

public class DataTableManager : MonoBehaviour
{
    private List<ChapterData> chapterDataTable = new();


    private void Start()
    {
        Init();
    }


    private void Init()
    {
        LoadChapterDataTable();
    }

    private void LoadChapterDataTable()
    {
        var parseDataTable = CSVReader.Read("Data/ChapterDataTable");
        foreach (Dictionary<string, object> data in parseDataTable)
        {
            ChapterData chapterData = new();
            
            chapterData.chapterNo = (int)data["chapterNo"];
            chapterData.totalStages = (int)data["totalStages"];
            chapterData.chapterRewardGem = (int)data["chapterRewardGem"];
            chapterData.chapterRewardGold = (int)data["chapterRewardGold"];

            chapterDataTable.Add(chapterData);
        }
    }
}

public class ChapterData
{
    public int chapterNo;
    public int totalStages;
    public int chapterRewardGem;
    public int chapterRewardGold;
}