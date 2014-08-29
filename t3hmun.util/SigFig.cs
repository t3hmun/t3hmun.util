namespace t3hmun.util
{
    using System;

    public static class SigFig
    {
        /// <summary>Rounds by significant figures.</summary>
        /// <param name="num">The number to round.</param>
        /// <param name="sigFigs">The number of significant figures.</param>
        /// <returns>The number rounded to significant figures.</returns>
        public static double Round(double num, int sigFigs)
        {
            if (sigFigs < 1)
                throw new ArgumentOutOfRangeException("sigFigs", "Less than 1 significant figures is invalid.");

            //Prevents NaN in calculation.
            if (num == 0)
                return 0;

            //digits will be 1 smaller for numbers that are powers of ten, but it doesn't affect the result.
            double digits = Math.Ceiling(Math.Log10(num < 0 ? -num : num));
            double power = sigFigs - digits;

            double magCoef = Math.Pow(10, power);
            double rounded = Math.Round(magCoef*num);
            return rounded/magCoef;
        }

        /// <summary>Rounds up with specified number of significant figures.</summary>
        /// <param name="num">The number to round up.</param>
        /// <param name="sigFigs">The number of significant figures.</param>
        /// <returns>A number rounded up to the specified significantt figures.</returns>
        public static double RoundUp(double num, int sigFigs)
        {
            if (sigFigs < 1)
                throw new ArgumentOutOfRangeException("sigFigs", "Less than 1 significant figures is invalid.");

            //Prevents NaN in calculation.
            if (num == 0)
                return 0;

            double digits = Math.Ceiling(Math.Log10(num < 0 ? -num : num));
            double power = sigFigs - digits;

            double magCoef = Math.Pow(10, power);
            double rounded = Math.Ceiling(magCoef*num);
            return rounded/magCoef;
        }

        /// <summary>Rounds down with specified number of significant figures.</summary>
        /// <param name="num">The number to round down.</param>
        /// <param name="sigFigs">The number of significant figures.</param>
        /// <returns>A number rounded down to the specified significantt figures.</returns>
        public static double RoundDown(double num, int sigFigs)
        {
            if (sigFigs < 1)
                throw new ArgumentOutOfRangeException("sigFigs", "Less than 1 significant figures is invalid.");

            //Prevents NaN in calculation.
            if (num == 0)
                return 0;

            double digits = Math.Ceiling(Math.Log10(num < 0 ? -num : num));
            double power = sigFigs - digits;

            double magCoef = Math.Pow(10, power);
            double rounded = Math.Floor(magCoef*num);
            return rounded/magCoef;
        }
    }
}