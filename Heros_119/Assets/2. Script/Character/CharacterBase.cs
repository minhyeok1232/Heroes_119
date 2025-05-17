using System;
using UnityEngine;
using System.Collections;

public class CharacterBase : MonoBehaviour
{
    // ���� 1) Player�� �̵����� �ʴ´�. (BackGround�� �������� �̵�)
    // ���� 2) ��� Player�� animator�� ����ϸ�, ������ Character�� anim�� ���� ����ϴ� ���� �ƴϴ�.
    // --> Character�� Jump, Dead ���.. �Լ��� ����?? Player1, Player2, ... ���� ������ ĳ���� (6~9������ �Ѱ�)
    // --> ���⿡ ��ӹ޴� override ĳ���Ϳ� ���� �� ��ӹ޴� ���ο� �� ĳ������ ������ Ŭ�������� �ִϸ��̼��� �����Ѵ�.
    // ���� 3) ���� ���̾��Ű�� Line�� 3���� ����ߴµ� 3x3 ���·� ĳ���͸� (����ϰ���) ��ġ�� �ű�� ������ �ؼ� ��ġ�Ұ�
    
    // ========================================== Animation ==========================================
    public Animator anim;
    
    // ========================================= Touch & Drag ========================================
    private float dist;	// Distance
    private bool isDragging = false;
    private Vector3 offset;
    
    // grid
	private Transform[] gridSlots;
	

    // 1) Character ���� ���� --> ���⼭ Player���� ã����.
    protected virtual void Start()
    {
	    // ���⼭, ��ӹ޴� Player(Tag, ... )�� ã�Ƽ� 
	    // List�� ����ϴ°� ������? �����ϴ°� ������?
	    // Dictionary<Tag, ??> �� ã�Ƽ� ���ϴ� player�� ã���� �ְ� �ؾ��ϳ�?
	    
	    GridScript grid = FindObjectOfType<GridScript>();
	    if (grid) gridSlots = grid.getGridSlots();
    }

    protected virtual void Update()
    {

    }
    
    private void SnapToNear3X3Grid()
    {
	    float minDist = float.MaxValue;
	    Transform closet = null;

	    foreach (Transform slot in gridSlots)
	    {
		    float dists = Vector2.Distance(slot.position, transform.position);
		    if (dists < minDist)
		    {
			    minDist = dists;
			    closet = slot;
		    }
	    }
	    
	    if (closet) transform.position = closet.position;
    }
    
    
    
    // ================================== Animation virtual (�ڽ����� ����) ==================================
    protected void SetAnimBools(string animName, bool value)
    {
	    anim.SetBool(animName, value);
    }

    protected void SetAnimTriggers(string animName)
    {
	    anim.SetTrigger(animName);
    }
    


}