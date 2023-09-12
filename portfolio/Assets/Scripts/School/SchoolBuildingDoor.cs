using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SchoolBuildingDoor : MonoBehaviour
{
    //private bool isSchoolBuilding = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //isSchoolBuilding = true;
            SceneManager.LoadScene("SchoolScene");
        }
    }
    //public bool GetIsSchoolBuilding()
    //{
    //    return isSchoolBuilding;
    //}
}
