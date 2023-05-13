using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{ 
     
   
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="enemy")
        {
            ScoreManager.instance.ChangeScore(-10);
        }
        
    }

/*    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "fish" && !hasCollided)
        {

            other.gameObject.SetActive(false);
            hasCollided = true;
            ScoreManager.instance.ChangeScore(scoreValue);

        }
    }*/
}
