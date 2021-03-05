using System;

namespace KbCodes.NCP
{
    public static class ErrorComputation
    {
        /// <summary>
        /// Compute absolute error
        /// </summary>
        /// <typeparam name="TOut">Relative error return type</typeparam>
        /// <param name="xe">Exact true value</param>
        /// <param name="xa">Approximate value</param>
        /// <returns>Absolute error</returns>
        public static TOut Ea<TOut>(dynamic xe, dynamic xa) => Math.Abs(xe - xa);

        /// <summary>
        /// Compute relative error
        /// </summary>
        /// <typeparam name="TOut">Relative error return type</typeparam>
        /// <param name="xe">Exact true value</param>
        /// <param name="xa">Approximate value</param>
        /// <returns>Relative error</returns>
        public static TOut Er<TOut>(dynamic xe, dynamic xa)
        {
            if (typeof(TOut) == typeof(decimal))
            {
                var decimalXe = (dynamic)(decimal)Convert.ChangeType(xe, typeof(decimal));
                return Math.Abs((decimalXe - xa) / decimalXe);
            }

            if (typeof(TOut) == typeof(double))
            {
                var doubleXe = (dynamic)(double)Convert.ChangeType(xe, typeof(double));
                return Math.Abs((doubleXe - xa) / doubleXe);
            }

            var dynamicXe = (dynamic)(float)Convert.ChangeType(xe, typeof(float));
            return (TOut)Convert.ChangeType(Math.Abs((dynamicXe - xa) / dynamicXe), typeof(TOut));
        }

        /// <summary>
        /// Compute percentage relative error
        /// </summary>
        /// <typeparam name="TOut">Percentage relative error return type</typeparam>
        /// <param name="xe">Exact true value</param>
        /// <param name="xa">Approximate value</param>
        /// <returns>Percentage relative error</returns>
        public static TOut Ep<TOut>(dynamic xe, dynamic xa)
        {
            if (typeof(TOut) == typeof(decimal))
            {
                return Er<decimal>(xe, xa) * 100;
            }

            if (typeof(TOut) == typeof(double))
            {
                return Er<double>(xe, xa) * 100;
            }
            return (TOut)Convert.ChangeType(Er<float>(xe, xa) * 100, typeof(TOut));
        }

        /// <summary>
        /// Compute approximation quality
        /// </summary>
        /// <typeparam name="TOut">Approximation quality return type</typeparam>
        /// <param name="xe">Exact true value</param>
        /// <param name="xa">Approximate value</param>
        /// <returns>Approximation quality</returns>
        public static TOut ApproxQuality<TOut>(dynamic xe, dynamic xa)
        {
            if (typeof(TOut) == typeof(decimal))
            {
                var decimalXe = (dynamic)(decimal)Convert.ChangeType(xe, typeof(decimal));
                return Math.Abs(decimalXe - xa) / (1+ Math.Abs(decimalXe));
            }

            if (typeof(TOut) == typeof(double))
            {
                var doubleXe = (dynamic)(double)Convert.ChangeType(xe, typeof(double));
                return Math.Abs(doubleXe - xa) / (1 + Math.Abs(doubleXe));
            }

            var dynamicXe = (dynamic)(float)Convert.ChangeType(xe, typeof(float));
            return (TOut)Convert.ChangeType(Math.Abs(dynamicXe - xa) / (1 + Math.Abs(dynamicXe)), typeof(TOut));
        }
    }
}
