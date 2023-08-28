using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OyuncuKontrolü : MonoBehaviour
{
    public Rigidbody rb;
    public LayerMask duvarlar;
    public TextMeshProUGUI skor_txt;

    GameObject[] düşmanlar;
    GameObject[] yemler;

    int yem_miktarı;
    int skor = 0;

    float hız = 5f;

    bool sağ = false;
    bool sol = false;
    bool yukarı = false; 
    bool aşağı = false;

    private void Start()
    {
        düşmanlar = GameObject.FindGameObjectsWithTag("Düşman");
        yemler = GameObject.FindGameObjectsWithTag("Yem");

        yem_miktarı = yemler.Length;

        skor_txt.text = "Skor:" + skor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Yem")
        {
            Destroy(other.gameObject);
            skor += 10;
            skor_txt.text = "Skor:" + skor;
            yem_miktarı--;

            if(yem_miktarı == 0)
            {
                Debug.Log("Tebrikler! Oyunu kazandın.");
            }
        }

        if(other.gameObject.tag == "BüyükYem")
        {
            Destroy(other.gameObject);
            foreach(GameObject düşman in düşmanlar)
            {
                düşman.GetComponent<YapayZeka>().MaviOl();
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow) && Kontrol(-Vector3.right) == false)
            YönDurumu(true, false, false, false);

        if (Input.GetKeyDown(KeyCode.LeftArrow) && Kontrol(Vector3.right) == false)
            YönDurumu(false, true, false, false);

        if (Input.GetKeyDown(KeyCode.UpArrow) && Kontrol(-Vector3.forward) == false)
            YönDurumu(false, false, true, false);

        if (Input.GetKeyDown(KeyCode.DownArrow) && Kontrol(Vector3.forward) == false)
            YönDurumu(false, false, false, true);
    }

    bool Kontrol(Vector3 IşıkYönü)
    {
        RaycastHit temas;
        
        if(Physics.Raycast(transform.position, IşıkYönü, out temas, 2.0f, duvarlar))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void YönDurumu(bool sağYönü, bool solYönü, bool yukarıYönü, bool aşağıYönü)
    {
        sağ = sağYönü;
        sol = solYönü;
        yukarı = yukarıYönü;
        aşağı = aşağıYönü;
    }

    private void FixedUpdate()
    {
        HareketEt();
    }

    void HareketEt()
    {
        if (sağ)
            rb.velocity = -Vector3.right * hız;

        if (sol)
            rb.velocity = Vector3.right * hız;

        if (yukarı)
            rb.velocity = new Vector3(0,0,-1) * hız;

        if (aşağı)
            rb.velocity = new Vector3(0,0,1) * hız;
    }
}
