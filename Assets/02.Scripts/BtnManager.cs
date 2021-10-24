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
    string testPlayerWeapon;

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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            testPlayerWeapon = "010000000";
            OnGetWeaponBtnClick();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            testPlayerWeapon = "010000001";
            OnGetWeaponBtnClick();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            testPlayerWeapon = "010000002";
            OnGetWeaponBtnClick();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            testPlayerWeapon = "010010000";
            OnGetWeaponBtnClick();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            testPlayerWeapon = "010010001";
            OnGetWeaponBtnClick();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            testPlayerWeapon = "010010002";
            OnGetWeaponBtnClick();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            testPlayerWeapon = "010020000";
            OnGetWeaponBtnClick();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            testPlayerWeapon = "010020001";
            OnGetWeaponBtnClick();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            testPlayerWeapon = "010020002";
            OnGetWeaponBtnClick();
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

    public void OnGetWeaponBtnClick()
    {
        classDict = DBManager.Instance.GetWeaponInfo(testPlayerWeapon);

        var keys = classDict.Keys;

        dataText.text = "";

        foreach (var key in keys)
        {
            dataText.text += key.ToString() + ": " + classDict[key].ToString() + "\n";
        }

    }





}
