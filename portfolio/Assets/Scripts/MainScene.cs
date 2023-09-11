using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    [SerializeField] GameObject player;
    private byte m_Scene; //1 school -- 2 project
    private void Start()
    {
        if (m_Scene == 0)
        {
            player.transform.position = new Vector3(-10.0f, 0.0f, 0.0f);
        }

        if (m_Scene == 1)
        {
            player.transform.position = new Vector3(4.0f, 19.0f, 0.0f);
        }

        if (m_Scene == 2)
        {
            player.transform.position = new Vector3(25.0f, 5.5f, 0.0f);
        }
    }

    private void Update()
    {
        Debug.Log(m_Scene);
    }

    public void SetScene(byte scene)
    {
        m_Scene = scene;
    }
}
