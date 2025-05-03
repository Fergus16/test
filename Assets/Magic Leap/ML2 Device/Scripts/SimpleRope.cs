// Copyright (c) 2019-present, Magic Leap, Inc. All Rights Reserved.
// Use of this file is governed by the Developer Agreement, located
// here: https://auth.magicleap.com/terms/developer
using System.Collections.Generic;
using UnityEngine;

namespace MagicLeap.DesignToolkit.Samples
{
    /// <summary>
    /// Simple Rope Physics for Line Renderer
    /// </summary>
    public class SimpleRope : MonoBehaviour
    {
        private LineRenderer LineRenderer;
        private List<RopeSegment> _ropeSegments = new List<RopeSegment>();
        public float RopeSegLen = 0.25f;
        public Vector3 Gravity = new Vector3(0f, -1.5f, 0f);
        public float Drag = 2f;
        public Transform RopeStartPoint;
        public Transform RopeEndPoint;

        // Use this for initialization
        void Start()
        {
            LineRenderer = GetComponent<LineRenderer>();

            for (int i = 0; i < LineRenderer.positionCount; i++)
            {
                _ropeSegments.Add(new RopeSegment(LineRenderer.GetPosition(i)));
            }
        }

        // Update is called once per frame
        void Update()
        {
            DrawRope();
        }

        private void FixedUpdate()
        {
            Simulate();
        }

        private void Simulate()
        {
            // SIMULATION
            for (int i = 1; i < LineRenderer.positionCount; i++)
            {
                RopeSegment firstSegment = _ropeSegments[i];
                Vector3 velocity = firstSegment.posNow - firstSegment.posOld;
                firstSegment.posOld = firstSegment.posNow;
                firstSegment.posNow += velocity / Drag;
                firstSegment.posNow += Gravity * Time.fixedDeltaTime;
                _ropeSegments[i] = firstSegment;
            }

            //CONSTRAINTS
            for (int i = 0; i < 50; i++)
            {
                ApplyConstraint();
            }
        }

        private void ApplyConstraint()
        {
            //Constrant to Mouse
            RopeSegment firstSegment = _ropeSegments[0];
            firstSegment.posNow = RopeStartPoint.localPosition;
            _ropeSegments[0] = firstSegment;
            
            RopeSegment lastSegment = _ropeSegments[_ropeSegments.Count-1];
            lastSegment.posNow = RopeEndPoint.localPosition;
            _ropeSegments[_ropeSegments.Count-1] = lastSegment;

            for (int i = 0; i < LineRenderer.positionCount - 1; i++)
            {
                RopeSegment firstSeg = _ropeSegments[i];
                RopeSegment secondSeg = _ropeSegments[i + 1];

                float dist = (firstSeg.posNow - secondSeg.posNow).magnitude;
                float error = Mathf.Abs(dist - RopeSegLen);
                Vector3 changeDir = Vector3.zero;

                if (dist > RopeSegLen)
                {
                    changeDir = (firstSeg.posNow - secondSeg.posNow).normalized;
                } else if (dist < RopeSegLen)
                {
                    changeDir = (secondSeg.posNow - firstSeg.posNow).normalized;
                }

                Vector3 changeAmount = changeDir * error;
                if (i != 0)
                {
                    firstSeg.posNow -= changeAmount * 0.5f;
                    _ropeSegments[i] = firstSeg;
                    secondSeg.posNow += changeAmount * 0.5f;
                    _ropeSegments[i + 1] = secondSeg;
                }
                else
                {
                    secondSeg.posNow += changeAmount;
                    _ropeSegments[i + 1] = secondSeg;
                }
            }
        }

        private void DrawRope()
        {
            Vector3[] ropePositions = new Vector3[LineRenderer.positionCount];
            for (int i = 0; i < LineRenderer.positionCount; i++)
            {
                ropePositions[i] = _ropeSegments[i].posNow;
            }
            LineRenderer.SetPositions(ropePositions);
        }

        public struct RopeSegment
        {
            public Vector3 posNow;
            public Vector3 posOld;

            public RopeSegment(Vector3 pos)
            {
                posNow = pos;
                posOld = pos;
            }
        }
    }   
}