using DrawFunctionLib.DrawFunction3DPart;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrawFunctionLib.DrawFunction3DModel
{
    public class DrawCoordinate : DrawBase
    {
        protected CoordinateSettings uDrawCoordinateSettings;

        public virtual CoordinateSettings DrawCoordinateSettings
        {
            get
            {
                return this.uDrawCoordinateSettings;
            }
            set
            {
                if (value == null)
                    return;
                this.uDrawCoordinateSettings = value;
            }
        }

        public override DrawBase.ModelType ModelStyle
        {
            get
            {
                return DrawBase.ModelType.Changed;
            }
        }

        public DrawCoordinate(DrawFunction3D IndexDrawFunction)
        {
            this.uDrawCoordinateSettings = new DrawCoordinate.CoordinateSettings();
            this.IndexDrawFunction = IndexDrawFunction;
        }

        public override bool CalcualteModel()
        {
            bool flag = false;
            this.PartList.Clear();
            if (this.IndexDrawFunction != null)
            {
                flag = true;
                DrawCoordinate.CoordinateSettings coordinateSettings = this.DrawCoordinateSettings;
                this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenCoordinate, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Min), new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Max, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Min)));
                this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenCoordinate, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Min), new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Max, (float)this.IndexDrawFunction.DrawRangeZ.Min)));
                this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenCoordinate, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Min), new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Max)));
                this.PartList.Add(new DrawString(this.IndexDrawFunction, coordinateSettings.CoordinateNameX, coordinateSettings.DrawFont, coordinateSettings.BrushString, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Max, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Min)));
                this.PartList.Add(new DrawString(this.IndexDrawFunction, coordinateSettings.CoordinateNameY, coordinateSettings.DrawFont, coordinateSettings.BrushString, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Max, (float)this.IndexDrawFunction.DrawRangeZ.Min)));
                this.PartList.Add(new DrawString(this.IndexDrawFunction, coordinateSettings.CoordinateNameZ, coordinateSettings.DrawFont, coordinateSettings.BrushString, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Max)));
                if (coordinateSettings.EnableDrawCoordinateAreaXY)
                    this.PartList.Add(new FillPolygon(this.IndexDrawFunction, coordinateSettings.BrushCoordinateAreaXY, new DrawFunction3D.PointF3D[4]
                    {
            new DrawFunction3D.PointF3D((float) this.IndexDrawFunction.DrawRangeX.Min, (float) this.IndexDrawFunction.DrawRangeY.Min, (float) this.IndexDrawFunction.DrawRangeZ.Min),
            new DrawFunction3D.PointF3D((float) this.IndexDrawFunction.DrawRangeX.Min, (float) this.IndexDrawFunction.DrawRangeY.Max, (float) this.IndexDrawFunction.DrawRangeZ.Min),
            new DrawFunction3D.PointF3D((float) this.IndexDrawFunction.DrawRangeX.Max, (float) this.IndexDrawFunction.DrawRangeY.Max, (float) this.IndexDrawFunction.DrawRangeZ.Min),
            new DrawFunction3D.PointF3D((float) this.IndexDrawFunction.DrawRangeX.Max, (float) this.IndexDrawFunction.DrawRangeY.Min, (float) this.IndexDrawFunction.DrawRangeZ.Min)
                    }));
                if (coordinateSettings.EnableDrawCoordinateAreaYZ)
                    this.PartList.Add(new FillPolygon(this.IndexDrawFunction, coordinateSettings.BrushCoordinateAreaYZ, new DrawFunction3D.PointF3D[4]
                    {
            new DrawFunction3D.PointF3D((float) this.IndexDrawFunction.DrawRangeX.Min, (float) this.IndexDrawFunction.DrawRangeY.Min, (float) this.IndexDrawFunction.DrawRangeZ.Min),
            new DrawFunction3D.PointF3D((float) this.IndexDrawFunction.DrawRangeX.Min, (float) this.IndexDrawFunction.DrawRangeY.Min, (float) this.IndexDrawFunction.DrawRangeZ.Max),
            new DrawFunction3D.PointF3D((float) this.IndexDrawFunction.DrawRangeX.Min, (float) this.IndexDrawFunction.DrawRangeY.Max, (float) this.IndexDrawFunction.DrawRangeZ.Max),
            new DrawFunction3D.PointF3D((float) this.IndexDrawFunction.DrawRangeX.Min, (float) this.IndexDrawFunction.DrawRangeY.Max, (float) this.IndexDrawFunction.DrawRangeZ.Min)
                    }));
                if (coordinateSettings.EnableDrawCoordinateAreaXZ)
                    this.PartList.Add(new FillPolygon(this.IndexDrawFunction, coordinateSettings.BrushCoordinateAreaXZ, new DrawFunction3D.PointF3D[4]
                    {
            new DrawFunction3D.PointF3D((float) this.IndexDrawFunction.DrawRangeX.Min, (float) this.IndexDrawFunction.DrawRangeY.Min, (float) this.IndexDrawFunction.DrawRangeZ.Min),
            new DrawFunction3D.PointF3D((float) this.IndexDrawFunction.DrawRangeX.Min, (float) this.IndexDrawFunction.DrawRangeY.Min, (float) this.IndexDrawFunction.DrawRangeZ.Max),
            new DrawFunction3D.PointF3D((float) this.IndexDrawFunction.DrawRangeX.Max, (float) this.IndexDrawFunction.DrawRangeY.Min, (float) this.IndexDrawFunction.DrawRangeZ.Max),
            new DrawFunction3D.PointF3D((float) this.IndexDrawFunction.DrawRangeX.Max, (float) this.IndexDrawFunction.DrawRangeY.Min, (float) this.IndexDrawFunction.DrawRangeZ.Min)
                    }));
                if (coordinateSettings.EnableDrawTopCoordinateXY)
                {
                    this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenSubCoordinate, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Max, (float)this.IndexDrawFunction.DrawRangeZ.Min), new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Max, (float)this.IndexDrawFunction.DrawRangeY.Max, (float)this.IndexDrawFunction.DrawRangeZ.Min)));
                    this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenSubCoordinate, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Max, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Min), new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Max, (float)this.IndexDrawFunction.DrawRangeY.Max, (float)this.IndexDrawFunction.DrawRangeZ.Min)));
                }
                if (coordinateSettings.EnableDrawTopCoordinateYZ)
                {
                    this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenSubCoordinate, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Max), new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Max, (float)this.IndexDrawFunction.DrawRangeZ.Max)));
                    this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenSubCoordinate, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Max, (float)this.IndexDrawFunction.DrawRangeZ.Min), new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Max, (float)this.IndexDrawFunction.DrawRangeZ.Max)));
                }
                if (coordinateSettings.EnableDrawTopCoordinateXZ)
                {
                    this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenSubCoordinate, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Max), new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Max, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Max)));
                    this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenSubCoordinate, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Max, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Min), new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Max, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Max)));
                }
                if (coordinateSettings.EnableDrawTopCoordinateXYZ)
                {
                    this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenSubCoordinate, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Max, (float)this.IndexDrawFunction.DrawRangeY.Max, (float)this.IndexDrawFunction.DrawRangeZ.Min), new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Max, (float)this.IndexDrawFunction.DrawRangeY.Max, (float)this.IndexDrawFunction.DrawRangeZ.Max)));
                    this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenSubCoordinate, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Max, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Max), new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Max, (float)this.IndexDrawFunction.DrawRangeY.Max, (float)this.IndexDrawFunction.DrawRangeZ.Max)));
                    this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenSubCoordinate, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Max, (float)this.IndexDrawFunction.DrawRangeZ.Max), new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Max, (float)this.IndexDrawFunction.DrawRangeY.Max, (float)this.IndexDrawFunction.DrawRangeZ.Max)));
                }
                double num1 = this.IndexDrawFunction.DrawRangeX.Length / (double)coordinateSettings.CoordinateNumberX;
                double num2 = this.IndexDrawFunction.DrawRangeY.Length / (double)coordinateSettings.CoordinateNumberY;
                double num3 = this.IndexDrawFunction.DrawRangeZ.Length / (double)coordinateSettings.CoordinateNumberZ;
                if (coordinateSettings.EnableDrawCoordinateValue)
                {
                    List<DrawFunction3DPart.DrawBase> partList1 = this.PartList;
                    DrawFunction3D indexDrawFunction1 = this.IndexDrawFunction;
                    double min = this.IndexDrawFunction.DrawRangeX.Min;
                    string DrawString1 = min.ToString(coordinateSettings.DrawFormat);
                    Font drawFont1 = coordinateSettings.DrawFont;
                    Brush brushString1 = coordinateSettings.BrushString;
                    DrawFunction3D.PointF3D DrawPoint1 = new DrawFunction3D.PointF3D((float)(this.IndexDrawFunction.DrawRangeX.Min + num1 * 0.2), (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Min);
                    DrawString drawString1 = new DrawString(indexDrawFunction1, DrawString1, drawFont1, brushString1, DrawPoint1);
                    partList1.Add((DrawFunction3DPart.DrawBase)drawString1);
                    List<DrawFunction3DPart.DrawBase> partList2 = this.PartList;
                    DrawFunction3D indexDrawFunction2 = this.IndexDrawFunction;
                    min = this.IndexDrawFunction.DrawRangeY.Min;
                    string DrawString2 = min.ToString(coordinateSettings.DrawFormat);
                    Font drawFont2 = coordinateSettings.DrawFont;
                    Brush brushString2 = coordinateSettings.BrushString;
                    DrawFunction3D.PointF3D DrawPoint2 = new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)(this.IndexDrawFunction.DrawRangeY.Min + num2 * 0.2), (float)this.IndexDrawFunction.DrawRangeZ.Min);
                    DrawString drawString2 = new DrawString(indexDrawFunction2, DrawString2, drawFont2, brushString2, DrawPoint2);
                    partList2.Add((DrawFunction3DPart.DrawBase)drawString2);
                    List<DrawFunction3DPart.DrawBase> partList3 = this.PartList;
                    DrawFunction3D indexDrawFunction3 = this.IndexDrawFunction;
                    min = this.IndexDrawFunction.DrawRangeZ.Min;
                    string DrawString3 = min.ToString(coordinateSettings.DrawFormat);
                    Font drawFont3 = coordinateSettings.DrawFont;
                    Brush brushString3 = coordinateSettings.BrushString;
                    DrawFunction3D.PointF3D DrawPoint3 = new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)(this.IndexDrawFunction.DrawRangeZ.Min + num3 * 0.2));
                    DrawString drawString3 = new DrawString(indexDrawFunction3, DrawString3, drawFont3, brushString3, DrawPoint3);
                    partList3.Add((DrawFunction3DPart.DrawBase)drawString3);
                }
                if (coordinateSettings.EnableDrawSubCoordinateXY | coordinateSettings.EnableDrawCoordinateValue)
                {
                    if (num1 > 0.0)
                    {
                        double num4 = this.IndexDrawFunction.DrawRangeX.Min + num1;
                        double num5 = this.IndexDrawFunction.DrawRangeX.Max - num1 / 2.0;
                        double StepValue = num1;
                        double limit = num5;
                        double count = num4;
                        while (ObjectFlowControl.ForLoopControl.ForNextCheckR8(count, limit, StepValue))
                        {
                            if (coordinateSettings.EnableDrawSubCoordinateXY)
                                this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenSubCoordinate, new DrawFunction3D.PointF3D((float)count, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Min), new DrawFunction3D.PointF3D((float)count, (float)this.IndexDrawFunction.DrawRangeY.Max, (float)this.IndexDrawFunction.DrawRangeZ.Min)));
                            if (coordinateSettings.EnableDrawCoordinateValue)
                            {
                                if (!coordinateSettings.EnableDrawSubCoordinateXY)
                                    this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenSubCoordinate, new DrawFunction3D.PointF3D((float)count, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Min), new DrawFunction3D.PointF3D((float)count, (float)(this.IndexDrawFunction.DrawRangeY.Min + this.IndexDrawFunction.DrawRangeY.Length * (double)coordinateSettings.DrawSmallCoordinatePercent), (float)this.IndexDrawFunction.DrawRangeZ.Min)));
                                this.PartList.Add(new DrawString(this.IndexDrawFunction, count.ToString(coordinateSettings.DrawFormat), coordinateSettings.DrawFont, coordinateSettings.BrushString, new DrawFunction3D.PointF3D((float)count, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Min)));
                            }
                            count += StepValue;
                        }
                    }
                    if (num2 > 0.0)
                    {
                        double num4 = this.IndexDrawFunction.DrawRangeY.Min + num2;
                        double num5 = this.IndexDrawFunction.DrawRangeY.Max - num2 / 2.0;
                        double StepValue = num2;
                        double limit = num5;
                        double count = num4;
                        while (ObjectFlowControl.ForLoopControl.ForNextCheckR8(count, limit, StepValue))
                        {
                            if (coordinateSettings.EnableDrawSubCoordinateXY)
                                this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenSubCoordinate, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)count, (float)this.IndexDrawFunction.DrawRangeZ.Min), new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Max, (float)count, (float)this.IndexDrawFunction.DrawRangeZ.Min)));
                            if (coordinateSettings.EnableDrawCoordinateValue)
                            {
                                if (!coordinateSettings.EnableDrawSubCoordinateXY)
                                    this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenSubCoordinate, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)count, (float)this.IndexDrawFunction.DrawRangeZ.Min), new DrawFunction3D.PointF3D((float)(this.IndexDrawFunction.DrawRangeX.Min + this.IndexDrawFunction.DrawRangeX.Length * (double)coordinateSettings.DrawSmallCoordinatePercent), (float)count, (float)this.IndexDrawFunction.DrawRangeZ.Min)));
                                this.PartList.Add(new DrawString(this.IndexDrawFunction, count.ToString(coordinateSettings.DrawFormat), coordinateSettings.DrawFont, coordinateSettings.BrushString, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)count, (float)this.IndexDrawFunction.DrawRangeZ.Min)));
                            }
                            count += StepValue;
                        }
                    }
                }
                if (coordinateSettings.EnableDrawSubCoordinateXZ | coordinateSettings.EnableDrawCoordinateValue)
                {
                    if (num1 > 0.0)
                    {
                        double num4 = this.IndexDrawFunction.DrawRangeX.Min + num1;
                        double num5 = this.IndexDrawFunction.DrawRangeX.Max - num1 / 2.0;
                        double StepValue = num1;
                        double limit = num5;
                        double count = num4;
                        while (ObjectFlowControl.ForLoopControl.ForNextCheckR8(count, limit, StepValue))
                        {
                            if (coordinateSettings.EnableDrawSubCoordinateXZ)
                                this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenSubCoordinate, new DrawFunction3D.PointF3D((float)count, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Min), new DrawFunction3D.PointF3D((float)count, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Max)));
                            if (coordinateSettings.EnableDrawCoordinateValue)
                            {
                                if (!coordinateSettings.EnableDrawSubCoordinateXZ)
                                    this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenSubCoordinate, new DrawFunction3D.PointF3D((float)count, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Min), new DrawFunction3D.PointF3D((float)count, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)(this.IndexDrawFunction.DrawRangeZ.Min + this.IndexDrawFunction.DrawRangeZ.Length * (double)coordinateSettings.DrawSmallCoordinatePercent))));
                                if (!coordinateSettings.EnableDrawSubCoordinateXY)
                                    this.PartList.Add(new DrawString(this.IndexDrawFunction, count.ToString(coordinateSettings.DrawFormat), coordinateSettings.DrawFont, coordinateSettings.BrushString, new DrawFunction3D.PointF3D((float)count, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)this.IndexDrawFunction.DrawRangeZ.Min)));
                            }
                            count += StepValue;
                        }
                    }
                    if (num3 > 0.0)
                    {
                        double num4 = this.IndexDrawFunction.DrawRangeZ.Min + num3;
                        double num5 = this.IndexDrawFunction.DrawRangeZ.Max - num3 / 2.0;
                        double StepValue = num3;
                        double limit = num5;
                        double count = num4;
                        while (ObjectFlowControl.ForLoopControl.ForNextCheckR8(count, limit, StepValue))
                        {
                            if (coordinateSettings.EnableDrawSubCoordinateXZ)
                                this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenSubCoordinate, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)count), new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Max, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)count)));
                            if (coordinateSettings.EnableDrawCoordinateValue)
                            {
                                if (!coordinateSettings.EnableDrawSubCoordinateXZ)
                                    this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenSubCoordinate, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)count), new DrawFunction3D.PointF3D((float)(this.IndexDrawFunction.DrawRangeX.Min + this.IndexDrawFunction.DrawRangeX.Length * (double)coordinateSettings.DrawSmallCoordinatePercent), (float)this.IndexDrawFunction.DrawRangeY.Min, (float)count)));
                                this.PartList.Add(new DrawString(this.IndexDrawFunction, count.ToString(coordinateSettings.DrawFormat), coordinateSettings.DrawFont, coordinateSettings.BrushString, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)count)));
                            }
                            count += StepValue;
                        }
                    }
                }
                if (coordinateSettings.EnableDrawSubCoordinateYZ | coordinateSettings.EnableDrawCoordinateValue)
                {
                    if (num2 > 0.0)
                    {
                        double num4 = this.IndexDrawFunction.DrawRangeY.Min + num2;
                        double num5 = this.IndexDrawFunction.DrawRangeY.Max - num2 / 2.0;
                        double StepValue = num2;
                        double limit = num5;
                        double count = num4;
                        while (ObjectFlowControl.ForLoopControl.ForNextCheckR8(count, limit, StepValue))
                        {
                            if (coordinateSettings.EnableDrawSubCoordinateYZ)
                                this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenSubCoordinate, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)count, (float)this.IndexDrawFunction.DrawRangeZ.Min), new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)count, (float)this.IndexDrawFunction.DrawRangeZ.Max)));
                            if (coordinateSettings.EnableDrawCoordinateValue)
                            {
                                if (!coordinateSettings.EnableDrawSubCoordinateYZ)
                                    this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenSubCoordinate, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)count, (float)this.IndexDrawFunction.DrawRangeZ.Min), new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)count, (float)(this.IndexDrawFunction.DrawRangeZ.Min + this.IndexDrawFunction.DrawRangeZ.Length * (double)coordinateSettings.DrawSmallCoordinatePercent))));
                                if (!coordinateSettings.EnableDrawSubCoordinateXY)
                                    this.PartList.Add(new DrawString(this.IndexDrawFunction, count.ToString(coordinateSettings.DrawFormat), coordinateSettings.DrawFont, coordinateSettings.BrushString, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)count, (float)this.IndexDrawFunction.DrawRangeZ.Min)));
                            }
                            count += StepValue;
                        }
                    }
                    if (num3 > 0.0)
                    {
                        double num4 = this.IndexDrawFunction.DrawRangeZ.Min + num3;
                        double num5 = this.IndexDrawFunction.DrawRangeZ.Max - num3 / 2.0;
                        double StepValue = num3;
                        double limit = num5;
                        double count = num4;
                        while (ObjectFlowControl.ForLoopControl.ForNextCheckR8(count, limit, StepValue))
                        {
                            if (coordinateSettings.EnableDrawSubCoordinateYZ)
                                this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenSubCoordinate, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)count), new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Max, (float)count)));
                            if (coordinateSettings.EnableDrawCoordinateValue)
                            {
                                if (!coordinateSettings.EnableDrawSubCoordinateYZ)
                                    this.PartList.Add(new DrawLine(this.IndexDrawFunction, coordinateSettings.PenSubCoordinate, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)count), new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)(this.IndexDrawFunction.DrawRangeY.Min + this.IndexDrawFunction.DrawRangeY.Length * (double)coordinateSettings.DrawSmallCoordinatePercent), (float)count)));
                                if (!coordinateSettings.EnableDrawSubCoordinateXZ)
                                    this.PartList.Add(new DrawString(this.IndexDrawFunction, count.ToString(coordinateSettings.DrawFormat), coordinateSettings.DrawFont, coordinateSettings.BrushString, new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, (float)this.IndexDrawFunction.DrawRangeY.Min, (float)count)));
                            }
                            count += StepValue;
                        }
                    }
                }
            }
            return flag;
        }

        public class CoordinateSettings
        {
            protected Font uDrawFont;
            protected string uDrawFormat;
            protected Brush uBrushString;
            protected Pen uDrawPenCoordinate;
            protected Pen uDrawPenSubCoordinate;
            protected bool b_EnableDrawSubCoordinateXY;
            protected bool b_EnableDrawSubCoordinateYZ;
            protected bool b_EnableDrawSubCoordinateXZ;
            protected bool b_EnableDrawCoordinateAreaXY;
            protected bool b_EnableDrawCoordinateAreaYZ;
            protected bool b_EnableDrawCoordinateAreaXZ;
            protected bool b_EnableDrawTopCoordinateXY;
            protected bool b_EnableDrawTopCoordinateYZ;
            protected bool b_EnableDrawTopCoordinateXZ;
            protected bool b_EnableDrawTopCoordinateXYZ;
            protected bool b_EnableDrawCoordinateValue;
            protected float f_DrawSmallCoordinatePercent;
            protected int i_DrawCoordinateNumberX;
            protected int i_DrawCoordinateNumberY;
            protected int i_DrawCoordinateNumberZ;
            protected string str_DrawCoordinateNameX;
            protected string str_DrawCoordinateNameY;
            protected string str_DrawCoordinateNameZ;
            protected Brush brush_BrushCoordinateAreaXY;
            protected Brush brush_BrushCoordinateAreaYZ;
            protected Brush brush_BrushCoordinateAreaXZ;

            public virtual Font DrawFont
            {
                get
                {
                    return this.uDrawFont;
                }
                set
                {
                    if (value == null)
                        return;
                    this.uDrawFont = value;
                }
            }

            public virtual Brush BrushString
            {
                get
                {
                    return this.uBrushString;
                }
                set
                {
                    this.uBrushString = value;
                }
            }

            public virtual string DrawFormat
            {
                get
                {
                    return this.uDrawFormat;
                }
                set
                {
                    if (value == null)
                        return;
                    this.uDrawFormat = value;
                }
            }

            public virtual Pen PenCoordinate
            {
                get
                {
                    return this.uDrawPenCoordinate;
                }
                set
                {
                    if (value == null)
                        return;
                    this.uDrawPenCoordinate = value;
                }
            }

            public virtual float DrawSmallCoordinatePercent
            {
                get
                {
                    return this.f_DrawSmallCoordinatePercent;
                }
                set
                {
                    if ((double)value < 0.0)
                        value = 0.0f;
                    else if ((double)value > 1.0)
                        value = 1f;
                    this.f_DrawSmallCoordinatePercent = value;
                }
            }

            public virtual Pen PenSubCoordinate
            {
                get
                {
                    return this.uDrawPenSubCoordinate;
                }
                set
                {
                    if (value == null)
                        return;
                    this.uDrawPenSubCoordinate = value;
                }
            }

            public virtual bool EnableDrawSubCoordinateXY
            {
                get
                {
                    return this.b_EnableDrawSubCoordinateXY;
                }
                set
                {
                    this.b_EnableDrawSubCoordinateXY = value;
                }
            }

            public virtual bool EnableDrawSubCoordinateXZ
            {
                get
                {
                    return this.b_EnableDrawSubCoordinateXZ;
                }
                set
                {
                    this.b_EnableDrawSubCoordinateXZ = value;
                }
            }

            public virtual bool EnableDrawSubCoordinateYZ
            {
                get
                {
                    return this.b_EnableDrawSubCoordinateYZ;
                }
                set
                {
                    this.b_EnableDrawSubCoordinateYZ = value;
                }
            }

            public virtual bool EnableDrawCoordinateAreaXY
            {
                get
                {
                    return this.b_EnableDrawCoordinateAreaXY;
                }
                set
                {
                    this.b_EnableDrawCoordinateAreaXY = value;
                }
            }

            public virtual bool EnableDrawCoordinateAreaXZ
            {
                get
                {
                    return this.b_EnableDrawCoordinateAreaXZ;
                }
                set
                {
                    this.b_EnableDrawCoordinateAreaXZ = value;
                }
            }

            public virtual bool EnableDrawCoordinateAreaYZ
            {
                get
                {
                    return this.b_EnableDrawCoordinateAreaYZ;
                }
                set
                {
                    this.b_EnableDrawCoordinateAreaYZ = value;
                }
            }

            public virtual bool EnableDrawCoordinateValue
            {
                get
                {
                    return this.b_EnableDrawCoordinateValue;
                }
                set
                {
                    this.b_EnableDrawCoordinateValue = value;
                }
            }

            public virtual bool EnableDrawTopCoordinateXY
            {
                get
                {
                    return this.b_EnableDrawTopCoordinateXY;
                }
                set
                {
                    this.b_EnableDrawTopCoordinateXY = value;
                }
            }

            public virtual bool EnableDrawTopCoordinateXZ
            {
                get
                {
                    return this.b_EnableDrawTopCoordinateXZ;
                }
                set
                {
                    this.b_EnableDrawTopCoordinateXZ = value;
                }
            }

            public virtual bool EnableDrawTopCoordinateYZ
            {
                get
                {
                    return this.b_EnableDrawTopCoordinateYZ;
                }
                set
                {
                    this.b_EnableDrawTopCoordinateYZ = value;
                }
            }

            public virtual bool EnableDrawTopCoordinateXYZ
            {
                get
                {
                    return this.b_EnableDrawTopCoordinateXYZ;
                }
                set
                {
                    this.b_EnableDrawTopCoordinateXYZ = value;
                }
            }

            public virtual int CoordinateNumberX
            {
                get
                {
                    return this.i_DrawCoordinateNumberX;
                }
                set
                {
                    if (value < 1)
                        value = 1;
                    this.i_DrawCoordinateNumberX = value;
                }
            }

            public virtual int CoordinateNumberY
            {
                get
                {
                    return this.i_DrawCoordinateNumberY;
                }
                set
                {
                    if (value < 1)
                        value = 1;
                    this.i_DrawCoordinateNumberY = value;
                }
            }

            public virtual int CoordinateNumberZ
            {
                get
                {
                    return this.i_DrawCoordinateNumberZ;
                }
                set
                {
                    if (value < 1)
                        value = 1;
                    this.i_DrawCoordinateNumberZ = value;
                }
            }

            public virtual string CoordinateNameX
            {
                get
                {
                    return this.str_DrawCoordinateNameX;
                }
                set
                {
                    if (value == null)
                        return;
                    this.str_DrawCoordinateNameX = value;
                }
            }

            public virtual string CoordinateNameY
            {
                get
                {
                    return this.str_DrawCoordinateNameY;
                }
                set
                {
                    if (value == null)
                        return;
                    this.str_DrawCoordinateNameY = value;
                }
            }

            public virtual string CoordinateNameZ
            {
                get
                {
                    return this.str_DrawCoordinateNameZ;
                }
                set
                {
                    if (value == null)
                        return;
                    this.str_DrawCoordinateNameZ = value;
                }
            }

            public virtual Brush BrushCoordinateAreaXY
            {
                get
                {
                    return this.brush_BrushCoordinateAreaXY;
                }
                set
                {
                    this.brush_BrushCoordinateAreaXY = value;
                }
            }

            public virtual Brush BrushCoordinateAreaYZ
            {
                get
                {
                    return this.brush_BrushCoordinateAreaYZ;
                }
                set
                {
                    this.brush_BrushCoordinateAreaYZ = value;
                }
            }

            public virtual Brush BrushCoordinateAreaXZ
            {
                get
                {
                    return this.brush_BrushCoordinateAreaXZ;
                }
                set
                {
                    this.brush_BrushCoordinateAreaXZ = value;
                }
            }

            public CoordinateSettings()
            {
                this.uDrawFont = new Font("Comic Sans MS", 13.5f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
                this.uDrawFormat = "0.###";
                this.uBrushString = (Brush)new SolidBrush(Color.Black);
                this.uDrawPenCoordinate = new Pen(Color.Black, 4f);
                this.uDrawPenSubCoordinate = new Pen(Color.Black, 1f);
                this.b_EnableDrawSubCoordinateXY = true;
                this.b_EnableDrawSubCoordinateYZ = true;
                this.b_EnableDrawSubCoordinateXZ = true;
                this.b_EnableDrawCoordinateAreaXY = true;
                this.b_EnableDrawCoordinateAreaYZ = true;
                this.b_EnableDrawCoordinateAreaXZ = true;
                this.b_EnableDrawTopCoordinateXY = true;
                this.b_EnableDrawTopCoordinateYZ = true;
                this.b_EnableDrawTopCoordinateXZ = true;
                this.b_EnableDrawTopCoordinateXYZ = true;
                this.b_EnableDrawCoordinateValue = true;
                this.f_DrawSmallCoordinatePercent = 0.02f;
                this.i_DrawCoordinateNumberX = 20;
                this.i_DrawCoordinateNumberY = 10;
                this.i_DrawCoordinateNumberZ = 10;
                this.str_DrawCoordinateNameX = "x";
                this.str_DrawCoordinateNameY = "y";
                this.str_DrawCoordinateNameZ = "z";
                this.brush_BrushCoordinateAreaXY = (Brush)new SolidBrush(Color.FromArgb(30, Color.LightBlue));
                this.brush_BrushCoordinateAreaYZ = (Brush)new SolidBrush(Color.FromArgb(30, Color.Thistle));
                this.brush_BrushCoordinateAreaXZ = (Brush)new SolidBrush(Color.FromArgb(30, Color.Goldenrod));
                this.PenCoordinate.DashStyle = DashStyle.Solid;
                this.PenCoordinate.StartCap = LineCap.NoAnchor;
                this.PenCoordinate.EndCap = LineCap.ArrowAnchor;
            }
        }
    }
}
