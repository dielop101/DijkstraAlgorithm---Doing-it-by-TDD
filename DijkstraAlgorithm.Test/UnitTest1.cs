using DijkstraAlgorithm.Data;
using NUnit.Framework;
using System.Collections.Generic;

namespace DijkstraAlgorithm.Test
{
    public class Tests
    {
        private DijkstraService _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new DijkstraService();
        }

        [Test]
        public void Graph_A_To_B()
        {
            var path1 = new Path("A", 5, "B");

            var request = new List<Path>
            {
                path1
            };

            var result = _sut.CalculateResult(request, "A", "B");

            Assert.AreEqual(result, 5);
        }

        [Test]
        public void Graph_A_To_C()
        {
            var path1 = new Path("A", 5, "B");
            var path2 = new Path("B", 5, "C");

            var request = new List<Path>
            {
                path1,
                path2
            };

            var result = _sut.CalculateResult(request, "A", "C");

            Assert.AreEqual(result, 10);
        }

        [Test]
        public void Graph_A_To_C_With_2_Distinct_Paths()
        {
            var path1 = new Path("A", 5, "B");
            var path2 = new Path("B", 5, "C");
            var path3 = new Path("A", 3, "B2");
            var path4 = new Path("B2", 6, "C");

            var request = new List<Path>
            {
                path1,
                path2,
                path3,
                path4
            };

            var result = _sut.CalculateResult(request, "A", "C");

            Assert.AreEqual(result, 9);
        }

        [Test]
        public void Graph_A_To_C_Bucle()
        {
            var path1 = new Path("A", 5, "B");
            var path2 = new Path("B", 5, "A");
            var path3 = new Path("A", 3, "B2");
            var path4 = new Path("B2", 6, "C");

            var request = new List<Path>
            {
                path1,
                path2,
                path3,
                path4
            };

            var result = _sut.CalculateResult(request, "A", "C");

            Assert.AreEqual(result, 9);
        }

        [Test]
        public void Graph_A_To_C_Bucle_2()
        {
            var path1 = new Path("A", 5, "B");
            var path2 = new Path("B", 0, "D");
            var path3 = new Path("D", 5, "A");
            var path4 = new Path("A", 3, "B2");
            var path5 = new Path("B2", 6, "C");

            var request = new List<Path>
            {
                path1,
                path2,
                path3,
                path4,
                path5
            };

            var result = _sut.CalculateResult(request, "A", "C");

            Assert.AreEqual(result, 9);
        }

        [Test]
        public void Graph_A_To_E_ComplexGraph()
        {
            var path1 = new Path("A", 1, "B");
            var path2 = new Path("B", 1, "C");
            var path3 = new Path("B", 4, "D");
            var path4 = new Path("B", 3, "F");
            var path5 = new Path("C", 2, "D");
            var path6 = new Path("D", 1, "E");
            var path7 = new Path("F", 2, "E");

            var request = new List<Path>
            {
                path1,
                path2,
                path3,
                path4,
                path5,
                path6,
                path7
            };

            var result = _sut.CalculateResult(request, "A", "E");

            Assert.AreEqual(result, 5);
        }

        [Test]
        public void Graph_A_To_E_ComplexGraph2()
        {
            var path1 = new Path("A", 1, "B");
            var path2 = new Path("B", 4, "C");
            var path3 = new Path("B", 1, "D");
            var path4 = new Path("B", 3, "F");
            var path5 = new Path("C", 2, "D");
            var path6 = new Path("D", 1, "E");
            var path7 = new Path("F", 2, "E");

            var request = new List<Path>
            {
                path1,
                path2,
                path3,
                path4,
                path5,
                path6,
                path7
            };

            var result = _sut.CalculateResult(request, "A", "E");

            Assert.AreEqual(result, 3);
        }
    }
}