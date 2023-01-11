// Copyright Karel Kroeze, 2018-2020

using System;
using UnityEngine;
using static ResearchPowl.Constants;

namespace ResearchPowl
{
    public class Edge<T1, T2> where T1 : Node where T2 : Node
    {
        public T1 _in;
        public T2 _out;
        ResearchNode _inResearch, _outResearch;

        public Edge( T1 @in, T2 @out )
        {
            _in     = @in;
            _out    = @out;
            IsDummy = _out is DummyNode;
        }
        public T1 In
        {
            get => _in;
            set
            {
                _in     = value;
                IsDummy = _out is DummyNode;
            }
        }
        public T2 Out
        {
            get => _out;
            set
            {
                _out    = value;
                IsDummy = _out is DummyNode;
            }
        }

        public int Span => _out.X - _in.X;
        public bool  IsDummy { get; private set; }

        public int DrawOrder()
        {
            if ( OutResearch().HighlightInEdge(InResearch()) ) return 3;
            if ( OutResearch().Research.IsFinished ) return 2;
            if ( OutResearch()._available ) return 1;
            return 0;
        }
        public ResearchNode InResearch()
        {
            if (_inResearch == null)
            {
                if (In is ResearchNode rn) _inResearch = rn;
                else if (In is DummyNode dn) _inResearch = dn.InResearch();
            }
            return _inResearch;
        }
        public ResearchNode OutResearch()
        {
            if (_outResearch == null)
            {
                if (Out is ResearchNode rn) _outResearch = rn;
                else if (Out is DummyNode dn) _outResearch = dn.OutResearch();
            }
            return _outResearch;
        }
        static bool RectVisible(Rect view, Rect test)
        {
            return ! ( view.xMin > test.xMax
                    || view.yMin > test.yMax
                    || view.yMax < test.yMin
                    || view.xMax < test.xMin);
        }
        public void Draw(Rect visibleRect)
        {
            GUI.color = Out.InEdgeColor(InResearch());
            DrawLines(visibleRect);
            GUI.color = Color.white;
        }
        public void DrawEnd(Rect visibleRect, Vector2 left, Vector2 right)
        {
            if (IsDummy)
            {
                // or draw a line piece through the dummy
                var through = new Rect(right.x, right.y - 2, NodeSize.x, 4f);
                if (RectVisible(visibleRect, through)) FastGUI.DrawTextureFast(through, Assets.LineEW, GUI.color);
                return;
            }
            // draw the end arrow (if not dummy)
            var end = new Rect(right.x - 16f, right.y - 8f, 16f, 16f);
            if (RectVisible(visibleRect, end)) FastGUI.DrawTextureFast(end, Assets.LineEnd, GUI.color);
        }
        public void DrawComplicatedSegments(Rect visibleRect, Vector2 left, Vector2 right)
        {
            // draw three line pieces and two curves.
            // determine top and bottom y positions
            var yMin = left.y < right.y ? left.y : right.y;
            var yMax = left.y > right.y ? left.y : right.y;
            var top = yMin + NodeMargins.x / 4f;
            var bottom = yMax - NodeMargins.x / 4f;

            // if too far off, just skip
            if (!RectVisible(visibleRect, new Rect(left.x, yMin, right.x - left.x, yMax - yMin))) return;

            // straight bits
            // left to curve
            var leftToCurve = new Rect(left.x, left.y - 2f, NodeMargins.x / 4f, 4f );
            if (RectVisible(visibleRect, leftToCurve)) FastGUI.DrawTextureFast(leftToCurve, Assets.LineEW, GUI.color);

            // curve to curve
            var curveToCurve = new Rect( left.x + NodeMargins.x / 2f - 2f, top, 4f, bottom - top );
            if (RectVisible(visibleRect, curveToCurve)) FastGUI.DrawTextureFast(curveToCurve, Assets.LineNS, GUI.color);

            // curve to right
            var curveToRight = new Rect( left.x + NodeMargins.x / 4f * 3 + 1f, right.y - 2f, right.x - left.x - NodeMargins.x / 4f * 3, 4f );
            if (RectVisible(visibleRect, curveToRight)) FastGUI.DrawTextureFast(curveToRight, Assets.LineEW, GUI.color);

            // curve positions
            var curveLeft = new Rect(left.x + NodeMargins.x / 4f, left.y - NodeMargins.x / 4f, NodeMargins.x / 2f, NodeMargins.x / 2f );
            var curveRight = new Rect(left.x + NodeMargins.x / 4f + 1f, right.y - NodeMargins.x / 4f, NodeMargins.x / 2f, NodeMargins.x / 2f );

            // going down
            if ( left.y < right.y )
            {
                if (RectVisible(visibleRect, curveLeft)) FastGUI.DrawTextureFastWithCoords(curveLeft, Assets.LineCircle, GUI.color, new Rect(0.5f, 0.5f, 0.5f, 0.5f));
                if (RectVisible(visibleRect, curveRight)) FastGUI.DrawTextureFastWithCoords(curveRight, Assets.LineCircle, GUI.color, new Rect(0f, 0f, 0.5f, 0.5f));
                // bottom right quadrant
                // top left quadrant
            }
            else
            {
                // going up
                if (RectVisible(visibleRect, curveLeft)) FastGUI.DrawTextureFastWithCoords(curveLeft, Assets.LineCircle, GUI.color, new Rect(0.5f, 0f, 0.5f, 0.5f));
                // top right quadrant
                if (RectVisible(visibleRect, curveRight)) FastGUI.DrawTextureFastWithCoords(curveRight, Assets.LineCircle, GUI.color, new Rect(0f, 0.5f, 0.5f, 0.5f));
                // bottom left quadrant
            }
        }
        public void DrawLines( Rect visibleRect )
        {
            var left  = In.Right;
            var right = Out.Left;

            // if left and right are on the same level, just draw a straight line.
            if (Math.Abs( left.y - right.y ) < Epsilon)
            {
                var line = new Rect( left.x, left.y - 2f, right.x - left.x, 4f );
                if (RectVisible(visibleRect, line)) FastGUI.DrawTextureFast(line, Assets.LineEW, GUI.color);
            }
            else DrawComplicatedSegments(visibleRect, left, right);
            DrawEnd(visibleRect, left, right);
        }
        public override string ToString()
        {
            return _in + " -> " + _out;
        }
    }
}