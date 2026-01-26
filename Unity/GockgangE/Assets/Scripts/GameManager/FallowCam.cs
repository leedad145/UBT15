using UnityEngine;

public class FallowCam : MonoBehaviour
{
   // 카메라가 따라다닐 대상
   Transform target;

   // 카메라가 대상을 따라가는 속도
   public float smooth = 0.1f;

   // 카메라 위치 조정
   Vector3 adjustCamPos = new Vector3(0, 10, 0);

   // 카메라 경계 설정
   Vector2 minCamLimit;
   Vector2 maxCamLimit;

    // Update is called once per frame
    void Start()
    {
      SetTarget();
    }
    public void SetTarget()
    {
      GameObject player = GameObject.Find("Player");
      if(player != null)
      {
         target = player.transform;
      }
    }
   void Update()
   {
      if (target == null) 
      {
         SetTarget();
         return;
      }

      // 카메라의 대상 위치간의 보간
      Vector3 pos = Vector3.Lerp(transform.position, target.position, smooth);

      // 대상과 한계 위치에 따른 카메라 위치
      transform.position = new Vector3(pos.x, pos.y, -10f);
        //  Mathf.Clamp(pos.x, minCamLimit.x, maxCamLimit.x) + adjustCamPos.x,
        //  Mathf.Clamp(pos.y, minCamLimit.y, maxCamLimit.y) + adjustCamPos.y,
        //  -10f + adjustCamPos.z);
   }
}