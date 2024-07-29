using System;
using System.Collections.Generic;
using System.Drawing;

namespace DrawFunctionLib.DrawFunction3DPart
{
    public abstract class DrawBase : IComparer<DrawBase>, IComparable<DrawBase>, ICloneable
    {
        protected DrawFunction3D df_IndexDrawFunction;

        public virtual DrawFunction3D IndexDrawFunction
        {
            get
            {
                return this.df_IndexDrawFunction;
            }
            set
            {
                this.df_IndexDrawFunction = value;
            }
        }

        public abstract float Depth { get; }

        public DrawBase()
        {
            this.df_IndexDrawFunction = (DrawFunction3D)null;
        }

        public abstract void DrawPart(Graphics DrawGraph);

        public int Compare(DrawBase x, DrawBase y)
        {
            return (double)x.Depth <= (double)y.Depth ? ((double)x.Depth >= (double)y.Depth ? 0 : -1) : 1;
        }

        public int CompareTo(DrawBase other)
        {
            return 1;
            //return (double)this.Depth <= (double)other.Depth ? ((double)this.Depth >= (double)other.Depth ? 0 : -1) : 1;
        }

        public abstract object Clone();
    }
}
