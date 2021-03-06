﻿using System;
using Xamarin.Forms;

namespace DrawShape
{
	public class ShapeView : BoxView
	{
		public static readonly BindableProperty ShapeTypeProperty = BindableProperty.Create(nameof(ShapeType), typeof(ShapeType), typeof(ShapeView), ShapeType.Box);

		public static readonly BindableProperty StrokeColorProperty = BindableProperty.Create(nameof(StrokeColor), typeof(Color), typeof(ShapeView), Color.Default);

		public static readonly BindableProperty StrokeWidthProperty = BindableProperty.Create(nameof(StrokeWidth), typeof(float), typeof(ShapeView), 1f);

		public static readonly BindableProperty IndicatorPercentageProperty = BindableProperty.Create(nameof(IndicatorPercentage), typeof(float), typeof(ShapeView), 0f);

		public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(ShapeView), 0f);

		public static readonly BindableProperty PaddingProperty = BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(ShapeView), default(Thickness));

        public static readonly BindableProperty RadiusProperty = BindableProperty.Create(nameof(Radius), typeof(int), typeof(ShapeView), 0);

        public ShapeType ShapeType {
			get{ return (ShapeType)GetValue (ShapeTypeProperty); }
			set{ SetValue (ShapeTypeProperty, value); }
		}

		public Color StrokeColor {
			get{ return (Color)GetValue (StrokeColorProperty); }
			set{ SetValue (StrokeColorProperty, value); }
		}

		public float StrokeWidth {
			get{ return (float)GetValue (StrokeWidthProperty); }
			set{ SetValue (StrokeWidthProperty, value); }
		}

		public float IndicatorPercentage {
			get{ return (float)GetValue (IndicatorPercentageProperty); }
			set {
				if (ShapeType != ShapeType.CircleIndicator)
					throw new ArgumentException ("Can only specify this property with CircleIndicator");
				SetValue (IndicatorPercentageProperty, value);
			}
		}

		public float CornerRadius {
			get{ return (float)GetValue (CornerRadiusProperty); }
			set {
				if (ShapeType != ShapeType.Box)
					throw new ArgumentException ("Can only specify this property with Box");
				SetValue (CornerRadiusProperty, value);
			}
		}

		public Thickness Padding {
			get{ return (Thickness)GetValue (PaddingProperty); }
			set{ SetValue (PaddingProperty, value); }
		}

        /// <summary>
        /// Override the automatic radius for Shape type Circle.
        /// </summary>
        public int Radius
        {
            get { return (int)GetValue(RadiusProperty); }
            set
            {
                if (ShapeType != ShapeType.Circle)
                    throw new ArgumentException("Can only specify this property with Circle");
                SetValue(RadiusProperty, value);
            }
        }

        public ShapeView ()
		{
		}
	}

	public enum ShapeType
	{
		Box,
		Circle,
		CircleIndicator
	}
}