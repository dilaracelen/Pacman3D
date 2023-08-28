using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class YapayZeka : MonoBehaviour
{
    public NavMeshAgent takipEt;
    public Animator anim;
    public Transform düþmanDoðmaYeri;
    public GameObject hedefKüp;
    public MeshRenderer görünürlük;

    string renk = "Kýrmýzý";

    private void OnTriggerEnter(Collider other)
    {
        switch (görünürlük.enabled)
        {
            case true:

                if(other.gameObject.tag == "Player" && renk == "Kýrmýzý")
                    SceneManager.LoadScene(0);

                if(other.gameObject.tag == "Player" && renk == " Mavi")
                {
                    KýrmýzýOl();
                    hedefKüp.transform.position = düþmanDoðmaYeri.position;

                    CancelInvoke("KýrmýzýOl");
                    CancelInvoke("AnimasyonuBaþlat");

                    görünürlük.enabled = false;
                }

                if(other.gameObject == hedefKüp)
                {
                    other.gameObject.GetComponent<HedefKüp>().HareketEt();
                }

                break;

            case false:

                if(other.gameObject == hedefKüp)
                {
                    other.gameObject.GetComponent<HedefKüp>().HareketEt();
                    görünürlük.enabled = true;
                }

                break;
        }
    }

    private void Update()
    {
        takipEt.destination = hedefKüp.transform.position;
    }

    public void MaviOl()
    {
        renk = "Mavi";
        anim.SetBool("maviOl", true);

        Invoke("AnimasyonuBaþlat", 7.0f);
        Invoke("KýrmýzýOl", 10f);
    }

    void AnimasyonuBaþlat()
    {
        anim.SetBool("renkDeðiþtir", false);
    }

    void KýrmýzýOl()
    {
        renk = "Kýrmýzý";
        anim.SetBool("maviOl", false);
        anim.SetBool("renkDeðiþtir", false);
    }
}
