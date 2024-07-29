using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Show3DWithOpenGL
{
    public partial class Show3DControl : UserControl
    {
        /// <summary>
        /// 选择事件参数
        /// </summary>
        public class SelectEventArgs : EventArgs
        {
            public string Name;
            public List<Collision> SelectedCollisions = new List<Collision>();
            public SelectEventArgs()
                : base()
            {
                Name = "";
                SelectedCollisions = new List<Collision>();
            }
            public SelectEventArgs(string name, List<Collision> points)
            {
                Name = name;
                SelectedCollisions = points;
            }
        }
        /// <summary>
        /// 选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void SelectEventHandler(object sender, SelectEventArgs e);
        /// <summary>
        /// 选点模式{单点模式，多点模式}
        /// </summary>
        public enum PointMode
        {
            SinglePoint,
            MultiplePoints
        }
        /// <summary>
        /// 视图类型{正视图，后视图，左视图，右视图，俯视图，仰视图}
        /// </summary>
        public enum ViewType
        {
            Top,
            Bottom,
            Front,
            Back,
            Left,
            Right
        }
        private Vector3D defaultcolor = new Vector3D(1, 0, 0), defaultbackcolor = new Vector3D(0, 0, 0), defaultarrowcolor = new Vector3D(0, 0, 1);
        private float defaultalpha = 1f, defaultsize = 0.1f, defaultbackalpha = 1f, defaultarrowalpha = 1f, defaultselectedsize = 0.1f, defaulttextballsize = 0.1f;
        private float _MinDistance = 25f, _MaxDistance = 500f;
        private int MouseX = 0, MouseY = 0, ZoomX = 0, ZoomY = 0;
        private Vector3D ZoomCenter = new Vector3D();
        private float m_distance = 100f, rotation = 0f;
        private Vector3D m_SightAngle = new Vector3D(1f, 0f, 0f), m_SightCenter = new Vector3D(), m_SightUP = new Vector3D(0f, 0f, 1f), m_RotateCenter = new Vector3D();
        private float _MoveSpeed = 1 / 180f, _RotateSpeed = 1 / 180f, _ZoomSpeed = 1 / 1000f;
        private List<MarkPoint> PointList = new List<MarkPoint>(), tempPointList = new List<MarkPoint>();
        private List<Collision> SelectedPointList = new List<Collision>(), tempSelectedPointList = new List<Collision>();
        private List<Model_Triangle> ModelList = new List<Model_Triangle>(), tempModelList = new List<Model_Triangle>();
        private List<TextLabel> TextLabelList = new List<TextLabel>(), tempTextLabelList = new List<TextLabel>();
        private List<Arrow3D> ArrowList = new List<Arrow3D>(), tempArrowList = new List<Arrow3D>();
        private float[,] CubePoints = new float[24, 3];
        private Model_Triangle ballmodel = Model_Triangle.BALL, simianti = Model_Triangle.SiMianTi;
        private MouseButtons _PanButton = MouseButtons.Middle, _RotateButton = MouseButtons.Right, _SelectButton = MouseButtons.Left;
        private PointMode _SelectMode = PointMode.SinglePoint;
        private bool _lockview = false, _showerror = false;

        //private Bitmap bmp;
        //private byte[] bytes;
        //private uint[] ulist;
        //private string[] slist;

        private float m_LastDistance = 100f;
        private Vector3D m_LastAngle = new Vector3D(1f, 0, 0), m_LastCenter = new Vector3D();
        private byte[] blist;
        private char charx;

        /// <summary>
        /// 执行平移操作的鼠标按键
        /// </summary>
        [Browsable(true), Category("自定义"), Description("执行平移操作的鼠标按键")]
        public MouseButtons PanButton
        {
            get { return _PanButton; }
            set
            {
                if (_RotateButton == value) _RotateButton = _PanButton;
                if (_SelectButton == value) _SelectButton = _PanButton;
                _PanButton = value;
            }
        }
        /// <summary>
        /// 执行旋转操作的鼠标按键
        /// </summary>
        [Browsable(true), Category("自定义"), Description("执行旋转操作的鼠标按键")]
        public MouseButtons RotateButton
        {
            get { return _RotateButton; }
            set
            {
                if (_PanButton == value) _PanButton = _RotateButton;
                if (_SelectButton == value) _SelectButton = _RotateButton;
                _RotateButton = value;
            }
        }
        /// <summary>
        /// 执行选择操作的鼠标按键
        /// </summary>
        [Browsable(true), Category("自定义"), Description("执行选择操作的鼠标按键")]
        public MouseButtons SelectButton
        {
            get { return _SelectButton; }
            set
            {
                if (_PanButton == value) _PanButton = _SelectButton;
                if (_RotateButton == value) _RotateButton = _SelectButton;
                _SelectButton = value;
            }
        }
        /// <summary>
        /// 平移操作的速度因子
        /// </summary>
        [Browsable(true), Category("自定义"), Description("平移操作的速度因子")]
        public float MoveSpeed
        {
            get { return _MoveSpeed; }
            set
            {
                _MoveSpeed = value;
                if (value <= 0f) _MoveSpeed = 1 / 180f;
            }
        }
        /// <summary>
        /// 旋转操作的速度因子
        /// </summary>
        [Browsable(true), Category("自定义"), Description("旋转操作的速度因子")]
        public float RotateSpeed
        {
            get { return _RotateSpeed; }
            set
            {
                _RotateSpeed = value;
                if (value <= 0f) _RotateSpeed = 1 / 180f;
            }
        }
        /// <summary>
        /// 缩放操作的速度因子
        /// </summary>
        [Browsable(true), Category("自定义"), Description("缩放操作的速度因子")]
        public float ZoomSpeed
        {
            get { return _ZoomSpeed; }
            set
            {
                _ZoomSpeed = value;
                if (value <= 0f) _ZoomSpeed = 1 / 1000f;
            }
        }
        /// <summary>
        /// 最小缩放距离
        /// </summary>
        [Browsable(true), Category("自定义"), Description("最小缩放距离")]
        public float MinDistance
        {
            get { return _MinDistance; }
            set
            {
                if (value <= 0f) _MinDistance = 1 / 1000f;
                else if (value >= _MaxDistance) _MinDistance = _MaxDistance;
                else _MinDistance = value;
            }
        }
        /// <summary>
        /// 最大缩放距离
        /// </summary>
        [Browsable(true), Category("自定义"), Description("最大缩放距离")]
        public float MaxDistance
        {
            get { return _MaxDistance; }
            set
            {
                if (value <= _MinDistance) _MaxDistance = _MinDistance;
                else _MaxDistance = value;
            }
        }
        /// <summary>
        /// 标记点的颜色
        /// </summary>
        [Browsable(true), Category("自定义"), Description("标记点的颜色")]
        public Color MarkColor
        {
            get
            {
                return Color.FromArgb((int)(255 * defaultalpha), (int)(255 * defaultcolor.x), (int)(255 * defaultcolor.y), (int)(255 * defaultcolor.z));
            }
            set
            {
                defaultcolor = Vector3D.ColerVector3D(value);
                defaultalpha = value.A / 255f;
            }
        }
        /// <summary>
        /// 标记点的大小
        /// </summary>
        [Browsable(true), Category("自定义"), Description("标记点的大小")]
        public float MarkSize
        {
            get
            {
                return defaultsize;
            }
            set
            {
                defaultsize = value;
            }
        }
        /// <summary>
        /// 文字标记点的大小
        /// </summary>
        [Browsable(true), Category("自定义"), Description("文字标记点的大小")]
        public float TextMarkSize
        {
            get
            {
                return defaulttextballsize;
            }
            set
            {
                defaulttextballsize = value;
            }
        }
        /// <summary>
        /// 选中点的大小
        /// </summary>
        [Browsable(true), Category("自定义"), Description("选中点的大小")]
        public float SelectedSize
        {
            get
            {
                return defaultselectedsize;
            }
            set
            {
                defaultselectedsize = value;
            }
        }
        /// <summary>
        /// 是否显示帧率
        /// </summary>
        [Browsable(true), Category("自定义"), Description("是否显示帧率")]
        public bool DrawFPS
        {
            get
            {
                return openGLControl1.DrawFPS;
            }
            set
            {
                openGLControl1.DrawFPS = value;
            }
        }
        /// <summary>
        /// 是否锁定视图
        /// </summary>
        [Browsable(true), Category("自定义"), Description("是否锁定视图")]
        public bool LockView
        {
            get
            {
                return _lockview;
            }
            set
            {
                _lockview = value;
            }
        }
        /// <summary>
        /// 是否显示异常
        /// </summary>
        [Browsable(true), Category("自定义"), Description("是否显示异常")]
        public bool ShowError
        {
            get
            {
                return _showerror;
            }
            set
            {
                _showerror = value;
            }
        }
        /// <summary>
        /// 背景的颜色
        /// </summary>
        [Browsable(true), Category("自定义"), Description("背景的颜色")]
        public Color BackgroundColor
        {
            get
            {
                return Color.FromArgb((int)(255 * defaultbackalpha), (int)(255 * defaultbackcolor.x), (int)(255 * defaultbackcolor.y), (int)(255 * defaultbackcolor.z));
            }
            set
            {
                defaultbackcolor = Vector3D.ColerVector3D(value);
                defaultbackalpha = value.A / 255f;
            }
        }
        /// <summary>
        /// 箭头的颜色
        /// </summary>
        [Browsable(true), Category("自定义"), Description("箭头的颜色")]
        public Color ArrowColor
        {
            get
            {
                return Color.FromArgb((int)(255 * defaultarrowalpha), (int)(255 * defaultarrowcolor.x), (int)(255 * defaultarrowcolor.y), (int)(255 * defaultarrowcolor.z));
            }
            set
            {
                defaultarrowcolor = Vector3D.ColerVector3D(value);
                defaultarrowalpha = value.A / 255f;
            }
        }
        /// <summary>
        /// 选择点的模式
        /// </summary>
        [Browsable(true), Category("自定义"), Description("选择点的模式")]
        public PointMode SelectMode
        {
            get { return _SelectMode; }
            set
            {
                _SelectMode = value;
            }
        }
        /// <summary>
        /// 当用户选择点时发生的事件
        /// </summary>
        [Browsable(true), Category("行为"), Description("当用户选择点时发生")]
        public event SelectEventHandler SelectEvent;
        /// <summary>
        /// 构造函数
        /// </summary>
        public Show3DControl()
        {
            InitializeComponent();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    CubePoints[4 * i + j, i % 3] = 2 * (i / 3) - 1f;
                    CubePoints[4 * i + j, (i + 1) % 3] = 2 * (j / 2) - 1f;
                    CubePoints[4 * i + j, (i + 2) % 3] = (j / 2 + j % 2 == 1) ? -1f : 1f;
                }
            }
        }

        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            try
            {
                //  Get the OpenGL object.
                OpenGL gl = openGLControl1.OpenGL;
                gl.ClearColor(defaultbackcolor.x, defaultbackcolor.y, defaultbackcolor.z, defaultbackalpha);
                //OpenGL gl = openGLControl1.OpenGL;
                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
                gl.LoadIdentity();

                Draw3D(gl);
                gl.Flush();
                Vector3D eye = m_distance * m_SightAngle.Normalize() + m_SightCenter;
                gl.MatrixMode(OpenGL.GL_PROJECTION);

                //  Load the identity.
                gl.LoadIdentity();
                gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 1000.0);
                gl.LookAt(eye.x, eye.y, eye.z, m_SightCenter.x, m_SightCenter.y, m_SightCenter.z, m_SightUP.x, m_SightUP.y, m_SightUP.z);
                gl.MatrixMode(OpenGL.GL_MODELVIEW);
                gl.Flush();
            }
            catch (Exception e)
            {
                if (_showerror) MessageBox.Show(e.Message);
            }
        }

        private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            //  TODO: Initialise OpenGL here.

            //  Get the OpenGL object.
            OpenGL gl = openGLControl1.OpenGL;

            //  Set the clear color.
            gl.ClearColor(defaultbackcolor.x, defaultbackcolor.y, defaultbackcolor.z, defaultbackalpha);
        }

        private void openGLControl1_Resized(object sender, EventArgs e)
        {
            //  TODO: Set the projection matrix here.

            //  Get the OpenGL object.
            OpenGL gl = openGLControl1.OpenGL;

            //  Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            gl.LoadIdentity();

            //  Create a perspective transformation.
            gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 100.0);

            Vector3D eye = m_distance * m_SightAngle.Normalize() + m_SightCenter;
            //  Use the 'look at' helper function to position and aim the camera.
            //gl.LookAt(-5, 0, -5, 0, 0, 0, 0, 1, 0);
            gl.LookAt(eye.x, eye.y, eye.z, m_SightCenter.x, m_SightCenter.y, m_SightCenter.z, m_SightUP.x, m_SightUP.y, m_SightUP.z);

            //  Set the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            ReCalculateText();
        }

        private void openGLControl1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (LockView) return;
                int tempX = e.X, tempY = e.Y;
                if (e.Button == PanButton)
                {
                    m_SightCenter += (tempX - MouseX) * MoveSpeed * (float)Math.Pow(m_distance / 5 + 1, 0.75) * (m_SightAngle * m_SightUP).Normalize();
                    m_SightCenter += (tempY - MouseY) * MoveSpeed * (float)Math.Pow(m_distance / 5 + 1, 0.75) * m_SightUP.Normalize();
                }
                if (e.Button == RotateButton)
                {
                    m_SightAngle.SelfRotate((MouseX - tempX) * RotateSpeed, m_SightUP);
                    m_SightCenter.SelfRotate((MouseX - tempX) * RotateSpeed, m_RotateCenter, m_SightUP);
                    Vector3D axis = (m_SightAngle * m_SightUP).Normalize();
                    m_SightAngle.SelfRotate((tempY - MouseY) * RotateSpeed, axis);
                    m_SightUP.SelfRotate((tempY - MouseY) * RotateSpeed, axis);
                    m_SightCenter.SelfRotate((tempY - MouseY) * RotateSpeed, m_RotateCenter, axis);
                }
                MouseX = tempX;
                MouseY = tempY;
                ReCalculateText();
            }
            catch (Exception e1)
            {
                if (_showerror) MessageBox.Show(e1.Message);
            }
        }
        private void openGLControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (LockView) return;
                if (e.X != ZoomX || e.Y != ZoomY)
                {
                    List<Collision> collisionlist = SelectPoint(e.X, e.Y);
                    if (collisionlist.Count > 0)
                    {
                        ZoomCenter = collisionlist[0].point.vertex;
                    }
                    else
                    {
                        ZoomCenter = (1f - 2f * ((float)e.Y / (float)Height)) * m_distance / (float)Math.Sqrt(3) * m_SightUP.Normalize() + (2f * (float)e.X - (float)Width) / (float)Height * m_distance / (float)Math.Sqrt(3) * (m_SightUP * m_SightAngle).Normalize() + m_SightCenter;
                    }
                    ZoomX = e.X;
                    ZoomY = e.Y;
                }
                Vector3D v1 = ZoomCenter - m_SightCenter;
                float f1 = m_distance * (float)Math.Pow(2f, e.Delta * ZoomSpeed);
                f1 = f1 > _MinDistance ? f1 : _MinDistance;
                f1 = f1 < _MaxDistance ? f1 : _MaxDistance;
                float f2 = f1 / m_distance;
                Vector3D v2 = f2 * v1;
                m_SightCenter = m_SightCenter + v1 - v2;
                m_distance = f1;
                ReCalculateText();
            }
            catch (Exception e1)
            {
                if (_showerror) MessageBox.Show(e1.Message);
            }
        }
        /// <summary>
        /// 计算文字显示方式
        /// </summary>
        /// <param name="NewText"></param>
        public void ReCalculateText(bool NewText = false)
        {
            if (m_LastAngle != m_SightAngle || m_LastCenter != m_SightCenter || m_LastDistance != m_distance || NewText)
            {
                Vector3D eye = m_distance * m_SightAngle.Normalize() + m_SightCenter;
                for (int i = 0; i < tempTextLabelList.Count; i++)
                {
                    TextLabel t = tempTextLabelList[i];
                    if (t.LabelType == TextLabel.TextLabelType.TextLabel3D)
                    {
                        t.ReCalculateBack(eye, 1);
                        t = Vertex3DtoVertex2D(t);
                    }
                    if (t.LabelType == TextLabel.TextLabelType.AlwaysDisplay)
                    {
                        t = Vertex3DtoVertex2D(t);
                    }
                    tempTextLabelList[i] = t;
                }
                m_LastAngle = new Vector3D(m_SightAngle);
                m_LastDistance = m_distance;
                m_LastCenter = new Vector3D(m_SightCenter);
            }
        }
        /// <summary>
        /// 设置视图
        /// </summary>
        /// <param name="distance">焦距</param>
        /// <param name="Center">焦点</param>
        /// <param name="Angle">视野方向</param>
        /// <param name="SightUP">视图上方向</param>
        public void SetView(float distance, Vector3D Center, Vector3D Angle, Vector3D SightUP)
        {
            m_distance = distance > 0.1f ? distance : 0.1f;
            if (Center != null) m_SightCenter = Center;
            if ((Angle != null) && (SightUP != null) && ((Angle * SightUP).Length() != 0f))
            {
                if (Angle.Length() != 0f) m_SightAngle = Angle.Normalize();
                if (SightUP.Length() != 0f) m_SightUP = SightUP.Normalize();
            }
            ReCalculateText();
        }
        /// <summary>
        /// 设置视图
        /// </summary>
        /// <param name="distance">焦距</param>
        /// <param name="vt">视图类型</param>
        public void SetView(float distance, ViewType vt)
        {
            m_distance = distance > 0.1f ? distance : 0.1f;
            switch (vt)
            {
                case (ViewType.Front):
                    m_SightAngle = new Vector3D(1f, 0f, 0f);
                    m_SightCenter = new Vector3D();
                    m_SightUP = new Vector3D(0f, 0f, 1f);
                    break;
                case (ViewType.Back):
                    m_SightAngle = new Vector3D(-1f, 0f, 0f);
                    m_SightCenter = new Vector3D();
                    m_SightUP = new Vector3D(0f, 0f, 1f);
                    break;
                case (ViewType.Left):
                    m_SightAngle = new Vector3D(0f, -1f, 0f);
                    m_SightCenter = new Vector3D();
                    m_SightUP = new Vector3D(0f, 0f, 1f);
                    break;
                case (ViewType.Right):
                    m_SightAngle = new Vector3D(0f, 1f, 0f);
                    m_SightCenter = new Vector3D();
                    m_SightUP = new Vector3D(0f, 0f, 1f);
                    break;
                case (ViewType.Top):
                    m_SightAngle = new Vector3D(0f, 0f, 1f);
                    m_SightCenter = new Vector3D();
                    m_SightUP = new Vector3D(-1f, 0f, 0f);
                    break;
                case (ViewType.Bottom):
                    m_SightAngle = new Vector3D(0f, 0f, -1f);
                    m_SightCenter = new Vector3D();
                    m_SightUP = new Vector3D(1f, 0f, 0f);
                    break;
            }
            ReCalculateText();
        }
        /// <summary>
        /// 旋转视图
        /// </summary>
        /// <param name="angle">旋转角度，以弧度计量的角度</param>
        public void RotateView(float angle)
        {
            m_SightUP.SelfRotate(angle, m_SightAngle);
        }
        //private void draw(OpenGL gl)
        //{
        //    //OpenGL gl = openGLControl1.OpenGL;

        //    //  Clear the color and depth buffer.
        //    gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

        //    //  Load the identity matrix.
        //    gl.LoadIdentity();

        //    //  Rotate around the Y axis.
        //    //gl.Rotate(rotation, 0.0f, 1.0f, 0.0f);
        //    //gl.Rotate(rotation, 1.0f, 0.0f, 0.0f);

        //    //  Draw a coloured pyramid.
        //    gl.Begin(OpenGL.GL_TRIANGLES);
        //    gl.Color(1.0f, 0.0f, 0.0f);
        //    gl.Vertex(0.0f, 1.0f, 0.0f);
        //    gl.Color(0.0f, 1.0f, 0.0f);
        //    gl.Vertex(-1.0f, -1.0f, 1.0f);
        //    gl.Color(0.0f, 0.0f, 1.0f);
        //    gl.Vertex(1.0f, -1.0f, 1.0f);
        //    gl.Color(1.0f, 0.0f, 0.0f);
        //    gl.Vertex(0.0f, 1.0f, 0.0f);
        //    gl.Color(0.0f, 0.0f, 1.0f);
        //    gl.Vertex(1.0f, -1.0f, 1.0f);
        //    gl.Color(0.0f, 1.0f, 0.0f);
        //    gl.Vertex(1.0f, -1.0f, -1.0f);
        //    gl.Color(1.0f, 0.0f, 0.0f);
        //    gl.Vertex(0.0f, 1.0f, 0.0f);
        //    gl.Color(0.0f, 1.0f, 0.0f);
        //    gl.Vertex(1.0f, -1.0f, -1.0f);
        //    gl.Color(0.0f, 0.0f, 1.0f);
        //    gl.Vertex(-1.0f, -1.0f, -1.0f);
        //    gl.Color(1.0f, 0.0f, 0.0f);
        //    gl.Vertex(0.0f, 1.0f, 0.0f);
        //    gl.Color(0.0f, 0.0f, 1.0f);
        //    gl.Vertex(-1.0f, -1.0f, -1.0f);
        //    gl.Color(0.0f, 1.0f, 0.0f);
        //    gl.Vertex(-1.0f, -1.0f, 1.0f);
        //    gl.End();
        //    gl.Begin(OpenGL.GL_POINTS);
        //    gl.PointSize(10);
        //    gl.Color(1f, 0, 0);
        //    gl.Vertex(0, 0, 20);
        //    gl.End();
        //    //DrawCube(new Vector3D(0, 0, 20), 0.2f, gl);
        //}
        private void Draw3D(OpenGL gl)
        {
            foreach (Arrow3D a in ArrowList) DrawArrow(gl, a, a.Color);
            foreach (MarkPoint p in PointList)
            {
                //DrawCube(gl, p.vertex, defaultsize, defaultcolor);
                if (p.MarkMode == MarkPointMode.QiuTi) DrawBall(gl, p.point.vertex, defaultsize, p.point.color);
                if (p.MarkMode == MarkPointMode.SiMianTi) DrawSiMianTi(gl, p.point.vertex, defaultsize, p.point.color);
                if (p.MarkMode == MarkPointMode.ZhengFangTi) DrawCube(gl, p.point.vertex, defaultsize, p.point.color);
            }
            foreach (Collision c in SelectedPointList)
            {
                //DrawCube(gl, c.point.vertex, defaultsize, defaultcolor);
                DrawBall(gl, c.point.vertex, defaultselectedsize, defaultcolor);
            }

            gl.Begin(OpenGL.GL_TRIANGLES);
            foreach (Model_Triangle m in ModelList)
            {
                if (m.TypeOfModel == Model_Triangle.ModelType.OBJ)
                    foreach (Triangle triangle in m.TriangleList)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            gl.Color(m.PointList[triangle.vertex_index[i]].color.x, m.PointList[triangle.vertex_index[i]].color.y, m.PointList[triangle.vertex_index[i]].color.z, m.Alpha);
                            gl.Vertex(m.PointList[triangle.vertex_index[i]].vertex.x, m.PointList[triangle.vertex_index[i]].vertex.y, m.PointList[triangle.vertex_index[i]].vertex.z);
                        }
                    }
                if (m.TypeOfModel == Model_Triangle.ModelType.STL)
                    foreach (Triangle triangle in m.TriangleList)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            gl.Color(triangle.point[i].color.x, triangle.point[i].color.y, triangle.point[i].color.z, m.Alpha);
                            gl.Vertex(triangle.point[i].vertex.x, triangle.point[i].vertex.y, triangle.point[i].vertex.z);
                        }
                    }
                if (m.TypeOfModel == Model_Triangle.ModelType.CUSTOM)
                {
                    foreach (Triangle triangle in m.TriangleList)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            GL_Color(gl, m.ColorList[triangle.vertex_index[i]], m.Alpha);
                            GL_Vertex(gl, m.VertexList[triangle.vertex_index[i]]);
                            //gl.Color(m.PointList[triangle.vertex_index[i]].color.x, m.PointList[triangle.vertex_index[i]].color.y, m.PointList[triangle.vertex_index[i]].color.z,1f);
                            //gl.Vertex(m.PointList[triangle.vertex_index[i]].vertex.x, m.PointList[triangle.vertex_index[i]].vertex.y, m.PointList[triangle.vertex_index[i]].vertex.z);
                        }
                    }
                }
            }
            gl.End();

            foreach (TextLabel t in TextLabelList)
            {
                if (t.CanSee())
                {
                    if (t.DrawPoint()) DrawBall(gl, t.Vertex3D, defaulttextballsize, defaultcolor);
                    TextLabel temp = Vertex3DtoVertex2D(t);
                    gl.DrawText((int)(temp.Vertex2D.X + temp.DeltaVertex2D.X), (int)(temp.Vertex2D.Y + temp.DeltaVertex2D.Y), temp.TextColor.x, temp.TextColor.y, temp.TextColor.z, temp.FontName, temp.Size, temp.Text);
                }
            }

            ModelList = tempModelList;
            PointList = tempPointList;
            TextLabelList = tempTextLabelList;
            ArrowList = tempArrowList;
            SelectedPointList = tempSelectedPointList;
        }
        private void DrawCube(OpenGL gl, Vector3D center, float size = 0.1f, Vector3D color = null)
        {
            if (color == null || color == new Vector3D()) color = defaultcolor;
            float[,] p = new float[24, 3];
            for (int i = 0; i < 24; i++)
            {
                p[i, 0] = center.x + CubePoints[i, 0] * size / 2f;
                p[i, 1] = center.y + CubePoints[i, 1] * size / 2f;
                p[i, 2] = center.z + CubePoints[i, 2] * size / 2f;
            }
            gl.Begin(OpenGL.GL_QUADS);
            for (int i = 0; i < 24; i++)
            {
                GL_Color(gl, color);
                gl.Vertex(p[i, 0], p[i, 1], p[i, 2]);
            }
            gl.End();
        }
        private void DrawSiMianTi(OpenGL gl, Vector3D center, float size = 0.1f, Vector3D color = null)
        {
            if (color == null || color == new Vector3D()) color = defaultcolor;
            gl.Begin(OpenGL.GL_TRIANGLES);
            foreach (Triangle t in simianti.TriangleList)
            {
                for (int i = 0; i < 3; i++)
                {
                    GL_Color(gl, color);
                    GL_Vertex(gl, simianti.VertexList[t.vertex_index[i]] * size + center);
                }
            }
            gl.End();
        }
        private void DrawBall(OpenGL gl, Vector3D center, float size = 0.1f, Vector3D color = null)
        {
            if (color == null || color == new Vector3D()) color = defaultcolor;
            gl.Begin(OpenGL.GL_TRIANGLES);
            foreach (Triangle t in ballmodel.TriangleList)
            {
                for (int i = 0; i < 3; i++)
                {
                    GL_Color(gl, color);
                    GL_Vertex(gl, ballmodel.VertexList[t.vertex_index[i]] * 0.5f * size + center);
                }
            }
            gl.End();
        }
        private void DrawArrow(OpenGL gl, Arrow3D arrow, Vector3D color = null)
        {
            if (color == null || color == new Vector3D()) color = defaultarrowcolor;
            gl.Begin(OpenGL.GL_LINES);
            gl.LineWidth(arrow.Width);
            GL_Color(gl, color, defaultarrowalpha);
            GL_Vertex(gl, arrow.StartPosition);
            GL_Color(gl, color, defaultarrowalpha);
            GL_Vertex(gl, arrow.EndPosition);
            gl.End();
            gl.Begin(OpenGL.GL_TRIANGLES);
            foreach (Triangle t in arrow.ArrowHead.TriangleList)
            {
                for (int i = 0; i < 3; i++)
                {
                    GL_Color(gl, color);
                    GL_Vertex(gl, arrow.ArrowHead.VertexList[t.vertex_index[i]]);
                }
            }
            gl.End();
        }
        //private void DrawTextBytes(OpenGL gl,TextLabel t)
        //{
        //    gl.Begin(OpenGL.GL_BITMAP);
        //    //gl.Bitmap((int)(t.Vertex2D.X + t.DeltaVertex2D.X), (int)(t.Vertex2D.Y + t.DeltaVertex2D.Y), 0, 0, 0, 0, t.TextBytes);
        //    //gl.RasterPos((int)(t.Vertex2D.X + t.DeltaVertex2D.X), (int)(t.Vertex2D.Y + t.DeltaVertex2D.Y));
        //    gl.RasterPos((t.Vertex2D.X + t.DeltaVertex2D.X)/Width, (t.Vertex2D.Y + t.DeltaVertex2D.Y)/Height);
        //    gl.Bitmap(t.TextWidth+1, t.TextHeight+1, 0, 0, 0, 0, t.TextBytes);
        //    gl.End();
        //}
        //private void DrawTextBytes(OpenGL gl, TextLabel t)
        //{
        //    gl.Enable(OpenGL.GL_TEXTURE_2D);
        //    gl.BindTexture(OpenGL.GL_TEXTURE_2D, t.gtexture[0]);
        //    //gl.Color(1.0f, 1.0f, 1.0f,1.0f);
        //    gl.Begin(OpenGL.GL_QUADS);

        //    gl.TexCoord(1.0f, 1.0f);
        //    gl.Vertex(t.TextWidth, t.TextHeight);

        //    gl.TexCoord(0.0f, 1.0f);
        //    gl.Vertex(0.0f, t.TextHeight);

        //    gl.TexCoord(0.0f, 0.0f);
        //    gl.Vertex(0.0f, 0.0f);

        //    gl.TexCoord(1.0f, 0.0f);
        //    gl.Vertex(t.TextWidth, 0.0f);

        //    gl.End();
        //    gl.Disable(OpenGL.GL_TEXTURE_2D);
        //}
        /// <summary>
        /// 设置要显示的列表
        /// </summary>
        /// <param name="model_list">模型列表</param>
        /// <param name="point_list">点列表</param>
        /// <param name="textlabel_list">文字列表</param>
        /// /// <param name="arrow_list">箭头列表</param>
        public void SetDrawList(List<Model_Triangle> model_list, List<MarkPoint> point_list, List<TextLabel> textlabel_list, List<Arrow3D> arrow_list)
        {
            OpenGL gl = openGLControl1.OpenGL;
            tempModelList = model_list;
            tempPointList = point_list;
            tempTextLabelList = textlabel_list;
            tempArrowList = arrow_list;
        }
        /// <summary>
        /// 设置要显示的模型列表
        /// </summary>
        /// <param name="model_list"></param>
        public void SetModelList(List<Model_Triangle> model_list)
        {
            tempModelList = model_list;
        }
        /// <summary>
        /// 设置要显示的点的列表
        /// </summary>
        /// <param name="point_list"></param>
        public void SetPointList(List<MarkPoint> point_list)
        {
            tempPointList = point_list;
        }
        /// <summary>
        /// 设置显示文字列表
        /// </summary>
        /// <param name="textlabel_list"></param>
        public void SetTextLabelList(List<TextLabel> textlabel_list)
        {
            tempTextLabelList = textlabel_list;
            ReCalculateText(true);
        }
        /// <summary>
        /// 设置箭头显示列表
        /// </summary>
        /// <param name="arrow_list"></param>
        public void SetArrowList(List<Arrow3D> arrow_list)
        {
            tempArrowList = arrow_list;
        }
        /// <summary>
        /// 获取已选中的点
        /// </summary>
        /// <returns></returns>
        public List<Collision> GetSelectedPoints()
        {
            return tempSelectedPointList;
        }
        /// <summary>
        /// 重置选中点
        /// </summary>
        public void ResetSelected()
        {
            tempSelectedPointList = new List<Collision>();
        }
        /// <summary>
        /// 获取绘图区域截图
        /// </summary>
        /// <param name="filename">保存的文件名，包含路径、文件名和文件格式，保存格式为PNG</param>
        public Bitmap GetPicture(string filename = "")
        {
            System.Drawing.Point p = this.PointToScreen(new System.Drawing.Point());
            p.X = (int)(p.X * ScaleX);
            p.Y = (int)(p.Y * ScaleY);
            Size s = this.Size;
            s.Width = (int)(s.Width * ScaleX);
            s.Height = (int)(s.Height * ScaleY);
            Bitmap bitmap = new Bitmap(s.Width, s.Height);//实例化一个和窗体一样大的bitmap
            Graphics g = Graphics.FromImage(bitmap);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;//质量设为最高
            //g.CopyFromScreen(this.Left, this.Top, 0, 0, new Size(this.Width, this.Height));//保存整个窗体为图片
            Graphics g1 = this.CreateGraphics();

            g.CopyFromScreen(p, new System.Drawing.Point(), s);
            bitmap = KiResizeImage(bitmap, this.Width, this.Height);
            if (filename != "")
            {
                if (File.Exists(filename))
                    File.Delete(filename);
                if (!File.Exists(filename))
                {
                    //bitmap.Save(filepath);//默认保存格式为PNG，保存成jpg格式质量不是很好
                    bitmap.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            return bitmap;
        }
        /// <summary>
        /// 获取视距
        /// </summary>
        /// <returns></returns>
        public float GetSightDistance()
        {
            return m_distance;
        }
        /// <summary>
        /// 设置是否透明
        /// </summary>
        /// <param name="b"></param>
        public void SetTransparent(bool b)
        {
            OpenGL gl = openGLControl1.OpenGL;
            if (b) gl.Enable(OpenGL.GL_BLEND);
            else gl.Disable(OpenGL.GL_BLEND);
        }
        public void SetBlendFunc(uint src, uint dst)
        {
            OpenGL gl = openGLControl1.OpenGL;
            gl.BlendFunc(src, dst);
        }
        public void SetRotateCenter(Vector3D center)
        {
            m_RotateCenter = center;
        }
        private List<Collision> SelectPoint(int mouse_x, int mouse_y)
        {
            Vector3D source = new Vector3D(), target = new Vector3D();
            source = m_SightCenter + m_distance * m_SightAngle.Normalize();
            target = m_SightCenter + (1f - 2f * ((float)mouse_y / (float)Height)) * m_distance / (float)Math.Sqrt(3) * m_SightUP.Normalize() + (2f * (float)mouse_x - (float)Width) / (float)Height * m_distance / (float)Math.Sqrt(3) * (m_SightUP * m_SightAngle).Normalize();
            Ray ray = new Ray(source, target);
            List<Collision> collisionlist = new List<Collision>();
            foreach (Model_Triangle m in ModelList)
            {
                if (m.CanBeSelected()) foreach (Collision c in m.HitResult(ray, true)) collisionlist.Add(c);
            }
            return CommonClass.SortHitResult(collisionlist);
            //if (collisionlist.Count > 0)
            //{
            //    if (SelectMode == PointMode.SinglePoint) ResetSelected();
            //    tempSelectedPointList.Add(collisionlist[0]);
            //}
            //if (SelectEvent != null) SelectEvent(this, new SelectEventArgs(this.Name, this.tempSelectedPointList));
            //PointList.Add(collisionlist[0].point);
        }
        private Vector2D Vertex3DtoVertex2D(Vector3D vertex)
        {
            Vector2D v2d = new Vector2D();
            Vector3D eye = m_distance * m_SightAngle.Normalize() + m_SightCenter;
            Vector3D v = vertex - eye;
            Vector3D temp = new Vector3D();
            Vector3D.Componet c = v.GetComponet(m_SightAngle);
            temp.x = c.Parallel.Length();
            if (temp.x <= 0f || c.Parallel.DotProduct(-m_SightAngle) <= 0f)
            {
                v2d.X = -1;
                v2d.Y = -1;
                return v2d;
            }
            c = v.GetComponet(m_SightUP);
            temp.z = c.Parallel.Length();
            if (c.Parallel.DotProduct(m_SightUP) <= 0f) temp.z = -temp.z;
            Vector3D v1 = m_SightUP * m_SightAngle;
            c = v.GetComponet(v1);
            temp.y = c.Parallel.Length();
            if (c.Parallel.DotProduct(v1) <= 0f) temp.y = -temp.y;
            v2d.X = (float)Width / 2f + (float)Height / 2f * (float)Math.Sqrt(3) * temp.y / temp.x;
            v2d.Y = (float)Height / 2f * (float)Math.Sqrt(3) * temp.z / temp.x + (float)Height / 2f;
            return v2d;
        }
        private TextLabel Vertex3DtoVertex2D(TextLabel textlabel)
        {
            if (textlabel.TextColor == null || textlabel.TextColor == new Vector3D()) textlabel.TextColor = defaultcolor;
            if (textlabel.LabelType == TextLabel.TextLabelType.TextLabel2D) return textlabel;
            textlabel.Vertex2D = Vertex3DtoVertex2D(textlabel.Vertex3D);
            return textlabel;
        }

        private void GL_Vertex(OpenGL gl, Vector3D vertex)
        {
            gl.Vertex(vertex.x, vertex.y, vertex.z);
        }
        private void GL_Color(OpenGL gl, Vector3D color, float alpha = 1f)
        {
            gl.Color(color.x, color.y, color.z, alpha);
        }
        private void openGLControl1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (LockView) return;
                if (e.Button == SelectButton)
                {
                    List<Collision> collisionlist = SelectPoint(e.X, e.Y);
                    if (SelectMode == PointMode.SinglePoint) ResetSelected();
                    if (collisionlist.Count > 0)
                    {
                        tempSelectedPointList.Add(collisionlist[0]);
                        if (SelectEvent != null) SelectEvent(this, new SelectEventArgs(this.Name, this.tempSelectedPointList));
                    }
                    //PointList.Add(collisionlist[0].point);
                }
            }
            catch (Exception e1)
            {
                if (_showerror) MessageBox.Show(e1.Message);
            }
            this.OnMouseDown(e);
        }

        private void openGLControl1_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);
        }
        //private void Scan(int yNum, int zNum, string filepath)
        //{
        //    if (yNum >= 2 && zNum >= 2 && filepath != "")
        //    {
        //        List<Vector3D> vlist = new List<Vector3D>();
        //        List<Collision> clist = new List<Collision>();
        //        for (int i = 0; i < yNum; i++)
        //        {
        //            for (int j = 0; j < zNum; j++)
        //            {
        //                float angle1 = 3.1415926535898f * ((float)i / (float)(yNum - 1)+4f/180f), angle2 = 3.1415926535898f * (float)j / (float)(zNum - 1);
        //                Vector3D axis = (-Vector3D.ZAxis).Rotate(angle1, -Vector3D.YAxis);
        //                Vector3D direction = Vector3D.YAxis.Rotate(angle2, axis);
        //                clist = new List<Collision>();
        //                while (clist.Count == 0)
        //                {
        //                    Ray ray = new Ray(new Vector3D(), direction);
        //                    foreach (Model_Triangle m in ModelList)
        //                    {
        //                        foreach (Collision c in m.HitResult(ray, true)) clist.Add(c);
        //                    }
        //                    clist = CommonClass.SortHitResultDESC(clist);
        //                    angle2 += 3.1415926535898f / (180f * 60f);
        //                    direction = Vector3D.YAxis.Rotate(angle2, axis);
        //                }
        //                vlist.Add(clist[0].point.vertex);
        //            }
        //        }
        //        List<string> slist = new List<string>();
        //        for (int i = 0; i < yNum; i++)
        //        {
        //            string s = "";
        //            for (int j = 0; j < zNum; j++)
        //            {
        //                s += vlist[i * zNum + j].ToString("# # #") + ";";
        //            }
        //            s = s.Substring(0, s.Length - 1);
        //            slist.Add(s);
        //        }
        //        //string filepath = @"D:\workspace\visual studio 2013\Show3DWithOpenGL\Show3DWithOpenGL\bin\Debug\" + filename;
        //        if (File.Exists(filepath))
        //            File.Delete(filepath);
        //        if (!File.Exists(filepath))
        //        {
        //            FileStream fs1 = new FileStream(filepath, FileMode.Create, FileAccess.Write);//创建写入文件 
        //            StreamWriter sw = new StreamWriter(fs1);
        //            foreach (string s in slist)
        //            {
        //                sw.WriteLine(s);
        //            }
        //            sw.Close();
        //            fs1.Close();
        //        }
        //    }
        //}


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Model_Triangle m = new Model_Triangle("人头", Model_Triangle.ModelType.STL, @"E:\360Downloads\Email_Files\rentou.stl");
        //    ModelList.Add(m);
        //    //Draw3D();
        //}
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    if(ModelList.Count>0) Scan(15*3+1, 11*3+1, @"D:\workspace\visual studio 2013\Show3DWithOpenGL\Show3DWithOpenGL\bin\Debug\touding.txt");
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    Model_Triangle m=new Model_Triangle("头顶",Model_Triangle.ModelType.CUSTOM,@"D:\workspace\visual studio 2013\Show3DWithOpenGL\Show3DWithOpenGL\bin\Debug\toudingOK.txt");
        //    //m.SaveCUSTOMModel(@"D:\workspace\visual studio 2013\Show3DWithOpenGL\Show3DWithOpenGL\bin\Debug\toudingOK.txt");
        //    //List<Model_Triangle> ml = new List<Model_Triangle>();
        //    ModelList.Add(m);
        //    //SetModelList(ml);
        //}
        #region Win32 API
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr ptr);
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(
        IntPtr hdc, // handle to DC
        int nIndex // index of capability
        );
        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);
        #endregion

        #region DeviceCaps常量
        const int HORZRES = 8;
        const int VERTRES = 10;
        const int LOGPIXELSX = 88;
        const int LOGPIXELSY = 90;
        const int DESKTOPVERTRES = 117;
        const int DESKTOPHORZRES = 118;
        #endregion

        public static readonly float ScaleX = GetScaleX();
        public static readonly float ScaleY = GetScaleY();
        private static float GetScaleX()
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            int t = GetDeviceCaps(hdc, DESKTOPHORZRES);
            int d = GetDeviceCaps(hdc, HORZRES);
            float scaleX = (float)GetDeviceCaps(hdc, DESKTOPHORZRES) / (float)GetDeviceCaps(hdc, HORZRES);
            ReleaseDC(IntPtr.Zero, hdc);
            return scaleX;
        }
        private static float GetScaleY()
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            float scaleY = (float)(float)GetDeviceCaps(hdc, DESKTOPVERTRES) / (float)GetDeviceCaps(hdc, VERTRES);
            ReleaseDC(IntPtr.Zero, hdc);
            return scaleY;
        }
        public static Bitmap KiResizeImage(Bitmap bmp, int newW, int newH)
        {
            try
            {
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);

                // 插值算法的质量
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();

                return b;
            }
            catch
            {
                return null;
            }
        }
    }
    public struct MarkPoint
    {
        public Point point;
        public MarkPointMode MarkMode;
    }
    public enum MarkPointMode
    {
        SiMianTi,
        ZhengFangTi,
        QiuTi
    }
}
