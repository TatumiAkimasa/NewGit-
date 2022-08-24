using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneMove : MonoBehaviour
{
    public string move_Scene;
    public Text Title,text;

    public AudioClip Souce1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  Scene_move_START()
    {
        StartCoroutine(Count());
    }
    public void Scene_move()
    {
        SceneManager.LoadScene(move_Scene);
    }

    private IEnumerator Count()
    {
        for(int i=0;i!=10;i++)
        {
            if(i==1)
            {
                Destroy(this.GetComponent<Image>());
                Destroy(this.GetComponent<Button>());
                Destroy(text);
                this.GetComponent<AudioSource>().PlayOneShot(Souce1);
                Title.text = "3";
                yield return new WaitForSeconds(1.0f);
            }
            if(i==2)
            {
                Title.text = "2";
                yield return new WaitForSeconds(1.0f);
            }
            if (i == 3)
            {
                Title.text = "1";
                yield return new WaitForSeconds(1.0f);
            }
            if(i==4)
                SceneManager.LoadScene(move_Scene);
        }
        
    }
}
