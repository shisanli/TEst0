using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFunctionLib.DrawFunction3DModel
{
    public abstract class DrawBase
    {
        protected List<DrawFunctionLib.DrawFunction3DPart.DrawBase> list_PartList;
        protected DrawFunction3D df_IndexDrawFunction;

        public abstract DrawBase.ModelType ModelStyle { get; }

        public virtual List<DrawFunctionLib.DrawFunction3DPart.DrawBase> PartList
        {
            get
            {
                return this.list_PartList;
            }
            set
            {
                this.list_PartList = value;
            }
        }

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

        public DrawBase()
        {
            this.list_PartList = new List<DrawFunction3DPart.DrawBase>();
            this.df_IndexDrawFunction = (DrawFunction3D)null;
        }

        public abstract bool CalcualteModel();

        public enum ModelType : short
        {
            Changed,
            Fixed,
        }
    }
}
