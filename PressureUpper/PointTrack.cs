using DrawFunctionLib;

namespace PressureUpper
{
    public class PointTrack
    {
        List<TimePosition> timePositionList;
        float _liveTime;
        public PointTrack(float liveTime)
        {
            _liveTime = liveTime;
            timePositionList = new List<TimePosition>();
        }
        public void AddTimePosition(DateTime time, DrawFunction3D.PointF3D position)
        {
            TimePosition tp = new TimePosition();
            tp.Time = time;
            tp.Position = position;
            timePositionList.Add(tp);
        }
        public void Reset()
        {
            timePositionList.Clear();
        }
        public void DisplayAndRefresh(DateTime time, DrawFunction3D drawTools)
        {
            if (timePositionList.Count > 0)
            {
                DrawFunction3D.PointF3D position = timePositionList[timePositionList.Count - 1].Position;

                Font Font1 = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

                DrawFunctionLib.DrawFunction3DPart.DrawString sting =
                    new DrawFunctionLib.DrawFunction3DPart.DrawString(drawTools, "压力中心", Font1, Brushes.Black,
                        new DrawFunction3D.PointF3D(position.X, position.Y, position.Z + 10));
                sting.DrawFont = Font1;
                drawTools.DrawPartListFunction.Add(sting);
                DrawFunctionLib.DrawFunction3DPart.FillEllipse ell = new DrawFunctionLib.DrawFunction3DPart.FillEllipse(drawTools, Brushes.Black, position, 10, 10);
                drawTools.DrawPartListFunction.Add(ell);

                DrawFunction3D.PointF3D lastPosition = position;

                for (int i = timePositionList.Count - 2; i >= 0; --i)
                {
                    TimePosition tp = timePositionList[i];
                    if (time.Subtract(tp.time).TotalSeconds > _liveTime)
                    {
                        timePositionList.Remove(tp);
                    }
                    else
                    {
                        ell = new DrawFunctionLib.DrawFunction3DPart.FillEllipse(drawTools, Brushes.Black, tp.position, 10, 10);
                        DrawFunctionLib.DrawFunction3DPart.DrawLine line = new DrawFunctionLib.DrawFunction3DPart.DrawLine(drawTools, new Pen(Color.Black, 10), tp.position, lastPosition);
                        drawTools.DrawPartListFunction.Add(ell);
                        drawTools.DrawPartListFunction.Add(line);
                        lastPosition = tp.position;
                    }
                }
            }
        }
    }
}
