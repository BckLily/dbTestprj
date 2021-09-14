using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour
{
    // 임시 텍스트
    public Text dataText;

    Dictionary<string, string> classDict;

    PlayerClass.ePlayerClass testPlayerClass;

    private void Start()
    {
        classDict = new Dictionary<string, string>();
        testPlayerClass = PlayerClass.ePlayerClass.Soldier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            testPlayerClass = PlayerClass.ePlayerClass.Soldier;
            OnGetClassBtnClick();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            testPlayerClass = PlayerClass.ePlayerClass.Medic;
            OnGetClassBtnClick();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            testPlayerClass = PlayerClass.ePlayerClass.Engineer;
            OnGetClassBtnClick();
        }
    }

    public void OnGetClassBtnClick()
    {
        
        classDict = DBManager.Instance.GetClassInfo(testPlayerClass);

        var keys = classDict.Keys;

        dataText.text = "";

        foreach(var key in keys)
        {
            dataText.text += key.ToString() + ": " + classDict[key].ToString() + "\n";
        }
    }

}
