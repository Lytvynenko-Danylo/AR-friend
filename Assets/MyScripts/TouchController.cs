using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TouchController : MonoBehaviour
{
    public GameObject Final;
    public GameObject Explosion;
    public Animator animator;
    private GameObject DanceBtn;
    private GameObject LampBtn;
    private GameObject DanceText;
    private int count = 0;
    private static string[] danceStyles = { "Jazz Dancing", "Breakdance Uprock Var 1", "Hokey Pokey",
        "Swing Dancing", "Chicken Dance", "Dancing Maraschino Step" };
    // Start is called before the first frame update
    void Start()
    {
        animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name.ToString() == "MagicLamp" && Final.activeInHierarchy == false)
                {
                    Explosion.SetActive(true);
                    Invoke("ShowFinal", 2f);
                }
                else if (hit.transform.name.ToString() == "Final" && Final.activeInHierarchy == true)
                {
                    animator.Play("hi", -1, 0f);
                }
            }
        }
#elif UNITY_ANDROID
        if ((Input.GetTouch(0).phase == TouchPhase.Stationary) ||
        (Input.GetTouch(0).phase == TouchPhase.Moved) && (Input.GetTouch(0).deltaPosition.magnitude < 1.2f))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // if (hit.transform.name.ToString() == "MagicLamp" && Final.activeInHierarchy == false)
                // {
                //     Explosion.SetActive(true);
                //     Invoke("ShowFinal", 2f);
                // }
                 if (hit.transform.name.ToString() == "Final" && Final.activeInHierarchy == true)
                {
                    animator.Play("hi", -1, 0f);
                }
            }
        }
        if((Input.GetTouch(0).phase == TouchPhase.Moved) && (Input.GetTouch(0).deltaPosition.magnitude > 3f)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name.ToString() == "MagicLamp" && Final.activeInHierarchy == false)
                {
                    Explosion.SetActive(true);
                    Invoke("ShowFinal", 2f);
                }
                 if (hit.transform.name.ToString() == "Final" && Final.activeInHierarchy == true)
                {
                    animator.Play(danceStyles[count], -1, 0f);
                                             count++;
                    if (count >= danceStyles.Length)
                    {
                        count = 0;
                    }
                }
            }
        }
#endif
    }

    private void ShowFinal()
    {
        Explosion.SetActive(false);
        Final.SetActive(true);
    }
}
