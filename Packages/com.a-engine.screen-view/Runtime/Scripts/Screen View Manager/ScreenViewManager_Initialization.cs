using UnityEngine;

namespace AEngine
{
    public partial class ScreenViewManager : MonoBehaviour
    {
        private void ConfigureState()
        {
            if (state != TransitionStates.None)
            {
                return;
            }

            if (!isInitialized)
            {
                isInitialized = true;
                configuration = Resources.Load("Screen View Configuration") as ScreenViewConfiguration;

                if (configuration != null && configuration.NeedLoadInitialScene)
                {
                    if (string.IsNullOrEmpty(configuration.InitialScene) || string.IsNullOrEmpty(configuration.InitialScreenView))
                    {
                        Debug.LogError("Set initial scene and initial screen view at Screen View Settings asset");
                        state = TransitionStates.Default;
                    }
                    else
                    {
                        // что если текущая сцена равна сцене инициализации?
                        state = TransitionStates.DevelopmentInitial;
                    }
                }
                else
                {
                    state = TransitionStates.Default;
                }
            }
        }

        private void Initialize()
        {
            
            switch (state)
            {
                case TransitionStates.Default:
                    MakeDefaultTransition();
                    break;


                case TransitionStates.DevelopmentInitial:
                    MakeDevelopmentInitialTransition();
                    break;


                case TransitionStates.DevelopmentBack:
                    MakeDevelopmentBackTransition();
                    break;


                case TransitionStates.Transition:
                    MakeBaseTransition();
                    break;
            }

            /*
            if (!isLoadedConfiguration)
            {
                isLoadedConfiguration = true;

                configuration = Resources.Load("Screen View Configuration") as ScreenViewConfiguration;

                if (configuration != null && configuration.NeedLoadInitialScene)
                {
                    developmentBackTransition.scene = CurrentScene;
                    developmentBackTransition.screenView = defaultScreenView.Kind;

                    OpenScreenView(configuration.InitialScene, configuration.InitialScreenView, ParamsData.None);
                }
            }
            */
        }

        private void MakeDefaultTransition()
        {

        }

        private void MakeDevelopmentInitialTransition()
        {

        }

        private void MakeDevelopmentBackTransition()
        {

        }

        private void MakeBaseTransition()
        {

        }
    }
}