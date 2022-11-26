using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineArea : MonoBehaviour
{


    private List<GameObject> mines;

    [SerializeField]
    private GameObject minePrefab;

    [SerializeField]
    private int maxMine = 20;


    private Cooldown cd;

    // Start is called before the first frame update
    void Start()
    {
        mines = new List<GameObject>();
        cd = new Cooldown(1000);
         
    }

    // Update is called once per frame
    void Update()
    {

        if (mines.Count < maxMine && cd.Ready())
        {
            SpawnMine();
        }

    }



    private void SpawnMine()
    {
        
        GameObject mine = GameObject.Instantiate(minePrefab,null);
        mine.transform.SetParent(transform);
        Vector3 minePosition;
        minePosition.y = 2.7f;
        minePosition.x = Random.RandomRange(-0.5f, 0.5f);
        minePosition.z = Random.RandomRange(-0.5f, 0.5f);

        int max = 20;
        for (int i = 0; i < mines.Count; i++)
        {
            if (max <= 0)
            {
                Debug.Log("max");
                Destroy(mine);
                return;
            }
                
            float distance = Vector3.Distance(minePosition, mines[i].transform.localPosition);
            if (distance < 0.1f)
            {
                max--;
                minePosition.x = Random.RandomRange(-0.5f, 0.5f);
                minePosition.z = Random.RandomRange(-0.5f, 0.5f);
                i = -1;
            }
        }

        mine.transform.localPosition = minePosition;
        mines.Add(mine);

    }






}
