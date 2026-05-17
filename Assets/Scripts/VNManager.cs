using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class VNManager : MonoBehaviour
{
    public TextMeshProUGUI SpeakerName;
    public TextMeshProUGUI SpeakingContent;

    private string filePath = Constants.STORY_PATH;
    private List<ExcelReader.ExcelData> storyData;
    private int currentLine = 0;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadStoryFromFile(filePath);
        DisplayNextLine();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DisplayNextLine();
        }
    }


    void LoadStoryFromFile(string path)
{
    storyData = ExcelReader.ReadExcel(path);
    if (storyData == null || storyData.Count == 0)
    {
        Debug.LogError("No Data Found In The FIle!");
    }

}


void DisplayNextLine()
{
    if(currentLine >= storyData.Count)
    {
        Debug.Log("End of Story");
        return;
    }
    var data = storyData[currentLine];
    SpeakerName.text = data.Speaker;
    SpeakingContent.text = data.Content;
    currentLine++;

}

}


