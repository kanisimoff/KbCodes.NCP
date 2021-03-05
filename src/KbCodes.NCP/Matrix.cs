namespace KbCodes.NCP
{
    /// <summary>
    /// Defining a matrix
    /// </summary>
    /// <typeparam name="T">Type of matrix elements</typeparam>
    public struct Matrix<T> where T : struct
    {
        private readonly T[,] _matrix;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="matrix"></param>
        public Matrix(T[,] matrix)
        {
            _matrix = matrix;
        }

        /// <summary>
        /// Rows count of matrix
        /// </summary>
        public int Rows => _matrix.GetLength(0);

        /// <summary>
        /// Columns count of matrix
        /// </summary>
        public int Cols => _matrix.GetLength(1);

        /// <summary>
        /// Array representation of a matrix
        /// </summary>
        public T[,] Value => _matrix;
    }
}
