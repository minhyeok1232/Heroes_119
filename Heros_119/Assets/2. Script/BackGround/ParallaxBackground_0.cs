using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground_0 : MonoBehaviour
{
    public float Background_MoveSpeed = 1.5f;

    [Header("Layer Setting")]
    [SerializeField] private float[] Layer_Speed = new float[7];
    [SerializeField] private GameObject[] Layer_Objects = new GameObject[7];

    private float boundSizeX;
    private float sizeX;

    void Start()
    {
        SpriteRenderer sr = Layer_Objects[0].GetComponent<SpriteRenderer>();
        boundSizeX = sr.sprite.bounds.size.x;
        sizeX = Layer_Objects[0].transform.localScale.x;
    }

    void Update()
    {
        for (int i = 0; i < Layer_Objects.Length; i++)
        {
            // 1. 각 레이어를 왼쪽으로 움직이기 (배경 속도 차이)
            Layer_Objects[i].transform.position += Layer_Speed[i] * Background_MoveSpeed * Time.deltaTime * Vector3.left;

            // 2. 무한 루프 처리 (배경이 왼쪽 끝을 지나면 다시 오른쪽으로 옮기기)
            float xPos = Layer_Objects[i].transform.position.x;
            if (xPos < -boundSizeX * sizeX)
            {
                Layer_Objects[i].transform.position += boundSizeX * sizeX * 2f * Vector3.right;
            }
        }
    }
}