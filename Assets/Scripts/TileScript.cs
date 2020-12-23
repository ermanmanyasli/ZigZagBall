using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    private Rigidbody mybody;
    private AudioSource audiosource;

    [SerializeField]
    private GameObject gem;
    [SerializeField]
    private float chanceForCollectable;

    // Start is called before the first frame update
    void Awake()
    {
        mybody = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Start()
    {
        if (Random.value < chanceForCollectable)
        {
            Vector3 temp = transform.position;
            temp.y += 1.4f;
            Instantiate(gem, temp, Quaternion.identity);
        }
    }


    IEnumerator TriggerFallingDown()
    {
        yield return new WaitForSeconds(0.3f);
        mybody.isKinematic = false;
        audiosource.Play();
        StartCoroutine(TurnOffGameobject());
    }


    IEnumerator TurnOffGameobject()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider target)
    {
        if (target.tag == "Ball")
        {
            StartCoroutine(TriggerFallingDown());
        }
    }



}//class









































