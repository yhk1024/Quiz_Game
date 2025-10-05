using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score_check : MonoBehaviour
{
    GameObject obj;

    public TMP_Text Check;    //점수 확인
    int score = 0;  //점수
    int i = 0;  //문제수

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Quiz_list");
        i = obj.GetComponent<Quiz_list>().i;
        score = obj.GetComponent<Quiz_list>().score;

        Check.text = "총 " + i + "점 중에서 " + score + "점 맞았습니다!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClick_ReplayB()
    {
        SceneManager.LoadScene("Quiz");
    }

    public void OnClick_EndB()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnClick_DetailB()
    {
        DontDestroyOnLoad(gameObject);  //값 넘기기
        SceneManager.LoadScene("Detail");
    }
}
