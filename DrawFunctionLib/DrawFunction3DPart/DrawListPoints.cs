using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFunctionLib.DrawFunction3DPart
{
    public abstract class DrawListPoints : DrawBase
    {
       
        public DrawListPoints()
        {
            this.list_PointList = new DrawFunction3D.PointF3D[]
            {
                new DrawFunction3D.PointF3D()
            };
        }

        
        public virtual DrawFunction3D.PointF3D[] PointList
        {
            get
            {
                return this.list_PointList;
            }
            set
            {
                this.list_PointList = value;
            }
        }

       
        public override float Depth
        {
            get
            {
                float num = 0f;
                checked
                {
                    if (this.PointList.Length > 0 & this.IndexDrawFunction != null)
                    {
                        num = this.IndexDrawFunction.DepthValueToDraw(this.PointList[0]);
                        int num2 = 0;
                        int num3 = this.PointList.Length - 1;
                        for (int i = num2; i <= num3; i++)
                        {
                            float num4 = this.IndexDrawFunction.DepthValueToDraw(this.PointList[i]);
                            if (num > num4)
                            {
                                num = num4;
                            }
                        }
                    }
                    return num;
                }
            }
        }

        // Token: 0x06000270 RID: 624 RVA: 0x00009AB0 File Offset: 0x00007EB0
        protected virtual DrawFunction3D.PointF3D[] ClonePointList()
        {
            checked
            {
                DrawFunction3D.PointF3D[] array = new DrawFunction3D.PointF3D[this.PointList.Length - 1 + 1];
                int num = 0;
                int num2 = array.Length - 1;
                for (int i = num; i <= num2; i++)
                {
                    array[i] = (DrawFunction3D.PointF3D)this.PointList[i].Clone();
                }
                return array;
            }
        }

        // Token: 0x040000F6 RID: 246
        protected DrawFunction3D.PointF3D[] list_PointList;
    }
}
