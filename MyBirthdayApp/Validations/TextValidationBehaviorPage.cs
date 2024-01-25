using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Markup;

namespace MyBirthdayApp.Validations
{
    public class TextValidationBehaviorPage : ContentPage
    {
        public TextValidationBehaviorPage()
        {
            Content = new Entry()
                .Behaviors(new TextValidationBehavior
                {
                    InvalidStyle = new Style<Entry>(Entry.TextColorProperty, Colors.Red),
                    ValidStyle = new Style<Entry>(Entry.TextColorProperty, Colors.Green),
                    Flags = ValidationFlags.ValidateOnValueChanged,
                    MinimumLength = 1,
                    MaximumLength = 10,
                    
                });
        }
    }
}
