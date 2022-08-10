using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;
public class UIController : MonoBehaviour
{
    
    [SerializeField] GameObject shark => GameObject.Find("Shark");
    SharkController sharkScript => shark.GetComponent<SharkController>();

    [SerializeField] GameObject hpBar;

    [SerializeField] GameObject point;

    [SerializeField] GameObject pointImage;

    [SerializeField] GameObject Win,Lose;

    
    void Awake()
    {
        Time.timeScale = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.GetComponent<Slider>().value = sharkScript.hp;
        point.GetComponent<Text>().text = "" + sharkScript.point;


        if (sharkScript.hp >= 3)
        {
            hpBar.SetActive(false);
            pointImage.SetActive(false);
            Win.SetActive(false);
            Lose.SetActive(true);
            Time.timeScale = 0;
        }
        if (sharkScript.isFinish == true)
        {
            hpBar.SetActive(false);
            pointImage.SetActive(false);
            Win.SetActive(true);
            Lose.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    
}
