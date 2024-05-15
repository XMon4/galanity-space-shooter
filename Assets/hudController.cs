using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class hudController : MonoBehaviour
{

    [SerializeField] private GameObject _panel;
    private bool isPaused;
    private bool respawning;
    public int hp;
    [SerializeField] private TextMeshProUGUI _panelMessage;
    [SerializeField] private List<GameObject> _hpBars= new List<GameObject>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        hp = 3;
        isPaused = false;
        _panel.SetActive(isPaused);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = _hpBars.Count - 1; i >= 0; i--)
        {
            _hpBars[i].SetActive(hp>i);
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (hp > 0)
            {
                if (!respawning)
                {
                    _panelMessage.text = "PAUSED";
                    hudPause();
                }
            }
        }
    }

    private void hudPause()
    {
        isPaused = !isPaused;
        _panel.SetActive((isPaused));
        Time.timeScale = isPaused ? 0 : 1;
    }

    public void losHP()
    {    
        
        hp--;   
        if(hp<0)
        { _panelMessage.text="GAME OVER";
            hudPause();
        }
        else
        {Time.timeScale = 0;
            StartCoroutine(Delay(1f));
        }

    }

    public void lvlClear()
    {
        _panelMessage.text = "Enemy Felled";
        hudPause();
    }
  
    private IEnumerator Delay(float delay)
    {
        respawning = true;
        yield return new WaitForSecondsRealtime(delay);
    Time.timeScale = 1;
    respawning = false;
    }

    public void buttonRestart(int restartlvl)
    {
        SceneManager.LoadScene(restartlvl);
        hudPause();
    }

    public void buttonReturn()
    {
        SceneManager.LoadScene(0);
        hudPause();
    }
    
}
