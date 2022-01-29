using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    public static HUD m_hud;
    public static Counter m_counter;

    //Camera Data
    Camera m_camera;
    float m_minFOV = 0;
    float m_maxFOV = 90;

    enum SceneState
    {
        ssMAIN_MENU = 0,
        ssDEATH_MENU = 1,
        ssWIN_MENU = 2,
        ssOPTIONS_MENU = 3,
        ssLEVEL_X = 4 
	} SceneState m_sceneState;

    // Start is called before the first frame update
    void Awake()
    {
        //constant in all scenes
        DontDestroyOnLoad(gameObject);

        m_hud = gameObject.AddComponent<HUD>();
        m_counter = gameObject.AddComponent<Counter>();

        m_camera = Camera.main;
        m_camera.fieldOfView = m_maxFOV;
    }

    // Update is called once per frame
    void Update()
    {
        switch(m_sceneState)
        {
            case SceneState.ssMAIN_MENU:
            {
                
			}break;
            case SceneState.ssDEATH_MENU:
            {

			}break;
            case SceneState.ssWIN_MENU:
            {

			}break;
            case SceneState.ssOPTIONS_MENU:
            {
                
			}break;
            case SceneState.ssLEVEL_X:
            {
                    CalculateCameraFOV();
            }
            break;
            default:
            {
                    Debug.LogWarning("Manager::Update() -> not SceneState catchs for state = " + m_sceneState.ToString());
			}break;
		}
      
    }

    public void CalculateCameraFOV()
    {
        if (m_counter.IsCounting())
        {
            float distance = m_counter.GetDistanceThrough();
            float fov = (1 - distance) * (m_maxFOV - m_minFOV);
            m_camera.fieldOfView = fov;
        }
        else
        {
            m_camera.fieldOfView = m_maxFOV;
        }
    }

   
}
