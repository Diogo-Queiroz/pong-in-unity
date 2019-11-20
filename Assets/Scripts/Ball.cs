using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
	public Rigidbody2D Rb2D;
	private int scoreOne = 0;
	private int scoreTwo = 0;
	private bool GameEnded = false;
	public Text TscoreOne;
	public Text TscoreTwo;
	public Text Tresult;

	void Awake()
	{
		Rb2D.GetComponent<Rigidbody2D>();
	}

	// Start is called before the first frame update
	void Start()
	{
		ForceBall();
		TscoreOne.text = scoreOne.ToString();
		TscoreTwo.text = scoreTwo.ToString();
		Tresult.text = "";
	}
	
	void Update()
	{
		if (GameEnded)
		{
			if (Input.GetKey(KeyCode.Space))
			{
				RestartGame();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		UpdateScore(other.name);
		if (scoreOne == 11)
		{
			Tresult.text = "PLAYER ONE WINS";
			Rb2D.velocity = Vector2.zero;
			GameEnded = true;
		}

		if (scoreTwo == 11)
		{
			Tresult.text = "PLAYER TWO WINS";
			Rb2D.velocity = Vector2.zero;
			GameEnded = true;
		}
		Rb2D.MovePosition(new Vector2(0, 0));
		//ForceBall();
		
	}

	void ForceBall()
	{
		Rb2D.velocity = new Vector2(6, 2);
	}

	void UpdateScore(string ColliderName)
	{
		if (ColliderName == "GoalForTwo")
		{
			scoreOne++;
			TscoreOne.text = scoreOne.ToString();
		}
		else
		{
			scoreTwo++;
			TscoreTwo.text = scoreTwo.ToString();
		}
	}

	void RestartGame()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			scoreOne = 0;
			scoreTwo = 0;
			Start();
		}
	}
}
