using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class Player : Character
{
   [SerializeField] private FloatingJoystick floatingJoystick;
   [SerializeField] private Rigidbody rb;
   [SerializeField] private float moveSpeed;

   [SerializeField] private float maxSlopeAngle;

   private float _horizontal;
   private float _vertical;
   
   private RaycastHit _slopeHit;
   
   public override void OnInit()
   {
      base.OnInit();
      ChangeState(new PlayerIdleState());
   }

   #region Movement

   public bool GetInput()
   {
      _vertical = floatingJoystick.Vertical;
      _horizontal = floatingJoystick.Horizontal;
      if (Mathf.Abs(_vertical) < 0.01f &&
          Mathf.Abs(_horizontal) < 0.01f)
      {
         return false;
      }
      return true;
   }

   public void Move()
   {
      if (rb != null) ;
      rb.velocity = new Vector3(_horizontal, 0, _vertical).normalized * moveSpeed;
   }

   public void LookAtMoveDirection()
   {
      transform.eulerAngles = new Vector3(0f, 90f + Mathf.Atan2(-_vertical, _horizontal) * 180 / Mathf.PI, 0f);
   }
   
   public bool OnSlope()
   {
      if (Physics.Raycast(transform.position, Vector3.down, out _slopeHit, 0.8f))
      {
         Debug.DrawRay(transform.position,Vector3.down * 0.8f, Color.red, 3f);
         float angle = Vector3.Angle(Vector3.up, _slopeHit.normal);
         return angle < maxSlopeAngle && angle != 0;
      }

      return false;
   }
   
   public void SlopeMove()
   {
      Vector3 moveDirection = new Vector3(_horizontal, _vertical, 0).normalized;
      rb.velocity = Vector3.ProjectOnPlane(moveDirection, _slopeHit.normal).normalized * moveSpeed;
   }
   
   #endregion
   
}
