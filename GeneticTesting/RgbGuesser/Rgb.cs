namespace RgbGuesser
{
	class Rgb
	{
		internal int R { get; set; }
		internal int G { get; set; }
		internal int B { get; set; }

		public override string ToString()
		{
			return string.Format("({0}, {1}, {2})", R, G, B);
		}
	}
}