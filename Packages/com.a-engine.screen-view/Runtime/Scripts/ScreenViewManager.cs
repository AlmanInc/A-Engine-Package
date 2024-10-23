using System;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace AEngine
{
    public class ScreenViewManager : MonoBehaviour
    {
        public static event OpenScreenView OnOpenScreenView;
        public static event DeactivateScreenView OnDeactivateScreenView;
        public static event CloseScreenView OnCloseScreenView;

        private static ScreenViewConfiguration configuration;
        private static TransitionData transitionData;
        private static TransitionData developmentBackTransition;

        //==================================================
        // Fields
        //==================================================

        [SerializeField] private ScreenView defaultScreenView;

        private bool isInitialized;

        //==================================================
        // Properties
        //==================================================

        private string CurrentScene => SceneManager.GetActiveScene().name;

        //==================================================
        // Methods
        //==================================================

        private void Awake()
        {
            if (!isInitialized)
            {
                configuration = Resources.Load("Screen View Configuration") as ScreenViewConfiguration;
                isInitialized = true;
            }
        }

        private void Start()
        {
            OnDeactivateScreenView?.Invoke();
            OnCloseScreenView?.Invoke();

            if (string.IsNullOrEmpty(transitionData.screenView))
            {
                if (defaultScreenView != null)
                {
                    string screenView = defaultScreenView.Kind;
                    OnOpenScreenView(screenView, transitionData.paramsData);
                }
                else
                {
                    Debug.LogError("Couldn't make transition");
                }
            }
            else
            {
                OnOpenScreenView(transitionData.screenView, transitionData.paramsData);
            }
        }

        private void OnDestroy()
        {
            OnCloseScreenView?.Invoke();

            OnOpenScreenView = null;
            OnDeactivateScreenView = null;
            OnCloseScreenView = null;
        }

        public void CloseScreenViews() => OnCloseScreenView?.Invoke();
        
        public void OpenScreenView(Enum scene, Enum screenView, ParamsData paramsData = null) => OpenScreenView(scene.ToString(), screenView.ToString(), paramsData);

        public void OpenScreenView(string scene, string screenView, ParamsData paramsData = null)
        {
            transitionData.scene = scene;
            transitionData.screenView = screenView;
            transitionData.paramsData = paramsData;

            OpenScreenView();
        }

        public void OpenScreenView(Enum screenView, ParamsData paramsData = null) => OpenScreenView(screenView.ToString(), paramsData);
        
        public void OpenScreenView(string screenView, ParamsData paramsData = null)
        {
            transitionData.scene = string.Empty;
            transitionData.screenView = screenView;
            transitionData.paramsData = paramsData;

            OpenScreenView();
        }

        public void OpenScene(Enum scene, ParamsData paramsData = null) => OpenScene(scene.ToString(), paramsData);

        public void OpenScene(string scene, ParamsData paramsData = null)
        {
            transitionData.scene = scene;
            transitionData.screenView = string.Empty;
            transitionData.paramsData = paramsData;

            OpenScreenView();
        }

        private void OpenScreenView()
        {
            OnDeactivateScreenView?.Invoke();

            if (string.IsNullOrEmpty(transitionData.scene) || transitionData.scene == CurrentScene)
            {
                OnCloseScreenView?.Invoke();
                OnOpenScreenView?.Invoke(transitionData.screenView, transitionData.paramsData);
            }
            else
            {
                SceneManager.LoadSceneAsync(transitionData.scene);
            }
        }
    }
}