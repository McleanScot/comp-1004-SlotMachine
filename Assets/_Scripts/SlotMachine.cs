using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlotMachine : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Panel.gameObject.SetActive(false);
        PanelJackPot.gameObject.SetActive(false);

        
    }
	
	private int playerMoney = 1000;
	private int winnings = 0;
	private int jackpot = 5000;
	private float turn = 0.0f;
	private int playerBet = 10;
	private float winNumber = 0.0f;
	private float lossNumber = 0.0f;
	private string[] spinResult;
	private string fruits = "";
	private float winRatio = 0.0f;
	private float lossRatio = 0.0f;
	private int grapes = 0;
	private int bananas = 0;
	private int oranges = 0;
	private int cherries = 0;
	private int bars = 0;
	private int bells = 0;
	private int sevens = 0;
	private int blanks = 0;

    public Text CreditText;
    public Text BetText;
    public Text WinningsText;
    public Text MessageText;
    public Text JackPotText;

    public Image Panel;
    public Image PanelJackPot;
    public Image ReelOne;
    public Image ReelTwo;
    public Image ReelThree;
    public Image SpinButton;

    public Sprite Blanks;
    public Sprite Grapes;
    public Sprite Bananas;
    public Sprite Oranges;
    public Sprite Cherries;
    public Sprite Bars;
    public Sprite Bells;
    public Sprite Sevens;



    /* Utility function to show Player Stats */
    private void showPlayerStats()
	{
		winRatio = winNumber / turn;
		lossRatio = lossNumber / turn;
		string stats = "";
		stats += ("Jackpot: " + jackpot + "\n");
		stats += ("Player Money: " + playerMoney + "\n");
		stats += ("Turn: " + turn + "\n");
		stats += ("Wins: " + winNumber + "\n");
		stats += ("Losses: " + lossNumber + "\n");
		stats += ("Win Ratio: " + (winRatio * 100) + "%\n");
		stats += ("Loss Ratio: " + (lossRatio * 100) + "%\n");
		Debug.Log(stats);
	}

	/* Utility function to reset all fruit tallies*/
	private void resetFruitTally()
	{
		grapes = 0;
		bananas = 0;
		oranges = 0;
		cherries = 0;
		bars = 0;
		bells = 0;
		sevens = 0;
		blanks = 0;
	}

	/* Utility function to reset the player stats */
	private void resetAll()
	{
		playerMoney = 1000;
		winnings = 0;
		jackpot = 5000;
		turn = 0;
		playerBet = 10;
		winNumber = 0;
		lossNumber = 0;
		winRatio = 0.0f;
        WinningsText.text = "0";
	}

	/* Check to see if the player won the jackpot */
	private void checkJackPot()
	{
		/* compare two random values */
		var jackPotTry = Random.Range (1, 51);
		var jackPotWin = Random.Range (1, 51);
		if (jackPotTry == jackPotWin)
		{
			Debug.Log("You Won the $" + jackpot + " Jackpot!!");
			playerMoney += jackpot;
            winnings = 5000;
            JackPotText.text = "You Won the $" + jackpot + " Jackpot!!";
            PanelJackPot.gameObject.SetActive(true);

        }
	}

	/* Utility function to show a win message and increase player money */
	private void showWinMessage()
	{
		playerMoney += winnings;
		Debug.Log("You Won: $" + winnings);
		resetFruitTally();
		checkJackPot();
	}

	/* Utility function to show a loss message and reduce player money */
	private void showLossMessage()
	{
		playerMoney -= playerBet;
		Debug.Log("You Lost!");
		resetFruitTally();
	}

	/* Utility function to check if a value falls within a range of bounds */
	private bool checkRange(int value, int lowerBounds, int upperBounds)
	{
		return (value >= lowerBounds && value <= upperBounds) ? true : false;

	}

	/* When this function is called it determines the betLine results.
    e.g. Bar - Orange - Banana */
	private string[] Reels()
	{
		string[] betLine = { " ", " ", " " };
		int[] outCome = { 0, 0, 0 };

		for (var spin = 0; spin < 3; spin++)
		{
			outCome[spin] = Random.Range(1,65);

			if (checkRange(outCome[spin], 1, 27)) {  // 41.5% probability
				betLine[spin] = "blank";
				blanks++;
            }
			else if (checkRange(outCome[spin], 28, 37)){ // 15.4% probability
				betLine[spin] = "Grapes";
				grapes++;
            }
			else if (checkRange(outCome[spin], 38, 46)){ // 13.8% probability
				betLine[spin] = "Banana";
				bananas++;
            }
			else if (checkRange(outCome[spin], 47, 54)){ // 12.3% probability
				betLine[spin] = "Orange";
				oranges++;
            }
			else if (checkRange(outCome[spin], 55, 59)){ //  7.7% probability
				betLine[spin] = "Cherry";
				cherries++;
            }
			else if (checkRange(outCome[spin], 60, 62)){ //  4.6% probability
				betLine[spin] = "Bar";
				bars++;
            }
			else if (checkRange(outCome[spin], 63, 64)){ //  3.1% probability
				betLine[spin] = "Bell";
				bells++;
            }
			else if (checkRange(outCome[spin], 65, 65)){ //  1.5% probability
				betLine[spin] = "Seven";
				sevens++;
            }

            if(checkRange(outCome[0], 1, 27))
            {
                ReelOne.sprite = Resources.Load<Sprite>("blank");
            }
            else if (checkRange(outCome[0], 28, 37))
            {
                ReelOne.sprite = Resources.Load<Sprite>("grapes");
            }

            else if (checkRange(outCome[0], 38, 46))
            {
                ReelOne.sprite = Resources.Load<Sprite>("banana");
            }

            else if (checkRange(outCome[0], 47, 54))
            {
                ReelOne.sprite = Resources.Load<Sprite>("orange");
            }
            else if (checkRange(outCome[0], 55, 59))
            {
                ReelOne.sprite = Resources.Load<Sprite>("cherry");
            }
            else if (checkRange(outCome[0], 60, 62))
            {
                ReelOne.sprite = Resources.Load<Sprite>("bar");
            }
            else if (checkRange(outCome[0], 63, 64))
            {
                ReelOne.sprite = Resources.Load<Sprite>("bell");
            }
            else if (checkRange(outCome[0], 65, 65))
            {
                ReelOne.sprite = Resources.Load<Sprite>("seven");
            }

            if (checkRange(outCome[1], 1, 27))
            {
                ReelTwo.sprite = Resources.Load<Sprite>("blank");
            }
            else if (checkRange(outCome[1], 28, 37))
            {
                ReelTwo.sprite = Resources.Load<Sprite>("grapes");
            }
            else if (checkRange(outCome[1], 38, 46))
            {
                ReelTwo.sprite = Resources.Load<Sprite>("banana");
            }

            else if (checkRange(outCome[1], 47, 54))
            {
                ReelTwo.sprite = Resources.Load<Sprite>("orange");
            }
            else if (checkRange(outCome[1], 55, 59))
            {
                ReelTwo.sprite = Resources.Load<Sprite>("cherry");
            }
            else if (checkRange(outCome[1], 60, 62))
            {
                ReelTwo.sprite = Resources.Load<Sprite>("bar");
            }
            else if (checkRange(outCome[1], 63, 64))
            {
                ReelTwo.sprite = Resources.Load<Sprite>("bell");
            }
            else if(checkRange(outCome[1], 65, 65))
            {
                ReelTwo.sprite = Resources.Load<Sprite>("seven");
            }

            if (checkRange(outCome[2], 1, 27))
            {
                ReelThree.sprite = Resources.Load<Sprite>("blank");
            }
            else if (checkRange(outCome[2], 28, 37))
            {
                ReelThree.sprite = Resources.Load<Sprite>("grapes");
            }
            else if (checkRange(outCome[2], 38, 46))
            {
                ReelThree.sprite = Resources.Load<Sprite>("banana");
            }

            else if (checkRange(outCome[2], 47, 54))
            {
                ReelThree.sprite = Resources.Load<Sprite>("orange");
            }
            else if (checkRange(outCome[2], 55, 59))
            {
                ReelThree.sprite = Resources.Load<Sprite>("cherry");
            }
            else if (checkRange(outCome[2], 60, 62))
            {
                ReelThree.sprite = Resources.Load<Sprite>("bar");
            }
            else if (checkRange(outCome[2], 63, 64))
            {
                ReelThree.sprite = Resources.Load<Sprite>("bell");
            }
            else if(checkRange(outCome[2], 65, 65))
            {
                ReelThree.sprite = Resources.Load<Sprite>("seven");
            }
        }
		return betLine;
	}

    public void CloseGame()
    {
        Application.Quit();
    }

	/* This function calculates the player's winnings, if any */
	private void determineWinnings()
	{
		if (blanks == 0)
		{
			if (grapes == 3)
			{
				winnings = playerBet * 10;
			}
			else if (bananas == 3)
			{
				winnings = playerBet * 20;
			}
			else if (oranges == 3)
			{
				winnings = playerBet * 30;
			}
			else if (cherries == 3)
			{
				winnings = playerBet * 40;
			}
			else if (bars == 3)
			{
				winnings = playerBet * 50;
			}
			else if (bells == 3)
			{
				winnings = playerBet * 75;
			}
			else if (sevens == 3)
			{
				winnings = playerBet * 100;
			}
			else if (grapes == 2)
			{
				winnings = playerBet * 2;
			}
			else if (bananas == 2)
			{
				winnings = playerBet * 2;
			}
			else if (oranges == 2)
			{
				winnings = playerBet * 3;
			}
			else if (cherries == 2)
			{
				winnings = playerBet * 4;
			}
			else if (bars == 2)
			{
				winnings = playerBet * 5;
			}
			else if (bells == 2)
			{
				winnings = playerBet * 10;
			}
			else if (sevens == 2)
			{
				winnings = playerBet * 20;
			}
			else if (sevens == 1)
			{
				winnings = playerBet * 5;
			}
			else
			{
				winnings = playerBet * 1;
			}
			winNumber++;
			showWinMessage();
        }
		else
		{
			lossNumber++;
			showLossMessage();
            winnings = 0;
        }

	}
    public void OnBetOneClick()
    {
        BetText.text = (playerBet = playerBet + 1).ToString(); ;
        Debug.Log("button clicked");
    }
    public void OnBetTwoClick()
    {
        BetText.text = (playerBet = playerBet + 2).ToString(); ;
        Debug.Log("button clicked");
    }
    public void OnBetFiveClick()
    {
        BetText.text = (playerBet = playerBet + 5).ToString(); ;
        Debug.Log("button clicked");
    }
    public void OnBetTenClick()
    {
        BetText.text = (playerBet = playerBet + 10).ToString(); ;
        Debug.Log("button clicked");
    }
    public void OnBetTwentyFiveClick()
    {
        BetText.text = (playerBet = playerBet + 25).ToString(); ;
        Debug.Log("button clicked");
    }
    public void OnBetFiftyClick()
    {
        BetText.text = (playerBet = playerBet + 50).ToString(); ;
        Debug.Log("button clicked");
    }
    public void OnBetOneHundredClick()
    {
        BetText.text = (playerBet = playerBet + 100).ToString(); ;
        Debug.Log("button clicked");
    }
    public void OnBetFiveHundredClick()
    {
        BetText.text = (playerBet = playerBet + 500).ToString(); ;
        Debug.Log("button clicked");
    }
    public void ResetStats()
    {
        resetAll();
        BetText.text = playerBet.ToString();
        CreditText.text = playerMoney.ToString();
        Panel.gameObject.SetActive(false);
        MessageText.text = "";
    }

	public void OnSpinButtonClick()
	{

		if (playerMoney == 0)
		{
            Panel.gameObject.SetActive(true);
            MessageText.text = "You have run out of credits! Please reset or quit the game.";

        }
		else if (playerBet > playerMoney)
		{
			Debug.Log("You don't have enough Money to place that bet.");
            MessageText.text = "You don't have enough Money to place that bet.";
            Panel.gameObject.SetActive(true);
            playerBet = 10;
            SpinButton.sprite = Resources.Load<Sprite>("spin_pressed");

        }

		else if (playerBet < 0)
		{
			Debug.Log("All bets must be a positive $ amount.");
		}
		else if (playerBet <= playerMoney)
		{
			spinResult = Reels();
			fruits = spinResult[0] + " - " + spinResult[1] + " - " + spinResult[2];
			Debug.Log(fruits);
			determineWinnings();
			turn++;
			showPlayerStats();
            playerBet = 10;
            MessageText.text = "";
            Panel.gameObject.SetActive(false);
            SpinButton.sprite = Resources.Load<Sprite>("spin");
        }
		else
		{
			Debug.Log("Please enter a valid bet amount");
		}

        BetText.text = playerBet.ToString();
        CreditText.text = playerMoney.ToString();
        WinningsText.text = winnings.ToString();

        if(winnings != 5000)
        {
            JackPotText.text = "";
            PanelJackPot.gameObject.SetActive(false);
        }
    }


    
}
