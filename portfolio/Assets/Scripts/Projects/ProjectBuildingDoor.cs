using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectBuildingDoor : MonoBehaviour
{
    //private bool isProjectsBuilding = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //isProjectsBuilding = true;
            SceneManager.LoadScene("ProjectsScene");
        }
    }

    //public bool GetIsProjectsBuilding()
    //{
    //    return isProjectsBuilding;
    //}
}
