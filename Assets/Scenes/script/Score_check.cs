using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score_check : MonoBehaviour
{
    GameObject obj;

    public TMP_Text Check;    //���� Ȯ��
    int score = 0;  //����
    int i = 0;  //������

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Quiz_list");
        i = obj.GetComponent<Quiz_list>().i;
        score = obj.GetComponent<Quiz_list>().score;

        Check.text = "�� " + i + "�� �߿��� " + score + "�� �¾ҽ��ϴ�!";
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
        DontDestroyOnLoad(gameObject);  //�� �ѱ��
        SceneManager.LoadScene("Detail");
    }
}
