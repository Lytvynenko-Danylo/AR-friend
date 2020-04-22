using System.Linq;
using UnityEngine;

namespace MyScripts
{
    public class FinalController : MonoBehaviour
    {
        [SerializeField]
        Animator animator;
        private static string[] commands = { "wake up", "make up", "hi", "dance", "then", "dans", "dence", "stop", "store" };
        private static string[] danceStyles = { "Jazz Dancing", "Breakdance Uprock Var 1", "Hokey Pokey",
        "Swing Dancing", "Chicken Dance", "Dancing Maraschino Step" };
        private int count = 0;
        private bool CharapterShowed;

        public GameObject Explosion;
        void Start()
        {
            gameObject.SetActive(false);
            animator.GetComponent<Animator>();
            CharapterShowed = false;
            Explosion.SetActive(false);
        }

        public void Actions(string usercommands)
        {
            string text = usercommands.Trim().ToLower();
            foreach (var item in commands)
            {
                if (text.Contains(item))
                {
                    text = item;
                    break;
                }
            }

            switch (text)
            {
                case "wake up":
                case "make up":
                    if (!CharapterShowed)
                    {
                        //chara.
                        //animator.SetBool("ShowFinal", true);
                        Explosion.SetActive(true);
                        Invoke("ShowFinal", 2f);
                    }
                    break;
                case "hi":
                    animator.Play("hi", -1, 0f);
                    break;
                case "dance":
                case "dans":
                case "dence":
                case "then":
                    animator.Play(danceStyles[count], -1, 0f);
                    count++;
                    if (count >= danceStyles.Length)
                    {
                        count = 0;
                    }
                    // for (int i = 0; i < danceStyles.Length; i++)
                    // {
                    //     count = i;
                    //     if (count == 0)
                    //     {
                    //         animator.Play(danceStyles[count], -1, 0f);
                    //     }
                    //     else
                    //     {
                    //         Invoke("ShowDance", 15f);
                    //     }
                    // }
                    break;
                case "stop":
                case "store":
                    animator.Play("Idle", -1, 0f);
                    break;
                default:
                    break;
            }
        }
        private void ShowFinal()
        {
            Explosion.SetActive(false);
            gameObject.SetActive(true);
            CharapterShowed = true;
        }
        // private void ShowDance()
        // {
        //     animator.Play(danceStyles[count], -1, 0f);
        //     if (count >= danceStyles.Length)
        //     {
        //         count = 0;
        //     }
        // }
    }
}