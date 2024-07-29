using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using LiveCharts.Charts;
using LiveCharts.Defaults;

namespace PressureUpper
{
    public class ChartViewModel
    {
        public ChartViewModel() { }//默认构造函数 用于角度数据
        private SeriesCollection AngleSeries = new() {
            //new StackedRowSeries{
            //    Values = new ChartValues<float> {0, 0, 0, 0,0,0},
            //    Title="力差",
            //    StackMode = StackMode.Values,
            //    DataLabels = true,
            //    LabelPoint = p => p.X.ToString()
            //},
            // new StackedRowSeries{Values = new ChartValues<float> {0, 0, 0, 0,0,0},
            //    StackMode = StackMode.Values,
            //    Title="合力",
            //    DataLabels = true,
            //    LabelPoint = p => p.X.ToString()
            // },

             new StackedRowSeries
            {
                Values = new ChartValues<float> {0, 0, 0, 0,0,0},
                StackMode = StackMode.Values,
                Title="内力",
                DataLabels = true,
                LabelPoint = p => p.X.ToString()

            },
            new StackedRowSeries
            {
                Values = new ChartValues<float> {0, 0, 0, 0,0,0},
                StackMode = StackMode.Values,
                Title="外力",
                DataLabels = true,
                LabelPoint = p => p.X.ToString()
            }

        };


        public SeriesCollection DiffSeries = new() {
            new StackedRowSeries{
                Values = new ChartValues<float> {0, 0, 0, 0,0,0},
                Title="力差(外-内)",
                StackMode = StackMode.Values,
                DataLabels = true,
                LabelPoint = p => p.X.ToString()
            },
            // new StackedRowSeries{Values = new ChartValues<float> {0, 0, 0, 0,0,0},
            //    StackMode = StackMode.Values,
            //    Title="合力",
            //    DataLabels = true,
            //    LabelPoint = p => p.X.ToString()
            // },

            // new StackedRowSeries
            //{
            //    Values = new ChartValues<float> {0, 0, 0, 0,0,0},
            //    StackMode = StackMode.Values,
            //    Title="内力",
            //    DataLabels = true,
            //    LabelPoint = p => p.X.ToString()

            //},
            //new StackedRowSeries
            //{
            //    Values = new ChartValues<float> {0, 0, 0, 0,0,0},
            //    StackMode = StackMode.Values,
            //    Title="外力",
            //    DataLabels = true,
            //    LabelPoint = p => p.X.ToString()
            //}

        };


        private readonly AxesCollection yAxis = new()
        {
            new Axis
            {
                Foreground= new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0,0,0)),
                Title = "度数",
                Labels = new[] { "0°", "30°", "45°", "60°", "90°", "120°" }
            }
         };

        private readonly AxesCollection xAxis = new()
        {
            new Axis
            {
                Title = "指标",
                Foreground= new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0,0,0)),
                
            }
         };


        public SeriesCollection Series
        {
            get { return AngleSeries; }
        }

        public AxesCollection XAxis
        {
            get { return xAxis; }
        }

        public AxesCollection YAxis
        {
            get { return yAxis; }
        }

        ///////////////////////
       


        public ChartViewModel(bool realTime)
        {
            //力差
            DiffPressure = new LineSeries
            {
                Values = new ChartValues<ObservableValue> {
                    new ObservableValue(0),
                    new ObservableValue(0),
                    new ObservableValue(0),
                    new ObservableValue(0),
                    new ObservableValue(0)
                },
                Title = "力差",
                StrokeThickness = 4,
                PointGeometrySize = 0,
                DataLabels = true
            };

            //合力
            SumPressure = new LineSeries
            {
                Values = new ChartValues<ObservableValue> {
                    new ObservableValue(0),
                    new ObservableValue(0),
                    new ObservableValue(0),
                    new ObservableValue(0),
                    new ObservableValue(0)
                },
                Title = "合力",
                StrokeThickness = 4,
                PointGeometrySize = 0,
                DataLabels = true
            };

            //内力
            InsidePressure = new LineSeries
            {
                Values = new ChartValues<ObservableValue> {
                    new ObservableValue(0),
                    new ObservableValue(0),
                    new ObservableValue(0),
                    new ObservableValue(0),
                    new ObservableValue(0) 
                },
                Title = "内力",
                StrokeThickness = 4,
                PointGeometrySize = 0,
                DataLabels = true,
                Foreground = System.Windows.Media.Brushes.Black
            };
            //外力
            OutsidePressure = new LineSeries
            {
                Values = new ChartValues<ObservableValue> { 
                    new ObservableValue(0),
                    new ObservableValue(0),
                    new ObservableValue(0),
                    new ObservableValue(0),
                    new ObservableValue(0)
                },
                Title = "外力",
                StrokeThickness = 4,
                PointGeometrySize = 0,
                DataLabels = true,
                Foreground = System.Windows.Media.Brushes.Black,
            };
            
            

            RealTimeSeries = new SeriesCollection
            {
                //DiffPressure,
                //SumPressure,
                InsidePressure,
                OutsidePressure
            };
        }
        public LineSeries InsidePressure { get; set; }
        public LineSeries OutsidePressure { get; set; }
        public LineSeries SumPressure { get; set; }
        public LineSeries DiffPressure { get; set; }

        public SeriesCollection? RealTimeSeries { get; set; }

        public void ClearRealTimeData()
        {
            InsidePressure.Values.Clear();
            OutsidePressure.Values.Clear();
            for (var i = 0; i <= 5; i++)
            {
                InsidePressure.Values.Add(new ObservableValue(0));
                OutsidePressure.Values.Add(new ObservableValue(0));
            }

            SumPressure.Values.Clear();
            DiffPressure.Values.Clear();
        }

        public void ClearAngleData()
        {
            foreach(var item in AngleSeries)
            {
                for (int i=0; i<item.Values.Count;i++)
                {
                    item.Values[i] = 0f;
                }
            }
        }

        public void ClearDiffData()
        {
           foreach(var item in DiffSeries)
            {
                for(int i = 0; i < item.Values.Count; i++)
                {
                    item.Values[i] = 0f;
                }
            }
        }
    }
}
