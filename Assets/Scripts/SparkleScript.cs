using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator DeactivateAfterTime()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
