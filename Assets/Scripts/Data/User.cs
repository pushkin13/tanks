
public class User
{
	private readonly int id = 0;
	private string currentLevel = "";
	private string currentTank = "";

	public User(int id,		string currentLevel,		string currentTank)	{		this.id = id;		this.currentLevel = currentLevel;		this.currentTank = currentTank;	}

	public int ID => id;
	public string CurrentTank => currentTank;
	public string CurrentLevel	{		get { return currentLevel; }		set { currentLevel = value; }	}


	public static User TestUser ()	{		return new User(1, "level1", "tank1");	}
}
