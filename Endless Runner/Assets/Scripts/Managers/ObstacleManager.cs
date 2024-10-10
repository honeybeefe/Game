using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : State
{
    [SerializeField] int createCount = 5;
    [SerializeField] int random;
    [SerializeField] List<GameObject> obstacleList;

    void Start()
    {
        obstacleList.Capacity = 20;

        Create();

        StartCoroutine(ActiveObstacle());
    }

    public void Create()
    {
        for(int i=0; i<createCount; i++)
        {
            GameObject prefab = ResourcesManager.Instance.Instantiate("Cone", gameObject.transform);

            prefab.SetActive(false);

            obstacleList.Add(prefab);
        }
    }

     public bool ExamineActive()
    {
        for(int i = 0; i< obstacleList.Count; i++)
        {
            if (obstacleList[i].activeSelf == false)
            {
                return false;
            }
        }
        return true;
    }

    public IEnumerator ActiveObstacle()
    {
        while(true)
        {
            yield return CoroutineCache.WaitForSecond(2.5f);

            random = Random.Range(0, obstacleList.Count);

            //현재 게임 오브젝트가 활성화되어 있는지 확인
            while(obstacleList[random].activeSelf==true)
            {
                //현재 리스트에 있는 모든 게임 오브젝트가 활성화되어 있는지 확인
                if(ExamineActive())
                {
                    //모든 게임 오브젝트가 활성화되어 있다면 게임 오브젝트를 새로 생성한 다음
                    //ObstacleList에 넣어준다
                    GameObject clone = ResourcesManager.Instance.Instantiate("Cone", gameObject.transform);

                    clone.SetActive(false);

                    obstacleList.Add(clone);
                }

                //현재 인덱스에 있는 게임 오브젝트가 활성화되어 있으면 random 변수의 값을 +1해서 다시 검색
                random = (random + 1) % obstacleList.Count;
            }
        }
    }

    public GameObject GetObstacle()
    {
        return obstacleList[random];
    }
}