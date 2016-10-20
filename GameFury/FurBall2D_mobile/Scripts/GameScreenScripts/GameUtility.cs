using UnityEngine;
using System.Collections;

public class GameUtility  {

	public static int Game_Level;
	public static int Deficulty_Level;
	public static float Game_Deficulty_ThreSold;
	//Game Setting Mobile
	public static bool IsAndroid=false;
	// Game Score 
	public static int GAME_SCORE=0;
	// Game Sound 
	public static bool GameSoundOn=true;
	public static float GameSoundVolume=1;
	// Game Score 
	public static float GAME_SCORE_BAR_VALUE=0;
	//Next Targated Point
	public static float NextTargetPoint=100f;
	//Next Targated Point
	public static float PreviousTargetPoint=0;
	//Obstracle Point
	public  static int Level_ObastraclePoint=7;
	//Public Current ObstraclePoint
	public static int CurrentObstarclePoint=0;
	//Game Time
	public static int GAME_TIME=0;
	//Pingo Movement Speed
	public static float pingoMovmentSpeed=6f;
	public static float accelarometerSpped=0;
	//public Game Record
	public static int [] GameRecord={0,0,0,0,0};
	//Screen Number
	public static int SPLASH_SCREEN = 0;
	public static int MENU_SCREEN = 1;
	public static int GAME_SCREEN = 2;



}
