using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarObstacle : MonoBehaviour
{
    [SerializeField]
    AudioClip[] cusses;

    bool cussing = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddTorque(Random.Range(-4, 4));


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<SecretPlayer>() !=null && !cussing)
        {
            StartCoroutine(Cuss());
            SecretPlayer obj = collision.gameObject.GetComponent<SecretPlayer>();
            obj.moving = false;
            obj.body.velocity = Vector2.zero;
  
        }
    }

    IEnumerator Cuss()
    {
        cussing = true;
        GetComponent<AudioSource>().PlayOneShot(cusses[Random.Range(0,cusses.Length)]);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
