using System;

namespace AvImage.AverageCalculation
{
    public class SimpleAverageCalculator
    {
        private byte[] rgbValues;
        public byte[] Average { get; }
        public SimpleAverageCalculator(byte[] rgbValues)
        {
            this.rgbValues = rgbValues;
            Average = new byte[3];

            CalculateAverage();
            PrintAverage();
        }

        private void PrintAverage()
        {
            Console.WriteLine("Average RGB:");
            foreach (var av in Average)
            {
                Console.Write(av+" ");
            }
            Console.WriteLine();
        }

        private void CalculateAverage()
        {
            int rTotal = 0, gTotal = 0, bTotal = 0;
            for (int i=0;i<rgbValues.Length;i+=3)
            {
                rTotal += rgbValues[i];
                gTotal += rgbValues[i + 1];
                bTotal += rgbValues[i + 2];
            }
            var pixelCount = (rgbValues.Length / 3);
            Average[0] = (byte)(rTotal / pixelCount);
            Average[1] = (byte)(gTotal / pixelCount);
            Average[2] = (byte)(bTotal / pixelCount);
        }
    }
}
