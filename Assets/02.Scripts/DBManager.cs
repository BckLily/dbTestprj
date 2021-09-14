using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerClass;
using SimpleJSON;
using System;
using UnityEngine.UI;
using System.IO;
using LitJson;


public class DBManager : MonoBehaviour
{
    private static DBManager instance = null;
    public static DBManager Instance { get { return instance; } private set { instance = value; } }


    [Header("Test Data")]
    public Text dataText;


    [Header("PHP URL String")]
    public string classUrl;
    public string allClassUrl;
    public string weaponUrl;

    [Header("File Path")]
    public string resourcePath;
    public string jsonPath;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        classUrl = "127.0.0.1/Unity/Class.php";
        allClassUrl = "127.0.0.1/Unity/AllClass.php";
        weaponUrl = "127.0.0.1/Unity/Weapon.php";

        resourcePath = "/Resources/";
        jsonPath = "JSON/";

        StartCoroutine(GetAllClassCo());

    }


    #region 실시간으로 Json 요청해서 원하는 값 반환하는 방식 ///실패
    //public void GetClassInfo(ePlayerClass playerClass)
    //{
    //    // playerClass를 받아서 String 값으로 전달하면서 코루틴 실행.
    //    //StartCoroutine(GetClassCo(playerClass.ToString()));
    //    // 플레이어의 직업을 받아서 실시간으로 정보를 넘겨주는 방식에서
    //    // 시작할 때 데이터를 받아서 json파일로 만들어 놓고
    //    // 요청이 들어오면 json 파일을 읽어서 Dictionary로 되돌려주는 방식으로 변경.



    //}

    //IEnumerator GetClassCo(string playerClass)
    //{
    //    // POST 방식의 요청
    //    WWWForm form = new WWWForm();

    //    form.AddField("Input_className", playerClass);

    //    // classUrl(php)에 form 값을 넘겨준다.
    //    WWW webRequest = new WWW(classUrl, form);

    //    yield return webRequest;

    //    // classUrl로 넘겨준 값에 error가 반환이 되는 것이 아니면
    //    if (string.IsNullOrEmpty(webRequest.error))
    //    {
    //        // 실행
    //        yield return GetClassJson(webRequest.text);
    //    }

    //}

    //private object GetClassJson(string _jsonData)
    //{
    //    // 입력받은 데이터를 Parsing 하는 단계
    //    var parseData = JSON.Parse(_jsonData);
    //    // {"results":[]} 형태의 파일
    //    var arrayData = parseData["results"];
    //    // []와 같이 데이터만 남는다.

    //    Dictionary<string, string> classDic = new Dictionary<string, string>();

    //    // 개수가 0개보다 많을 경우
    //    if (arrayData.Count > 0)
    //    {
    //        classDic.Add("ClassName", arrayData[0]["ClassName"].Value);
    //        classDic.Add("WeaponUID", arrayData[0]["WeaponUID"].Value);
    //        classDic.Add("StatusSkill0_UID", arrayData[0]["StatusSkill0_UID"].Value);
    //        classDic.Add("StatusSkill1_UID", arrayData[0]["StatusSkill1_UID"].Value);
    //        classDic.Add("StatusSkill2_UID", arrayData[0]["StatusSkill2_UID"].Value);
    //        classDic.Add("AbilitySkill0_UID", arrayData[0]["AbilitySkill0_UID"].Value);
    //        classDic.Add("AbilitySkill1_UID", arrayData[0]["AbilitySkill1_UID"].Value);
    //        classDic.Add("Perk0_UID", arrayData[0]["Perk0_UID"].Value);
    //        classDic.Add("Perk1_UID", arrayData[0]["Perk1_UID"].Value);
    //        classDic.Add("Perk2_UID", arrayData[0]["Perk2_UID"].Value);

    //    }
    //    else
    //    {
    //        Debug.Log("없는 직업입니다.");
    //    }

    //    dataText.text = "ClassName: " + classDic["ClassName"] + "\n";
    //    dataText.text += "WeaponUID: " + classDic["WeaponUID"] + "\n";
    //    dataText.text += "StatusSkill0_UID: " + classDic["StatusSkill0_UID"] + "\n";
    //    dataText.text += "StatusSkill1_UID: " + classDic["StatusSkill1_UID"] + "\n";
    //    dataText.text += "StatusSkill2_UID: " + classDic["StatusSkill2_UID"] + "\n";
    //    dataText.text += "AbilitySkill0_UID: " + classDic["AbilitySkill0_UID"] + "\n";
    //    dataText.text += "AbilitySkill1_UID: " + classDic["AbilitySkill1_UID"] + "\n";
    //    dataText.text += "Perk0_UID: " + classDic["Perk0_UID"] + "\n";
    //    dataText.text += "Perk1_UID: " + classDic["Perk1_UID"] + "\n";
    //    dataText.text += "Perk2_UID: " + classDic["Perk2_UID"] + "\n";

    //    return 0;
    //}

    #endregion


    #region 미리 Json을 만들어 놓고 요청하면 값 반환
    // 플레이어의 직업을 받으면 그 직업에 관련된 Dictionary 데이터를 반환
    public Dictionary<string, string> GetClassInfo(ePlayerClass playerClass)
    {
        string jsonString = File.ReadAllText(Application.dataPath + resourcePath + jsonPath + playerClass.ToString() + ".json");
        JsonData classData = JsonMapper.ToObject(jsonString);

        Debug.Log(classData["ClassName"].ToString());

        Dictionary<string, string> _classDict = new Dictionary<string, string>();


        _classDict.Add("ClassName", classData["ClassName"].ToString());
        _classDict.Add("WeaponUID", classData["WeaponUID"].ToString());
        _classDict.Add("StatusSkill0_UID", classData["StatusSkill0_UID"].ToString());
        _classDict.Add("StatusSkill1_UID", classData["StatusSkill1_UID"].ToString());
        _classDict.Add("StatusSkill2_UID", classData["StatusSkill2_UID"].ToString());
        _classDict.Add("AbilitySkill0_UID", classData["AbilitySkill0_UID"].ToString());
        _classDict.Add("AbilitySkill1_UID", classData["AbilitySkill1_UID"].ToString());
        _classDict.Add("Perk0_UID", classData["Perk0_UID"].ToString());
        _classDict.Add("Perk1_UID", classData["Perk1_UID"].ToString());
        _classDict.Add("Perk2_UID", classData["Perk2_UID"].ToString());

        return _classDict;
    }


    IEnumerator GetAllClassCo()
    {
        // POST 방식의 요청
        WWWForm form = new WWWForm();

        // classUrl(php)에 form 값을 넘겨준다.
        WWW webRequest = new WWW(allClassUrl, form);

        yield return webRequest;

        // classUrl로 넘겨준 값에 error가 반환이 되는 것이 아니면
        if (string.IsNullOrEmpty(webRequest.error))
        {
            // 실행
            GetAllClassJson(webRequest.text);
        }
    }

    private void GetAllClassJson(string _jsonData)
    {
        // 입력받은 데이터를 Parsing 하는 단계
        var parseData = JSON.Parse(_jsonData);
        // {"results":[]} 형태의 파일
        var arrayData = parseData["results"];
        // []와 같이 데이터만 남는다.

        Dictionary<string, string> classDic = new Dictionary<string, string>();

        // 개수가 0개보다 많을 경우
        if (arrayData.Count > 0)
        {
            for (int i = 0; i < arrayData.Count; i++)
            {
                classDic.Add("ClassName", arrayData[i]["ClassName"].Value);
                classDic.Add("WeaponUID", arrayData[i]["WeaponUID"].Value);
                classDic.Add("StatusSkill0_UID", arrayData[i]["StatusSkill0_UID"].Value);
                classDic.Add("StatusSkill1_UID", arrayData[i]["StatusSkill1_UID"].Value);
                classDic.Add("StatusSkill2_UID", arrayData[i]["StatusSkill2_UID"].Value);
                classDic.Add("AbilitySkill0_UID", arrayData[i]["AbilitySkill0_UID"].Value);
                classDic.Add("AbilitySkill1_UID", arrayData[i]["AbilitySkill1_UID"].Value);
                classDic.Add("Perk0_UID", arrayData[i]["Perk0_UID"].Value);
                classDic.Add("Perk1_UID", arrayData[i]["Perk1_UID"].Value);
                classDic.Add("Perk2_UID", arrayData[i]["Perk2_UID"].Value);


                string fileName = arrayData[i]["ClassName"].Value;
                JsonData classJson = JsonMapper.ToJson(classDic);

                File.WriteAllText(Application.dataPath + resourcePath + jsonPath + fileName + ".json", classJson.ToString());
                classDic.Clear();
            }
        }
        else
        {
            Debug.Log("없는 직업입니다.");
        }

    }
    #endregion


}
