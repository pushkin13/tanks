using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour
{
    [SerializeField]
    private TankControls tankControls;
    [SerializeField]
    private Transform levelContainer;
    [SerializeField]
    private TankPanel tankPanel;

    private MonsterSpawner spawner;
    private Tank tank;

    private bool isGameOver = false;
    private Vector3 sizeLevel;

    private void Start()
    {
        var levelPrefabPath = $"{Constants.FolderLevels}/{GameData.User.CurrentLevel}";
        GameObject levelPrefab = Resources.Load(levelPrefabPath, typeof(GameObject)) as GameObject;
        var level = Instantiate(levelPrefab, levelContainer, false);        sizeLevel = level.GetComponent<Renderer>().bounds.size;
        var levelInfo = GameData.Dict.GetLevel(GameData.User.CurrentLevel);
        spawner = level.GetComponent<MonsterSpawner>();
        spawner.Init(levelInfo, sizeLevel);

        Tank tankPrefab = Resources.Load($"{Constants.FolderTanks}/{GameData.User.CurrentTank}", typeof(Tank)) as Tank;
        tank = Tank.Instantiate(tankPrefab, levelContainer.transform, false);
        var tankInfo = GameData.Dict.GetTank(GameData.User.CurrentTank);
        tank.Init(tankInfo, sizeLevel);

        tankPanel.SetMaxHP(tankInfo.HP);
        tankPanel.SetCurrentHP(tankInfo.HP);
        tankControls.Init(tank);		Tank.OnChangeHP += Tank_OnChangeHP;
    }	private void Tank_OnChangeHP(int newHP)	{        tankPanel.SetCurrentHP(newHP);	}	private void OnDestroy()	{        Tank.OnChangeHP -= Tank_OnChangeHP;    }	private void Update()    {        if (isGameOver)            return;        if (spawner == null)            return;        CheckDeathMonsters();        foreach (var m in spawner.Monsters)		{            m.MoveToPos(tank.transform.position);		}        CheckGameOver();    }

    private void CheckDeathMonsters ()	{        spawner.Monsters.RemoveAll(m => m.IsDead());	}

    private void CheckGameOver()	{        if (tank.IsDead ())		{            isGameOver = true;            Destroy(tankControls);            SceneManager.LoadScene(Constants.StartScene, LoadSceneMode.Single);		}	}
}
