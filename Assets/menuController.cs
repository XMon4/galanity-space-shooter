using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuController : MonoBehaviour
{
    [SerializeField] private GameObject _button1;
    [SerializeField] private GameObject _button2;
    private bool activateButtons=false;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _button1.SetActive(false);
        _button2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartLevel(int l)
    {
        SceneManager.LoadScene(l);
    }

    public void StartButton()
    {
        activateButtons = !activateButtons;
        _button1.SetActive(activateButtons);
        _button2.SetActive(activateButtons);
    }

    public void ExitGame()
    {
        Application.Quit();
        print("bye");
    }
    
}
