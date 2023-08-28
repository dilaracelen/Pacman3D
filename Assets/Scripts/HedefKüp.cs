using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedefKüp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Duvar")
        {
            HareketEt();
        }
    }

    public void HareketEt()
    {
        float z = Random.Range(-18f, 14f);
        float x = Random.Range(-13f, 19.75f);

        transform.position = new Vector3(x, transform.position.y, z);
    }
}
