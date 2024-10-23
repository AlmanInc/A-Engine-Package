using UnityEngine;

namespace AEngine
{
    [CreateAssetMenu(menuName = "A-Engine/Screen View Configuration", fileName = "Screen View Configuration")]
    public class ScreenViewConfiguration : ScriptableObject
    {
        [Header("Initial Scene Settings")]
        [SerializeField] private bool loadInitialScene;
        [SerializeField] private string initialScene;
        [SerializeField] private string initialScreenView;
        
        public bool LoadInitialScene => loadInitialScene;

        public string InitialScene => initialScene;

        public string InitialScreenView => initialScreenView;
    }
}