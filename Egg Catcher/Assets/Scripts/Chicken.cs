using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{   
    [SerializeField]
    public GameObject egg;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn() {
        while (true) {
            float wait_time = Random.Range(2f,6f);
            yield return new WaitForSeconds(wait_time);
            Instantiate(egg, transform.position, Quaternion.identity);
            }
    }
}
