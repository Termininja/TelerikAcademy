﻿namespace Matrix.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The tests for class <see cref="Matrix"/>.
    /// </summary>
    [TestClass]
    public class Test_Matrix
    {
        /// <summary>
        /// The matrix with size 1.
        /// </summary>
        private const string MatrixWithSize1 = "  1\r\n";

        /// <summary>
        /// The matrix with size 2.
        /// </summary>
        private const string MatrixWithSize2 = "  1  4\r\n  3  2\r\n";

        /// <summary>
        /// The matrix with size 3.
        /// </summary>
        private const string MatrixWithSize3 = "  1  7  8\r\n  6  2  9\r\n  5  4  3\r\n";

        /// <summary>
        /// The matrix with size 4.
        /// </summary>
        private const string MatrixWithSize4 = "  1 10 11 12\r\n  9  2 15 13\r\n  8 16  3 14\r\n  7  6  5  4\r\n";

        /// <summary>
        /// The matrix with size 10.
        /// </summary>
        private const string MatrixWithSize10 =
            "  1 28 29 30 31 32 33 34 35 36\r\n 27  2 51 52 53 54 55 56 57 37\r\n 26 73  3 50 66 67 68 69 58 38\r\n 25 90 74  4 49 65 72 70 59 39\r\n 24 89 91 75  5 48 64 71 60 40\r\n 23 88 99 92 76  6 47 63 61 41\r\n 22 87 98100 93 77  7 46 62 42\r\n 21 86 97 96 95 94 78  8 45 43\r\n 20 85 84 83 82 81 80 79  9 44\r\n 19 18 17 16 15 14 13 12 11 10\r\n";

        /// <summary>
        /// The test matrix with size 0 should throw Exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMatrixWithSize0ShouldThrowException()
        {
            var m = new Matrix(0);
        }

        /// <summary>
        /// The test matrix with size 1 should return correct result.
        /// </summary>
        [TestMethod]
        public void TestMatrixWithSize1ShouldReturnCorrectResult()
        {
            var matrix = new Matrix(1);
            Assert.AreEqual(matrix.ToString(), MatrixWithSize1);
        }

        /// <summary>
        /// The test matrix with size 2 should return correct result.
        /// </summary>
        [TestMethod]
        public void TestMatrixWithSize2ShouldReturnCorrectResult()
        {
            var matrix = new Matrix(2);
            Assert.AreEqual(matrix.ToString(), MatrixWithSize2);
        }

        /// <summary>
        /// The test matrix with size 3 should return correct result.
        /// </summary>
        [TestMethod]
        public void TestMatrixWithSize3ShouldReturnCorrectResult()
        {
            var matrix = new Matrix(3);
            Assert.AreEqual(matrix.ToString(), MatrixWithSize3);
        }

        /// <summary>
        /// The test matrix with size 4 should return correct result.
        /// </summary>
        [TestMethod]
        public void TestMatrixWithSize4ShouldReturnCorrectResult()
        {
            var matrix = new Matrix(4);
            Assert.AreEqual(matrix.ToString(), MatrixWithSize4);
        }

        /// <summary>
        /// The test matrix with size 10 should return correct result.
        /// </summary>
        [TestMethod]
        public void TestMatrixWithSize10ShouldReturnCorrectResult()
        {
            var matrix = new Matrix(10);
            Assert.AreEqual(matrix.ToString(), MatrixWithSize10);
        }
    }
}