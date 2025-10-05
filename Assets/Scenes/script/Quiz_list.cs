using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Quiz_list : MonoBehaviour
{
    public TMP_Text Qestion;    //����
    public TMP_Text Now_Qes;    //���� ����

    public GameObject NextB;    //������ư
    public GameObject YesB;     //o��ư
    public GameObject NoB;      //x��ư

    public Image Timg; //���� �̹���

    public Sprite Bimg; //�ٲ� �̹��� �⺻
    public Sprite Yimg;  //�ٲ��̹��� ����
    public Sprite Nimg; //�ٲ� �̹��� ����

    string[] input_t =
    {
        "�ȳ��ϼ���. ���� �����̶�� �ؿ�!",
        "�� ������ ���� ������ �ùٸ� ��Ī�� �˱� ���� ���� �����̿���.",
        "���� ���ϴ� ���� ��Ī�� �ùٸ� ��Ī���� ����������.",
        "�׷� �����մϴ�!"
    };
    string[] input_q =
    {
        "���������� ���ĸ�Ī�� �������?",
        "���Ÿ������� ���ĸ�Ī�� �������?",
        "���̿����� ���ĸ�Ī�� �������?",
        "������� ���ĸ�Ī�� �������?",
        "���̾������ ���ĸ�Ī�� �������?",
        "���������� ���ĸ�Ī�� �������?",
        "���������� ���ĸ�Ī�� �������?",
        "�ı����� ���ĸ�Ī�� �������?",
        "�������̿����� ���ĸ�Ī�� �������?",
        "��������� ���ĸ�Ī�� �������?",
        "�������� ���ĸ�Ī�� �������?"
    };
    string[] input_c =
    {
        "X",        "O",        "X",        "O",        "X",
        "X",        "O",        "O",        "X",        "O",
        "X"
    };
    string[] input_e =
    {
        "���������� ���ĸ�Ī�� ���������̸� �������� �ȴ��鿡 ��ġ���ֽ��ϴ�.(���ְ������� ����)",
        "���Ӹ������̶�� �Ҹ��� �������ÿ� ��ġ���ֽ��ϴ�.(���ְ������� ����)",
        "���̿����� ���ĸ�Ī�� �Ž������̸� ���ֽ� �������� ��ġ���ֽ��ϴ�.(���ְ������� ����)",
        "�˻�޶�� �Ҹ��� ���ֽ� �������� ��ġ���ֽ��ϴ�.(���ְ������� ����)",
        "���̾������ ���ĸ�Ī�� ���̿����̸� ���ֽ� �ƶ󵿿� ��ġ���ֽ��ϴ�.(���ְ������� ����)",
        "���������� ���ĸ�Ī�� ���������̸� ���ֽ� �ֿ����� ��ġ���ֽ��ϴ�.(���ְ������� ����)",
        "�ΰ������̶�� �Ҹ��� ���ֽ� �Ѱ�鿡 ��ġ���ֽ��ϴ�.(���ְ������� ����)",
        "�ٱ��������̶�� �Ҹ��� ���ֽ� �ֿ����� ��ġ���ֽ��ϴ�.(���ְ������� ����)",
        "�������̿����� ���ĸ�Ī�� �Ź̿����̸� ���ֽ� �������� ��ġ���ֽ��ϴ�.(���ְ������� ����)",
        "���������̶�� �Ҹ��� ���ֽ� �Ѹ����� ��ġ���ֽ��ϴ�.(���ְ������� ����)",
        "�������� ���ĸ�Ī�� �������̸� ���ֽ� �ֿ����� ��ġ���ֽ��ϴ�.(���ְ������� ����)"
    };

    public int i = 0;  //���� ����
    public int score = 0;  //����
    int btn = 0;    //��ư ���� Ƚ��
    int a = 0;  //�������� ���


    public List<string> quiz = new List<string>();  //����
    public List<string> correct = new List<string>();   //����
    public List<string> explanation = new List<string>();   //�ؼ�
    public List<string> answer = new List<string>();    //���
    List<string> talk = new List<string> ();    //������ ���


    // Start is called before the first frame update
    void Start()
    {
        //�ʱ�ȭ
        i = -1;
        btn = 0;
        score = 0;

        quiz.AddRange(input_q); //���� �߰�
        correct.AddRange(input_c);  //���� �߰�
        explanation.AddRange(input_e);  //�ؼ� �߰�
        talk.AddRange(input_t); //������ ��� �߰�

        Timg.sprite = Bimg;
        YesB.SetActive(false); //��ư �����
        NoB.SetActive(false); //��ư �����



        Talking();
        Now_Qes.text = (i + 1) + "/" + quiz.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //������ ��� �����ֱ�.
    void Talking()
    {
        Qestion.text = talk[a];
    }

    //������  �����ش�.
    void QesT()
    {
        Qestion.text = (i+1) + ". " + quiz[i];
        Now_Qes.text = (i + 1) + "/" + quiz.Count;
    }

    //���� ��ư�� ������ ��.
    public void OnClickNextB()
    {
        if(a < talk.Count-1)
        {
            a++;
            Talking();
        } else
        {
            i++;
            //i���� ������ ���̺��� ���� ���, ���� ������ �Ѿ��.
            if (i < quiz.Count)
            {
                Timg.sprite = Bimg; //�̹��� ���� �⺻
                QesT(); //���� ������ �Ѿ��
            }
            else //�ƴ� ���, ���� ȭ������ �Ѿ��.
            {
                DontDestroyOnLoad(gameObject);  //�� �ѱ��
                SceneManager.LoadScene("End");  //���� ȭ������ ����.
            }
            NextB.SetActive(false); //��ư �����
            YesB.SetActive(true); //o��ư Ȱ��ȭ
            NoB.SetActive(true); //x��ư Ȱ��ȭ
        }
    }

    //���� Ȯ��
    void Check()
    {
        NextB.SetActive(true);  //���� ���� ��ư �����ֱ�

        //�ߺ����� ox��ư�� ������ ���� ����
        if(btn == i)
        {
            //���� ������ ���
            if (answer[i] == correct[i])
            {
                Timg.sprite = Yimg; //�̹��� ���� ����
                Qestion.text = "�����Դϴ�. ";
                score = score + 1;
            }
            else //������ �ƴ� ���
            {
                Timg.sprite = Nimg; //�̹��� ���� ����
                Qestion.text = "�����Դϴ�. " + explanation[i];
            }
            btn++;
        } else
        {

        }

    }


    //O��ư�� ���� ���, answer���� 'O'�� �ٲٰ� ������ Ȯ���Ѵ�.
    public void answer_yes()
    {
        answer.Add("O");
        Check();
    }

    //X��ư�� ���� ���, answer���� 'X'�� �ٲٰ� ������ Ȯ���Ѵ�.
    public void answer_no()
    {
        answer.Add("X");
        Check();
    }
}
