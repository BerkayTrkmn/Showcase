using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    //Change Level number to test
    [Header("Change For Different Level")]
    public int levelNumber;
    public Camera mainCamera;
    public Text conditionText;
    public List<LevelObject> levelList;

    private void Start()
    {
        InitiateLevel(levelList[levelNumber]);
    }
    public void InitiateLevel(LevelObject level)
    {
        mainCamera.backgroundColor = level.cameraColor;
        conditionText.text = level.winCondition.ToString();
        Instantiate(level.levelPrefab);
    }
}
public enum WinCondition
{
    ClearAllArea,
    ClearArea,
}

