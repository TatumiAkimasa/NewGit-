using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetClickedGameObject : MonoBehaviour
{
    GameObject clickedGameObject;
    private AddScore add_script;

    public AudioClip Souce1;

    private int mainPoint, SubPoint;

    private void Start()
    {
        add_script = GameObject.Find("Score_PL").GetComponent<AddScore>();
        add_script.Change_Score(0);
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            this.GetComponent<AudioSource>().PlayOneShot(Souce1);
            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;
            }

            if (clickedGameObject != null)
            {
                mainPoint = 0;
                SubPoint = 0;

                Debug.Log(clickedGameObject.name);

                if (clickedGameObject.tag.Contains("1") == true)
                {
                    mainPoint = 4;
                }
                else if ((clickedGameObject.tag.Contains("2") == true))
                {
                    mainPoint = 3;
                }
                else if ((clickedGameObject.tag.Contains("3") == true))
                {
                    mainPoint = 2;
                }
                else if ((clickedGameObject.tag.Contains("4") == true))
                {
                    mainPoint = 1;
                }

                if ((clickedGameObject.tag.Contains("RScore") == true))
                {
                    SubPoint = 2;
                    add_script.addScore(mainPoint, SubPoint);
                    if (clickedGameObject.GetComponent<Taeget_Sumon>() == null)
                    {
                        clickedGameObject.transform.parent.GetComponent<Taeget_Sumon>().Destroy();
                    }
                    else
                        clickedGameObject.GetComponent<Taeget_Sumon>().Destroy();
                }
                else if ((clickedGameObject.tag.Contains("Score") == true))
                {
                    SubPoint = 1;
                    add_script.addScore(mainPoint, SubPoint);
                    if (clickedGameObject.GetComponent<Taeget_Sumon>() == null)
                    {
                        clickedGameObject.transform.parent.GetComponent<Taeget_Sumon>().Destroy();
                    }
                    else
                        clickedGameObject.GetComponent<Taeget_Sumon>().Destroy();
                }
                
            }

        }
    }
}
