using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAW : MonoBehaviour
{
    public Transform parent;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerPER" || other.tag == "Player")
        {
            Debug.Log("AAAAAAAAA");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PlayerPER" || other.tag == "Player")
        {
            Debug.Log("AAAAAAAAA");
            Search(other.transform.position);
        }
    }

    public void Search(Vector3 target)
    {
        float moving = speed * Time.deltaTime;
        parent.localPosition = Vector3.MoveTowards(new Vector3(parent.localPosition.x, parent.localPosition.y, parent.localPosition.z), target, moving);
    }
}
