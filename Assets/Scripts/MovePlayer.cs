using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	[SerializeField] private int player;
	private KeyCode up;
	private KeyCode down;

	private Rigidbody2D myBody;
	// Start is called before the first frame update
	void Awake()
	{
		if (player == 1)
		{
			up = KeyCode.W;
			down = KeyCode.S;
		}
		else
		{
			up = KeyCode.UpArrow;
			down = KeyCode.DownArrow;
		}

		myBody = GetComponent<Rigidbody2D>();
	}

  // Update is called once per frame
  void Update()
  {
	  if (Input.GetKey(up))
	  {
		  myBody.velocity = new Vector2(0, 10.0f);
	  }
	  if (Input.GetKeyUp(up))
	  {
		  myBody.velocity = Vector2.zero;
	  }

		if (Input.GetKey(down))
	  {
			myBody.velocity = new Vector2(0, -10.0f);
	  }

		if (Input.GetKeyUp(down))
		{
			myBody.velocity = Vector2.zero;
		}

  }
}
