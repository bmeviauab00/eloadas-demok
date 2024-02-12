using Microsoft.UI.Xaml.Data;
using System;

namespace DataBindingSample
{
	public class StringIsEmptyConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
			=> !string.IsNullOrWhiteSpace(value as string);

		public object ConvertBack(object value, Type targetType, object parameter, string language)
			=> throw new NotImplementedException();
	}
}
