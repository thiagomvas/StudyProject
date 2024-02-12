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
					return "#F1EAFF";
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
					return "#E5D4FF";
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
					return "#D0A2F7";
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
					return "#303130";
				}
			} 
		}
	}
}
