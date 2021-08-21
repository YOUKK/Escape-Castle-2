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

	// 움직임 체크 변수
	private Vector3 lastPos;

	// 필요한 컴포넌트
	private SpriteRenderer theSpriteRenderer;
	private Animator theAnimator;
	private BoxCollider2D theBoxCollider2D;
	public LayerMask theLayerMask;
	private Dash_UI theDashUI;

	void Start()
	{
		theSpriteRenderer = GetComponent<SpriteRenderer>();
		theAnimator = GetComponent<Animator>();
		theBoxCollider2D = GetComponent<BoxCollider2D>();
		theDashUI = FindObjectOfType<Dash_UI>();
		theCapsuleCollider2D = GetComponent<CapsuleCollider2D>();

		// 초기화
		currentSpeed = walkSpeed;
	}
	void Update()
	{
		Walk();
		TryRun();
		MoveCheck();
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

	// 걷기
	private void Walk()
	{
		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(transform.right * currentSpeed * Time.deltaTime);
			theSpriteRenderer.flipX = true;
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(transform.right * -1 * currentSpeed * Time.deltaTime);
			theSpriteRenderer.flipX = false;
		}
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(transform.up * currentSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(transform.up * -1 * currentSpeed * Time.deltaTime);
		}
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
		}
		else
		{
			isWalk = false;
			theAnimator.SetBool("isWalk", false);
		}
		lastPos = transform.position;

	}

	[SerializeField]
	private float range;
	[SerializeField]
	private LayerMask layerMask;

	private CapsuleCollider2D theCapsuleCollider2D;


	Item item;

	// 아이템 줍기 시도
	private void TryPickUp()
	{
			if (Input.GetKeyDown(KeyCode.F))
			{
				PickUp();
			}
	}

	// 아이템 줍기
	private void PickUp()
	{
		if (item.pickupActivated)
		{
			RaycastHit2D hitInfo; // 충돌체 정보 저장

			Vector2 start = transform.position;
			Vector2 end = start + new Vector2(lastPos.x * range, lastPos.y * range);

			theCapsuleCollider2D.enabled = false;
			theBoxCollider2D.enabled = false;
			hitInfo = Physics2D.Linecast(start, end, layerMask);
			theCapsuleCollider2D.enabled = true;
			theBoxCollider2D.enabled = true;

			if (hitInfo.transform != null)
			{
				Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + "획득했습니다");
				//itemstatus.AcquireItem(GetInfo());
				Destroy(this.gameObject);
			}
		}
	}
}
