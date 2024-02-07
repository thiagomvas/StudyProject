namespace StudyProject.Presentation
{
	public class Theme
	{
		private static Theme instance;
		public bool DarkMode = true;

		private Theme()
		{
			// Private constructor to prevent instantiation
		}

		public static Theme Default
		{
			get
			{
				if (instance == null)
				{
					instance = new Theme();
				}
				return instance;
			}
		}

		public string BackgroundColor { 
			get
			{
				if(DarkMode)
				{
					return "#25252D";
				}
				else
				{
					return "#393646";
				}
			} 
		}

		public string ForegroundColor
		{
			get
			{
				if(DarkMode)
				{
					return "#30303C";
				}
				else
				{
					return "#4F4557";
				}
			} 
		}

		public string PrimaryColor
		{
			get
			{
				if(DarkMode)
				{
					return "#363646";
				}
				else
				{
					return "#6D5D6E";
				}
			} 
		}

		public string TextColor
		{
			get
			{
				if(DarkMode)
				{
					return "#EEEEEE";
				}
				else
				{
					return "#222222";
				}
			} 
		}
	}
}
