using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Detail_check : MonoBehaviour
{
    public TMP_Text ex_text;
    GameObject obj;
    List<string> quiz = new List<string>(); //문제
    List<string> correct = new List<string>(); //정답
    List<string> answer = new List<string>(); //내가 쓴 답
    List<string> explanation = new List<string>(); //설명
    int i = 0;
    ScrollRect scrollRect;


    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Quiz_list");
        quiz = obj.GetComponent<Quiz_list>().quiz;
        correct = obj.GetComponent<Quiz_list>().correct;
        explanation = obj.GetComponent<Quiz_list>().explanation;
        answer = obj.GetComponent<Quiz_list>().answer;

        scrollRect = GameObject.Find("Scroll View").GetComponent<ScrollRect>();

        Score_Detail();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Score_Detail()
    {
        for (i = 0; i < quiz.Count; i++)
        {
            ex_text = scrollRect.content.GetChild(i + 1).GetComponent<TMP_Text>();
            ex_text.text = $"{i + 1}. {quiz[i]} \n정답: {correct[i]} \t내 답: {answer[i]} \n해설: {explanation[i]}";
        }
    }
}
