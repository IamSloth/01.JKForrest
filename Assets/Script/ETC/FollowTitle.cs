using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.CrossPlatformInput;

public class FollowTitle : MonoBehaviour
{
    Transform n;
    public GameObject go;
    public TextMeshProUGUI startText;

    private float timer;
    bool isTitle;

 /*   public void GameQuit()
    {
        Application.Quit();
        Debug.Log("isQuit?");
    }
*/

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        n = GameObject.Find("Nsheep").transform;        
        isTitle = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = n.position + new Vector3(0, 8, 5);

        
        timer += Time.deltaTime;
        if (isTitle == false && timer >= 1 && startText.color.a >= 0.01)
        {
            startText.color = Color.Lerp(startText.color, new Color (0,0,0,0), 5 * Time.deltaTime);
            //isTitle = true;
            Debug.Log("1" + isTitle + startText.color.a);
            //StartCoroutine("FadeOut");
            
        }

        else if(isTitle == false && startText.color.a <= 0.1)
        {
            isTitle = true;
            timer = 0;
            Debug.Log("2" + isTitle + startText.color.a);
        }

        else if (isTitle == true && timer >= 1 && startText.color.a <= 0.99)
        {
            startText.color = Color.Lerp(startText.color, new Color(1, 1, 1, 1), 5 * Time.deltaTime);
            //isTitle = true;
            Debug.Log("3" + isTitle + startText.color.a);
            //StartCoroutine("FadeOut");
        }

        else if (isTitle == true && startText.color.a >= 0.99)
        {
            isTitle = false;
            timer = 0;
            Debug.Log("4" + isTitle + startText.color.a);
        }

        if (CrossPlatformInputManager.GetButton("Quit"))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            Debug.Log("isQuit?");
#else
                Application.Quit();                           
#endif
        }


    }

    
    IEnumerator FadeOut()
    {
        for (int i = 10; i>= 0; i--)
        {
            float f = i / 10.0f;
            Color c = startText.color;
            c.a = f;
            startText.color = c;
            yield return new WaitForSeconds(0.1f);
            Debug.Log(isTitle);
        }
        isTitle = true;
    }

    IEnumerator FadeIn()
    {
        for (int i = 0; i <= 10; i++)
        {
            float f = i / 10.0f;
            Color c = startText.color;
            c.a = f;
            startText.color = c;
            yield return new WaitForSeconds(0.1f);
        }
        isTitle = false;

    }
}


