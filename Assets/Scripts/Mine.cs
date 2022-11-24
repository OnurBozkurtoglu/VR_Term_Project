using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{

    public float hp = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickAxTrigger")&& hp>0)
        {

            hp -= 1;
            if (hp <= 0)
            {
                Destroy(gameObject,0.5f);
            }

        }
    }

}
