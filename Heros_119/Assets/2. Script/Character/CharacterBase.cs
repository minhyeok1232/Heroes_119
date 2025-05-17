using System;
using UnityEngine;
using System.Collections;

public class CharacterBase : MonoBehaviour
{
    // 조건 1) Player은 이동하지 않는다. (BackGround은 왼쪽으로 이동)
    // 조건 2) 모든 Player의 animator을 담당하며, 각각의 Character의 anim을 직접 담당하는 것은 아니다.
    // --> Character의 Jump, Dead 등등.. 함수에 들어가면?? Player1, Player2, ... 같은 각각의 캐릭터 (6~9개정도 둘거)
    // --> 여기에 상속받는 override 캐릭터에 들어가서 그 상속받는 새로운 각 캐릭터의 각각의 클래스에서 애니메이션을 동작한다.
    // 조건 3) 또한 하이어라키에 Line을 3개를 등록했는데 3x3 형태로 캐릭터를 (모바일게임) 터치로 옮기는 식으로 해서 배치할거
    
    // ========================================== Animation ==========================================
    public Animator anim;
    
    // ========================================= Touch & Drag ========================================
    private float dist;	// Distance
    private bool isDragging = false;
    private Vector3 offset;
    
    // grid
	private Transform[] gridSlots;
	

    // 1) Character 통합 관리 --> 여기서 Player들을 찾아줌.
    protected virtual void Start()
    {
	    // 여기서, 상속받는 Player(Tag, ... )을 찾아서 
	    // List로 등록하는게 좋을까? 뭐로하는게 좋을까?
	    // Dictionary<Tag, ??> 을 찾아서 원하는 player을 찾을수 있게 해야하나?
	    
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
    
    
    
    // ================================== Animation virtual (자식으로 전달) ==================================
    protected void SetAnimBools(string animName, bool value)
    {
	    anim.SetBool(animName, value);
    }

    protected void SetAnimTriggers(string animName)
    {
	    anim.SetTrigger(animName);
    }
    


}