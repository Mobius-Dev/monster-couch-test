using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform Player => _player;
    [SerializeField] private Transform _player;
    public Bounds LevelBounds => _levelBounds;
    [SerializeField] private Bounds _levelBounds;



    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(StaticData.BACK_KEY))
        {
            SceneManager.LoadScene(StaticData.MENU_SCENE_NAME, LoadSceneMode.Single);
        }
    }
}
