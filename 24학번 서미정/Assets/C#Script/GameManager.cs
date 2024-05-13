using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;                     //게임오버 시 활성화할 텍스트 게임 오브젝트
    public Text timeText;                               //생존 시간을 표기할 텍스트 컴포넌트
    public Text recordText;                             //최고 기록을 표기할 텍스트 컴포넌트

    private float surviveTime;                          //생존 시간
    private bool isGameover;                            //게임오버 상태

    public AudioSource endAudioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;                                //생존 시간과 게임오버 상태 초기화
        isGameover = false;

        endAudioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)                                // 게임오버가 아닌 동안
        {
            surviveTime += Time.deltaTime;              // 생존 시간 갱신
            timeText.text = "Time;" + (int)surviveTime;  // 갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
        }
        else
        {
            gameoverText.SetActive(true);               

            if (Input.GetKey(KeyCode.R))                // 게임오버 상태에서 R 키를 누른 경우
            {
                SceneManager.LoadScene("SampleScene");  // SampleleScene 씬을 로드
            }
        }
    }

    public void EndGame()
    {
        isGameover = true;                              // 현재 상태를 게임오버 상태로 전환
        gameoverText.SetActive(true);                   // 게임 오버 텍스트 게임 오브젝트를 활성화

        float bestTime = PlayerPrefs.GetFloat("BestTime");                //BestTime 키로 저장된 이전까지의 최고 시록 가져오기  

        if (surviveTime > bestTime)                     //이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
        {
            bestTime = surviveTime;                     //최고 기록 값을 현재 생존 시간 값으로 변경
            PlayerPrefs.SetFloat("BestTime", bestTime); //변경된 최고 기록을 BestTime 키로 저장
        }

        recordText.text = "Best Time : " + (int)bestTime;   //BestTime 저장

        endAudioPlayer.Play();

    }
}
