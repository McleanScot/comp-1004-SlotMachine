using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlotMachine : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //setting panels to not be visible when game starts 
        Panel.gameObject.SetActive(false);
        PanelJackPot.gameObject.SetActive(false);
    }
	//variables
	private int playerMoney = 1000;
	private int winnings = 0;
	private int jackpot = 5000;
	private float turn = 0.0f;
	private int playerBet = 10;
	private float winNumber = 0.0f;
	private float lossNumber = 0.0f;
	private string[] spinResult;
	private string weapons = "";
	private float winRatio = 0.0f;
	private float lossRatio = 0.0f;
	private int usps = 0;
	private int tech9s = 0;
	private int deagles = 0;
	private int m4a4s = 0;
	private int ak47s = 0;
	private int awps = 0;
	private int knives = 0;
	private int chickens = 0;
    //text game objects
    public Text CreditText;
    public Text BetText;
    public Text WinningsText;
    public Text MessageText;
    public Text JackPotText;
    //image game object 
    public Image Panel;
    public Image PanelJackPot;
    public Image ReelOne;
    public Image ReelTwo;
    public Image ReelThree;
    public Image SpinButton;

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
        //changes fruits to weapons to fit the csgo theme i was going with
        usps = 0;
        tech9s = 0;
		deagles = 0;
        m4a4s = 0;
        ak47s = 0;
        awps = 0;
        knives = 0;
        chickens = 0;
	}

	/* Utility function to reset the player stats */
	private void resetAll()
	{
        // setting the winnings text to 0
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
				betLine[spin] = "Chicken";
                chickens++;
            }
			else if (checkRange(outCome[spin], 28, 37)){ // 15.4% probability
				betLine[spin] = "Usp";
                usps++;
            }
			else if (checkRange(outCome[spin], 38, 46)){ // 13.8% probability
				betLine[spin] = "Tech 9";
                tech9s++;
            }
			else if (checkRange(outCome[spin], 47, 54)){ // 12.3% probability
				betLine[spin] = "Deagle";
                deagles++;
            }
			else if (checkRange(outCome[spin], 55, 59)){ //  7.7% probability
				betLine[spin] = "M4A$";
                m4a4s++;
            }
			else if (checkRange(outCome[spin], 60, 62)){ //  4.6% probability
				betLine[spin] = "AK-47";
                ak47s++;
            }
			else if (checkRange(outCome[spin], 63, 64)){ //  3.1% probability
				betLine[spin] = "AWP";
                awps++;
            }
			else if (checkRange(outCome[spin], 65, 65)){ //  1.5% probability
				betLine[spin] = "Knife";
                knives++;
            }
            //setting the sprite of reelone based off the roll range that was RNG'd
            if(checkRange(outCome[0], 1, 27))
            {
                ReelOne.sprite = Resources.Load<Sprite>("chicken");
            }
            else if (checkRange(outCome[0], 28, 37))
            {
                ReelOne.sprite = Resources.Load<Sprite>("usp");
            }

            else if (checkRange(outCome[0], 38, 46))
            {
                ReelOne.sprite = Resources.Load<Sprite>("Tec9");
            }

            else if (checkRange(outCome[0], 47, 54))
            {
                ReelOne.sprite = Resources.Load<Sprite>("deagle");
            }
            else if (checkRange(outCome[0], 55, 59))
            {
                ReelOne.sprite = Resources.Load<Sprite>("m4a4");
            }
            else if (checkRange(outCome[0], 60, 62))
            {
                ReelOne.sprite = Resources.Load<Sprite>("Ak47");
            }
            else if (checkRange(outCome[0], 63, 64))
            {
                ReelOne.sprite = Resources.Load<Sprite>("awp");
            }
            else if (checkRange(outCome[0], 65, 65))
            {
                ReelOne.sprite = Resources.Load<Sprite>("knife");
            }
            //setting the sprite of reeltwo based off the roll range that was RNG'd
            if (checkRange(outCome[1], 1, 27))
            {
                ReelTwo.sprite = Resources.Load<Sprite>("chicken");
            }
            else if (checkRange(outCome[1], 28, 37))
            {
                ReelTwo.sprite = Resources.Load<Sprite>("usp");
            }
            else if (checkRange(outCome[1], 38, 46))
            {
                ReelTwo.sprite = Resources.Load<Sprite>("Tec9");
            }

            else if (checkRange(outCome[1], 47, 54))
            {
                ReelTwo.sprite = Resources.Load<Sprite>("deagle");
            }
            else if (checkRange(outCome[1], 55, 59))
            {
                ReelTwo.sprite = Resources.Load<Sprite>("m4a4");
            }
            else if (checkRange(outCome[1], 60, 62))
            {
                ReelTwo.sprite = Resources.Load<Sprite>("Ak47");
            }
            else if (checkRange(outCome[1], 63, 64))
            {
                ReelTwo.sprite = Resources.Load<Sprite>("awp");
            }
            else if(checkRange(outCome[1], 65, 65))
            {
                ReelTwo.sprite = Resources.Load<Sprite>("knife");
            }
            //setting the sprite of reelThree based off the roll range that was RNG'd
            if (checkRange(outCome[2], 1, 27))
            {
                ReelThree.sprite = Resources.Load<Sprite>("chicken");
            }
            else if (checkRange(outCome[2], 28, 37))
            {
                ReelThree.sprite = Resources.Load<Sprite>("usp");
            }
            else if (checkRange(outCome[2], 38, 46))
            {
                ReelThree.sprite = Resources.Load<Sprite>("Tec9");
            }
            else if (checkRange(outCome[2], 47, 54))
            {
                ReelThree.sprite = Resources.Load<Sprite>("deagle");
            }
            else if (checkRange(outCome[2], 55, 59))
            {
                ReelThree.sprite = Resources.Load<Sprite>("m4a4");
            }
            else if (checkRange(outCome[2], 60, 62))
            {
                ReelThree.sprite = Resources.Load<Sprite>("Ak47");
            }
            else if (checkRange(outCome[2], 63, 64))
            {
                ReelThree.sprite = Resources.Load<Sprite>("awp");
            }
            else if(checkRange(outCome[2], 65, 65))
            {
                ReelThree.sprite = Resources.Load<Sprite>("knife");
            }
        }
		return betLine;
	}
    //method to close the game 
    public void CloseGame()
    {
        Application.Quit();
    }

	/* This function calculates the player's winnings, if any */
	private void determineWinnings()
	{
		if (chickens == 0)
		{
			if (usps == 3)
			{
				winnings = playerBet * 10;
			}
			else if (tech9s == 3)
			{
				winnings = playerBet * 20;
			}
			else if (deagles == 3)
			{
				winnings = playerBet * 30;
			}
			else if (m4a4s == 3)
			{
				winnings = playerBet * 40;
			}
			else if (ak47s == 3)
			{
				winnings = playerBet * 50;
			}
			else if (awps == 3)
			{
				winnings = playerBet * 75;
			}
			else if (knives == 3)
			{
				winnings = playerBet * 100;
			}
			else if (usps == 2)
			{
				winnings = playerBet * 2;
			}
			else if (tech9s == 2)
			{
				winnings = playerBet * 2;
			}
			else if (deagles == 2)
			{
				winnings = playerBet * 3;
			}
			else if (m4a4s == 2)
			{
				winnings = playerBet * 4;
			}
			else if (ak47s == 2)
			{
				winnings = playerBet * 5;
			}
			else if (awps == 2)
			{
				winnings = playerBet * 10;
			}
			else if (knives == 2)
			{
				winnings = playerBet * 20;
			}
			else if (knives == 1)
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
            //settings winnins to 0 to reset the bet text box 
            winnings = 0;
        }

	}
    //buttons to add the selected bet amount depending on what button was clicked 
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
        //hiding he panel and message when we reset 
        Panel.gameObject.SetActive(false);
        MessageText.text = "";
    }

	public void OnSpinButtonClick()
	{

		if (playerMoney == 0)
		{
            //sending a panel and message telling the player they are out of money
            Panel.gameObject.SetActive(true);
            MessageText.text = "You have run out of credits! Please reset or quit the game.";

        }
		else if (playerBet > playerMoney)
		{
            //sending the player a message that their bet is too much 
			Debug.Log("You don't have enough Money to place that bet.");
            MessageText.text = "You don't have enough Money to place that bet.";
            Panel.gameObject.SetActive(true);
            //if the bet is too big reset the bet to 10
            playerBet = 10;
            //change button to disabled button if they cant spin
            SpinButton.sprite = Resources.Load<Sprite>("spin_pressed");

        }

		else if (playerBet < 0)
		{
			Debug.Log("All bets must be a positive $ amount.");
		}
		else if (playerBet <= playerMoney)
		{
			spinResult = Reels();
			weapons = spinResult[0] + " - " + spinResult[1] + " - " + spinResult[2];
			Debug.Log(weapons);
			determineWinnings();
			turn++;
			showPlayerStats();
            //setting the bet back to 10 hiding the panel and message and putting the button back to its original sprite
            playerBet = 10;
            MessageText.text = "";
            Panel.gameObject.SetActive(false);
            SpinButton.sprite = Resources.Load<Sprite>("spin");
        }
		else
		{
			Debug.Log("Please enter a valid bet amount");
		}
        //setting the various text fields to their corresponding values.
        BetText.text = playerBet.ToString();
        CreditText.text = playerMoney.ToString();
        WinningsText.text = winnings.ToString();

        if(winnings != 5000)
        {
            //if we dont win the jackpot hide the jackpot message.
            JackPotText.text = "";
            PanelJackPot.gameObject.SetActive(false);
        }
    }


    
}
