using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Exam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TableRecords), typeof(TableRecords));
        }
    }
}