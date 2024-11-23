using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealtController : MonoBehaviour
{

    public static PlayerHealtController instance;

    public int currentHealt, maxHealt;

    private void Awake(){
        instance = this;
    }    

    // Start is called before the first frame update
    void Start()
    {
        currentHealt = maxHealt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dealDamage(){
        currentHealt --;

        if(currentHealt <=0){
            gameObject.SetActive(false);
        }
    }
}
