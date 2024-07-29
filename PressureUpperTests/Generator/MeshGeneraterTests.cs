using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressureUpper.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureUpper.Generator.Tests
{
    [TestClass()]
    public class MeshGeneraterTests
    {
        [TestMethod()]
        public void GenerateMeshTest()
        {
            MeshGenerater.GenerateMesh();
        }
    }
}