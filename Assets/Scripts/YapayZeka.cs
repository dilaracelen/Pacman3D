using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class YapayZeka : MonoBehaviour
{
    public NavMeshAgent takipEt;
    public Animator anim;
    public Transform d��manDo�maYeri;
    public GameObject hedefK�p;
    public MeshRenderer g�r�n�rl�k;

    string renk = "K�rm�z�";

    private void OnTriggerEnter(Collider other)
    {
        switch (g�r�n�rl�k.enabled)
        {
            case true:

                if(other.gameObject.tag == "Player" && renk == "K�rm�z�")
                    SceneManager.LoadScene(0);

                if(other.gameObject.tag == "Player" && renk == " Mavi")
                {
                    K�rm�z�Ol();
                    hedefK�p.transform.position = d��manDo�maYeri.position;

                    CancelInvoke("K�rm�z�Ol");
                    CancelInvoke("AnimasyonuBa�lat");

                    g�r�n�rl�k.enabled = false;
                }

                if(other.gameObject == hedefK�p)
                {
                    other.gameObject.GetComponent<HedefK�p>().HareketEt();
                }

                break;

            case false:

                if(other.gameObject == hedefK�p)
                {
                    other.gameObject.GetComponent<HedefK�p>().HareketEt();
                    g�r�n�rl�k.enabled = true;
                }

                break;
        }
    }

    private void Update()
    {
        takipEt.destination = hedefK�p.transform.position;
    }

    public void MaviOl()
    {
        renk = "Mavi";
        anim.SetBool("maviOl", true);

        Invoke("AnimasyonuBa�lat", 7.0f);
        Invoke("K�rm�z�Ol", 10f);
    }

    void AnimasyonuBa�lat()
    {
        anim.SetBool("renkDe�i�tir", false);
    }

    void K�rm�z�Ol()
    {
        renk = "K�rm�z�";
        anim.SetBool("maviOl", false);
        anim.SetBool("renkDe�i�tir", false);
    }
}
