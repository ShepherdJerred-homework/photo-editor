using System;
using System.Drawing;

namespace photo_editor
{
	class PhotoEditor
	{
		private const int RGB_MAX_VALUE = 255;
		private const int RGB_MIN_VALUE = 0;
		private const int BRIGHTNESS_MAX_VALUE = 100;
		private const int BRIGHTNESS_AVERAGE_VALUE = 50;
		private const int BRIGHTNESS_MIN_VALUE = 0;

		private int transformedBitmapArea;

		public Bitmap TransformedBitmap { get; set; }

		public PhotoEditor(Bitmap transformedBitmap)
		{
			TransformedBitmap = transformedBitmap;
			transformedBitmapArea = calculateTransformedBitmapArea();
		}

		public void InvertColors()
		{
			for (int y = 0; y < TransformedBitmap.Height; y++)
			{
				for (int x = 0; x < TransformedBitmap.Width; x++)
				{
					Color color = TransformedBitmap.GetPixel(x, y);
					int newRed = Math.Abs(color.R - RGB_MAX_VALUE);
					int newGreen = Math.Abs(color.G - RGB_MAX_VALUE);
					int newBlue = Math.Abs(color.B - RGB_MAX_VALUE);

					Color newColor = Color.FromArgb(newRed, newGreen, newBlue);
					TransformedBitmap.SetPixel(x, y, newColor);
				}
			}
		}

		public void TransformByColor(Color transformColor)
		{
			for (int y = 0; y < TransformedBitmap.Height; y++)
			{
				for (int x = 0; x < TransformedBitmap.Width; x++)
				{
					Color newColor = getNewColorForColorTransform(calculateAverageRgbPercentageForPixel(x, y), transformColor);

					TransformedBitmap.SetPixel(x, y, newColor);
				}
			}
		}

		public void ChangeBrightness(int brightness)
		{
			// The minimum value for the brightness is BRIGHTNESS_MIN_VALUE and the maximum value is BRIGHTNESS_MAX_VALUE. Lower values represent darkening the photo, 
			// and higher values represent brightening the photo. BRIGHTNESS_AVERAGE_VALUE represents no change.

			if (brightness < BRIGHTNESS_MIN_VALUE || brightness > BRIGHTNESS_MAX_VALUE)
			{
				throw new ArgumentException("The value for brightness cannot be greater than 100 or less than 0. Current value = " + brightness);
			}

			int amountToSubtractFromRgbValue = calculateAmountToSubtractFromRgbValue(brightness);

			for (int y = 0; y < TransformedBitmap.Height; y++)
			{
				for (int x = 0; x < TransformedBitmap.Width; x++)
				{
					Color newColor = getNewColorForBrightnessTransform(amountToSubtractFromRgbValue, TransformedBitmap.GetPixel(x, y));

					TransformedBitmap.SetPixel(x, y, newColor);
				}
			}
		}

		private Color getNewColorForBrightnessTransform(int amountToSubtractFromRgbValue, Color currentColor)
		{
			return Color.FromArgb(
				subtractBrightnessModifierFromRgbValue(amountToSubtractFromRgbValue, currentColor.R), 
				subtractBrightnessModifierFromRgbValue(amountToSubtractFromRgbValue, currentColor.G), 
				subtractBrightnessModifierFromRgbValue(amountToSubtractFromRgbValue, currentColor.B));
		}

		private Color getNewColorForColorTransform(double averageRgbValueForPixel, Color transformColor)
		{
			return Color.FromArgb(
				(int)(transformColor.R * averageRgbValueForPixel),
				(int)(transformColor.G * averageRgbValueForPixel),
				(int)(transformColor.B * averageRgbValueForPixel));
		}

		private int calculateAmountToSubtractFromRgbValue(int brightness)
		{
			return Convert.ToInt32(2 * (BRIGHTNESS_AVERAGE_VALUE - brightness) * 0.01 * RGB_MAX_VALUE);
		}

		private double calculateAverageRgbPercentageForPixel(int x, int y)
		{
			return calculateAverageRgbValuesForPixel(x, y) / RGB_MAX_VALUE;
		}

		private double calculateAverageRgbValuesForPixel(int x, int y)
		{
			Color color = TransformedBitmap.GetPixel(x, y);
			return (color.R + color.G + color.B) / 3;
		}

		private int calculateTransformedBitmapArea()
		{
			return TransformedBitmap.Height * TransformedBitmap.Width;
		}

		private int subtractBrightnessModifierFromRgbValue(int amountToSubtractFromRgbValue, int rgbValue)
		{
			int result = rgbValue - amountToSubtractFromRgbValue;

			if (result > RGB_MAX_VALUE)
				return RGB_MAX_VALUE;
			else if (result < RGB_MIN_VALUE)
				return RGB_MIN_VALUE;
			else
				return result;
		}
	}
}
