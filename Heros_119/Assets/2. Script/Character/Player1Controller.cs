using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player1Controller : CharacterBase, IDrag
{
	// Idle, Jump, Dead, Walk, Run, Attack

	// Use this for initialization
	protected override void Start()
	{
		base.Start();
		SetAnimBools("Walk", true);
	}
	 
	public void OnDragStart()
	{
		Debug.Log("[Player1] 드래그 시작");
	}

	public void OnDragging()
	{
		// 여기에 드래그 중일 때의 동작을 구현하세요
	}

	public void OnDragEnd()
	{
		Debug.Log("[Player1] 드래그 종료");
	}
}



