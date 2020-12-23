using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    [SerializeField]
    private GameObject sparkleFX;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            Instantiate(sparkleFX,transform.position,Quaternion.identity);
            GameplayController.instance.PlayGemSound();
            GameplayController.instance.IncreaseScore();
            gameObject.SetActive(false);

        }
    }
}
