using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;                              //생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f;                            //최소 생성 주기
    public float spawnRateMax = 3f;                             //최대 생성 주기

    private Transform target;                                   //발사할 대상
    private float spawnRate;                                    //생성 주기
    private float TimeAfterSpawn;                               //최근 생성 시점에서 지난 시간

    public AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
       TimeAfterSpawn = 0f;                                   //최근 생성 이후의 누적 시간을 0으로 초기화
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); //탄알 생성 간격을 spawnRateMax 사이에서 랜덤 지정
        target = FindObjectOfType<PlayerController>().transform; //PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정

        audioPlayer = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {   // 타임에프터스퐌 시간 갱신 (Update때마다 흘러단 시간을 누적 합산)
        TimeAfterSpawn += Time.deltaTime;            //TimeAfterSpawn 갱신

        if (TimeAfterSpawn >= spawnRate)             //최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        {
            TimeAfterSpawn = 0f;                     //누적된 시간을 리셋

            //BulletPrefab의 복제본을
            //transform.position 위치와 transform.rotation 회전으로 생성
            GameObject bullet
                = Instantiate(bulletPrefab, transform.position, transform.rotation);
             //생성괸 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전으로
             bullet.transform.LookAt(target);

            //포탄 생성시 포탄 발사음 실행
            audioPlayer.Play();

        }
    }
}
