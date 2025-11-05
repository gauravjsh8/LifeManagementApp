namespace LifeManagementApp
{
    public partial class NotePage : ContentPage
    {
        public NotePage(Note note = null)
        {
            InitializeComponent();
            BindingContext = new ViewModels.NoteViewModel(Navigation, note);
        }
    }
}