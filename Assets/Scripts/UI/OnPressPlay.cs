using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnPressPlay : MonoBehaviour
{
    public void OnPlayPressed(){
        Debug.Log("Remember to check the build order");
        SceneManager.LoadScene(0);
    }
}
