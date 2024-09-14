using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcWalk : MonoBehaviour
{
    public float speed;
    public Transform target;

    // Komponen NavMeshAgent untuk navigasi NPC
    public NavMeshAgent agent;

    // Komponen Animator untuk mengontrol animasi NPC
    public Animator animator;

    // GameObject yang berisi titik-titik jalur (Path Points)
    public GameObject PATH;

    // Array yang menyimpan titik-titik jalur sebagai Transform
    public Transform[] PathPoints;

    // Jarak minimum yang harus dicapai NPC sebelum berpindah ke titik berikutnya
    public float minDistance = 1;
    public float timeLimit = 5;
    public float timeCount;
    // Indeks saat ini dalam array PathPoints
    public int index = 0;

    void Start()
    {
        // Mengambil komponen NavMeshAgent dan Animator dari GameObject ini
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // Menginisialisasi array PathPoints dengan jumlah anak dari PATH
        /*PathPoints = new Transform[PATH.transform.childCount];
        for (int i = 0; i < PathPoints.Length; i++)
        {
            // Menyimpan setiap anak dari PATH sebagai elemen dalam PathPoints
            PathPoints[i] = PATH.transform.GetChild(i);
        }
        timeCount = timeLimit;*/
        target = FindObjectOfType<Waypoints>().waypoints[0];
    }

    void Update()
    {
        // Memanggil metode roam() setiap frame
        roam();
    }

    void roam()
    {
        //*/ Memeriksa apakah index berada dalam rentang yang valid
        /*if (index >= 0 && index < PathPoints.Length)
        {
            // Memeriksa jarak antara posisi NPC dan titik jalur saat ini
            if (Vector3.Distance(transform.position, PathPoints[index].position) < minDistance)
            {
                // Jika jarak cukup dekat, pindah ke titik jalur berikutnya
                index += 1;
            }
            else
            {
                // Jika jarak belum cukup dekat, kembali ke titik awal
                index = 0;
            }
        }
        
        // Mengatur tujuan NavMeshAgent ke posisi titik jalur yang dituju
        

        // Mengatur parameter 'vertical' pada Animator berdasarkan status NavMeshAgent
        */
        Vector3 dir = target.position - transform.position;
        //transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        agent.SetDestination(target.position);
        animator.SetFloat("vertical", !agent.isStopped ? 1 : 0);


        //transform.LookAt(target.position);

        if (Vector3.Distance(transform.position, target.position) <= 1.9f)
        {
            NextWaypoints();
        }
    }
    void NextWaypoints()
    {
        if (index >= FindObjectOfType<Waypoints>().waypoints.Length - 1)
        {
            Debug.Log("AKHIR");
            index = -1;
        }
        index++;
        target = FindObjectOfType<Waypoints>().waypoints[(index)];
    }
}
