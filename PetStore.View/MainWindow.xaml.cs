using PetStore.ViewModel;
using PetStore.ViewModel.Repository;

namespace PetStore.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent(); 
            const string connectionString = "Server=localhost\\SQLEXPRESS;Database=PetStore;Trusted_Connection=True;TrustServerCertificate=True";
            IDataRepository repository = new DataRepository(connectionString);
            DataContext = new MainViewModel(repository);
        }
    }
}