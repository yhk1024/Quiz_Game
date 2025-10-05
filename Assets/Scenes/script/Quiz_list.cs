using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Quiz_list : MonoBehaviour
{
    public TMP_Text Qestion;    //문제
    public TMP_Text Now_Qes;    //현재 문제

    public GameObject NextB;    //다음버튼
    public GameObject YesB;     //o버튼
    public GameObject NoB;      //x버튼

    public Image Timg; //현재 이미지

    public Sprite Bimg; //바꿀 이미지 기본
    public Sprite Yimg;  //바꿀이미지 정답
    public Sprite Nimg; //바꿀 이미지 오답

    string[] input_t =
    {
        "안녕하세요. 저는 르방이라고 해요!",
        "이 게임은 제주 오름의 올바른 명칭을 알기 위해 만든 게임이에요.",
        "제가 말하는 오름 명칭이 올바른 명칭인지 맞혀보세요.",
        "그럼 시작합니다!"
    };
    string[] input_q =
    {
        "원물오름은 정식명칭이 맞을까요?",
        "갯거리오름은 정식명칭이 맞을까요?",
        "새미오름은 정식명칭이 맞을까요?",
        "묘산봉은 정식명칭이 맞을까요?",
        "세미양오름은 정식명칭이 맞을까요?",
        "윗세오름은 정식명칭이 맞을까요?",
        "판포오름은 정식명칭이 맞을까요?",
        "파군봉은 정식명칭이 맞을까요?",
        "동검은이오름은 정식명칭이 맞을까요?",
        "명월오름은 정식명칭이 맞을까요?",
        "과오름은 정식명칭이 맞을까요?"
    };
    string[] input_c =
    {
        "X",        "O",        "X",        "O",        "X",
        "X",        "O",        "O",        "X",        "O",
        "X"
    };
    string[] input_e =
    {
        "원물오름의 정식명칭은 감낭오름이며 서귀포시 안덕면에 위치해있습니다.(제주관광공사 기준)",
        "갯머리오름이라고도 불리며 서귀포시에 위치해있습니다.(제주관광공사 기준)",
        "새미오름의 정식명칭은 거슨새미이며 제주시 구좌읍에 위치해있습니다.(제주관광공사 기준)",
        "궤살메라고도 불리며 제주시 구좌읍에 위치해있습니다.(제주관광공사 기준)",
        "세미양오름의 정식명칭은 세미오름이며 제주시 아라동에 위치해있습니다.(제주관광공사 기준)",
        "윗세오름의 정식명칭은 웃세오름이며 제주시 애월읍에 위치해있습니다.(제주관광공사 기준)",
        "널개오름이라고도 불리며 제주시 한경면에 위치해있습니다.(제주관광공사 기준)",
        "바굼지오름이라고도 불리며 제주시 애월읍에 위치해있습니다.(제주관광공사 기준)",
        "동검은이오름의 정식명칭은 거미오름이며 제주시 구좌읍에 위치해있습니다.(제주관광공사 기준)",
        "밝은오름이라고도 불리며 제주시 한림읍에 위치해있습니다.(제주관광공사 기준)",
        "과오름의 정식명칭은 샛오름이며 제주시 애월읍에 위치해있습니다.(제주관광공사 기준)"
    };

    public int i = 0;  //현재 문제
    public int score = 0;  //점수
    int btn = 0;    //버튼 누른 횟수
    int a = 0;  //르방이의 대사


    public List<string> quiz = new List<string>();  //문제
    public List<string> correct = new List<string>();   //정답
    public List<string> explanation = new List<string>();   //해설
    public List<string> answer = new List<string>();    //대답
    List<string> talk = new List<string> ();    //르방이 대사


    // Start is called before the first frame update
    void Start()
    {
        //초기화
        i = -1;
        btn = 0;
        score = 0;

        quiz.AddRange(input_q); //문제 추가
        correct.AddRange(input_c);  //정답 추가
        explanation.AddRange(input_e);  //해설 추가
        talk.AddRange(input_t); //르방이 대사 추가

        Timg.sprite = Bimg;
        YesB.SetActive(false); //버튼 숨기기
        NoB.SetActive(false); //버튼 숨기기



        Talking();
        Now_Qes.text = (i + 1) + "/" + quiz.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //르방이 대사 보여주기.
    void Talking()
    {
        Qestion.text = talk[a];
    }

    //문제를  보여준다.
    void QesT()
    {
        Qestion.text = (i+1) + ". " + quiz[i];
        Now_Qes.text = (i + 1) + "/" + quiz.Count;
    }

    //다음 버튼을 눌렀을 때.
    public void OnClickNextB()
    {
        if(a < talk.Count-1)
        {
            a++;
            Talking();
        } else
        {
            i++;
            //i값이 문제의 길이보다 작을 경우, 다음 문제로 넘어간다.
            if (i < quiz.Count)
            {
                Timg.sprite = Bimg; //이미지 변경 기본
                QesT(); //다음 문제로 넘어가기
            }
            else //아닐 경우, 종료 화면으로 넘어간다.
            {
                DontDestroyOnLoad(gameObject);  //값 넘기기
                SceneManager.LoadScene("End");  //종료 화면으로 간다.
            }
            NextB.SetActive(false); //버튼 숨기기
            YesB.SetActive(true); //o버튼 활성화
            NoB.SetActive(true); //x버튼 활성화
        }
    }

    //정답 확인
    void Check()
    {
        NextB.SetActive(true);  //다음 문제 버튼 보여주기

        //중복으로 ox버튼을 누르는 것을 방지
        if(btn == i)
        {
            //만약 정답일 경우
            if (answer[i] == correct[i])
            {
                Timg.sprite = Yimg; //이미지 변경 정답
                Qestion.text = "정답입니다. ";
                score = score + 1;
            }
            else //정답이 아닐 경우
            {
                Timg.sprite = Nimg; //이미지 변경 오답
                Qestion.text = "오답입니다. " + explanation[i];
            }
            btn++;
        } else
        {

        }

    }


    //O버튼을 누를 경우, answer값을 'O'로 바꾸고 정답을 확인한다.
    public void answer_yes()
    {
        answer.Add("O");
        Check();
    }

    //X버튼을 누를 경우, answer값을 'X'로 바꾸고 정답을 확인한다.
    public void answer_no()
    {
        answer.Add("X");
        Check();
    }
}
