using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureUpper
{
    public class CsvData
    {
        private static Point[] pointArray = new Point[] { new Point(53, 9), new Point(45, 10), new Point(2, 9), new Point(34, 14),
                                                            new Point(11, 9), new Point(2, 4), new Point(15, 15), new Point(9, 3) };
        public enum FootTypes
        {
            Left,
            Right
        }
        public FootTypes footType { get; private set; }
        public List<CsvFrame> frames;
        public int ROWS { get; private set; }
        public int COLS { get; private set; }
        public float SECONDS_PER_FRAME { get; private set; }
        public int START_FRAME { get; private set; }
        public int END_FRAME { get; private set; }

        public CsvFrame NewFrame()
        {
            return new CsvFrame() { datas = new string[ROWS, COLS] };
        }
        public float[] GetFrameSensorValues(int index)
        {
            float[] values = new float[8];
            if (index >= frames.Count) index = frames.Count - 1;
            CsvFrame frame = frames[index];
            if (footType == FootTypes.Right)
            {
                for (int i = 0; i < 8; ++i)
                {
                    values[i] = 0;
                    Point p = pointArray[i];
                    for (int j = 0; j < 5; ++j)
                    {
                        for (int k = 0; k < 5; ++k)
                        {
                            float temp = 0;
                            if (float.TryParse(frame.datas[p.X + j, p.Y + k], out temp))
                            {
                                if (values[i] < temp) values[i] = temp;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < 8; ++i)
                {
                    values[i] = 0;
                    Point p = pointArray[i];
                    for (int j = 0; j < 5; ++j)
                    {
                        for (int k = 0; k < 5; ++k)
                        {
                            float temp = 0;
                            if (float.TryParse(frame.datas[p.X + j, COLS - 1 - p.Y - k], out temp))
                            {
                                if (values[i] < temp) values[i] = temp;
                            }
                        }
                    }
                }
            }
            return values;
        }
        public static CsvData ReadFromFile(string path, FootTypes type)
        {
            CsvData csv = new CsvData();
            csv.footType = type;
            csv.frames = new List<CsvFrame>();
            StreamReader sr = new StreamReader(path, Encoding.Default);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] words = line.Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (words.Length > 0)
                {
                    switch (words[0])
                    {
                        case ("ROWS"):
                            csv.ROWS = int.Parse(words[1]);
                            break;
                        case ("COLS"):
                            csv.COLS = int.Parse(words[1]);
                            break;
                        case ("SECONDS_PER_FRAME"):
                            csv.SECONDS_PER_FRAME = float.Parse(words[1]);
                            break;
                        case ("START_FRAME"):
                            csv.START_FRAME = int.Parse(words[1]);
                            break;
                        case ("END_FRAME"):
                            csv.END_FRAME = int.Parse(words[1]);
                            break;
                        case ("Frame"):
                            CsvFrame frame = csv.NewFrame();
                            frame.id = int.Parse(words[1]);
                            for (int i = 0; i < csv.ROWS; ++i)
                            {
                                words = sr.ReadLine().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                for (int j = 0; j < csv.COLS; ++j)
                                {
                                    frame.datas[i, j] = words[j];
                                }
                            }
                            csv.frames.Add(frame);
                            break;
                        default:
                            break;
                    }
                }
            }
            return csv;
        }
    }
}
