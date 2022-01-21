using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
	private bool IsInit = false;

	private void Start()	{		var user = User.TestUser();		var dict = Dict.TestDict();		GameData.Init(user, dict);		IsInit = true;	}


	public void StartLevel()	{		if (!IsInit)			return;		SceneManager.LoadScene(Constants.LevelScene, LoadSceneMode.Single);	}
}
