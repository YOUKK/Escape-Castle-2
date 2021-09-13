using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// 스피드 조정 변수
	[SerializeField]
	private float walkSpeed;
	[SerializeField]
	private float runSpeed;
	private float currentSpeed;

	// 상태 변수
	private bool isMove;
	private bool isWalk;
	private bool isRun;
	public bool isDead;

	// 움직임 체크 변수
	private Vector3 lastPos;

	[SerializeField]
	private MonsterMove[] monsters;

	// 필요한 컴포넌트
	private SpriteRenderer theSpriteRenderer;
	private Animator theAnimator;
	private BoxCollider2D theBoxCollider2D;
	public LayerMask theLayerMask;
	private Dash_UI theDashUI;

	// 오디오
	public string WalkSound;
	public string RunSound;

	private AudioManager theAudioManager;

	private float walkTimer;
	private float walkWaitingTime;

	private float runTimer;
	private float runWaitingTime;

	void Start()
	{
		theSpriteRenderer = GetComponent<SpriteRenderer>();
		theAnimator = GetComponent<Animator>();
		theBoxCollider2D = GetComponent<BoxCollider2D>();
		theAudioManager = FindObjectOfType<AudioManager>();
		theDashUI = FindObjectOfType<Dash_UI>();

		walkTimer = 0f;
		walkWaitingTime = 0.7f;

		runTimer = 0f;
		runWaitingTime = 0.35f;

		// 초기화
		currentSpeed = walkSpeed;
	}
	void Update()
	{
		if (isWalk && !isRun)
		{
			walkTimer += Time.deltaTime;
			if (walkTimer > walkWaitingTime)
			{
				WalkSoundPlayer();
				walkTimer = 0;
			}
		}

		if (isRun)
		{
			runTimer += Time.deltaTime;
			if(runTimer > runWaitingTime)
			{
				WalkSoundPlayer();
				runTimer = 0;
			}
		}

		if (!isDead)
		{
			Walk();
			//StartCoroutine("PlayWalkSound");
			TryRun();
			MoveCheck();
		}
		else
		{
			StartCoroutine("Dead");
		}
	}

	//IEnumerator PlayWalkSound()
	//{
	//	if (isWalk)
	//	{
	//		WalkSoundPlayer();

	//		yield return new WaitForSeconds(1f);

	//		isWalk = false;
	//	}
	//}

	private void WalkSoundPlayer()
	{
		theAudioManager.Play(WalkSound);
	}

	private void RunSoundPlayer()
	{
		theAudioManager.Play(RunSound);
	}

	// 달리기 시도
	private void TryRun()
	{
		if (Input.GetKey(KeyCode.LeftShift) && (theDashUI.GetCurrentDash() > 0))
		{
			Running();
		}
		if (Input.GetKeyUp(KeyCode.LeftShift) || (theDashUI.GetCurrentDash() <= 0))
		{
			RunningCancel();
		}
	}

	// 달리기
	private void Running()
	{
		isRun = true;
		currentSpeed = runSpeed;
		theAnimator.SetBool("isRun", true);
		theDashUI.DecreaseDash(2);
	}

	// 달리기 취소
	private void RunningCancel()
	{
		isRun = false;
		currentSpeed = walkSpeed;
		theAnimator.SetBool("isRun", false);
	}


	Vector2 moveRight = Vector2.zero;
	Vector2 moveUp = Vector2.zero;

	// 걷기
	private void Walk()
	{
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			moveRight = Vector2.right;
			//transform.Translate(transform.right * currentSpeed * Time.deltaTime);
			theSpriteRenderer.flipX = true;
		}
		if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
		{
			moveRight = Vector2.zero;
		}

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			moveRight = Vector2.left;
			//transform.Translate(transform.right * -1 * currentSpeed * Time.deltaTime);
			theSpriteRenderer.flipX = false;
		}
		if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
		{
			moveRight = Vector2.zero;
		}

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			moveUp = Vector2.up;
			//transform.Translate(transform.up * currentSpeed * Time.deltaTime);
		}
		if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
		{
			moveUp = Vector2.zero;
		}

		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			moveUp = Vector2.down;
			//transform.Translate(transform.up * -1 * currentSpeed * Time.deltaTime);
		}
		if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
		{
			moveUp = Vector2.zero;
		}

		Vector2 velocity = (moveRight + moveUp).normalized * currentSpeed;
		transform.Translate(velocity * Time.deltaTime);
	}

	// 움직임 체크
	private void MoveCheck()
	{
		if(Vector3.Distance(lastPos, transform.position) >= 0.01f)
		{
			// Wall이랑 닿는지 체크
			RaycastHit2D hit;

			Vector2 start = transform.position;
			Vector2 end = start + new Vector2(lastPos.x * currentSpeed, lastPos.y * currentSpeed);

			theBoxCollider2D.enabled = false;
			hit = Physics2D.Linecast(start, end, theLayerMask);
			theBoxCollider2D.enabled = true;

			if(hit.transform != null)
			{
				isWalk = false;
			}

			isWalk = true;
			theAnimator.SetBool("isWalk", true);
			//theAudioManager.Play(WalkSound);
		}
		else
		{
			isWalk = false;
			theAnimator.SetBool("isWalk", false);
		}
		lastPos = transform.position;

	}

	// 죽음 체크
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Monster"))
		{
			if (!monsters[0].isWearCape)
			{
				isDead = true;
			}
		}
	}

	[SerializeField]
	private GameObject Ending_Dead;

	// 죽음
	IEnumerator Dead()
	{
		theAnimator.SetTrigger("Dead");

		yield return new WaitForSeconds(0.8f);

		for (int i = 0; i < monsters.Length; i++)
		{
			monsters[i].isWearCape = true;
		}

		Ending_Dead.SetActive(true);

		//this.gameObject.SetActive(false);

		//theAnimator.SetBool("DeadtoIdle", true);
	}
}
