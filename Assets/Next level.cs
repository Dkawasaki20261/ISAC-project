using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
public int LevelNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
	{
		Application.Quit();
	}

    }
    
    void OnTriggerEnter(Collider other)
    {
	if(other.tag == "Player")
        {
		SceneManager.LoadScene(LevelNum);
        }
    }


}
