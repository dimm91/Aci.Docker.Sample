using Web.Client.Ui.Services;

namespace Web.Client.Ui.Models
{
    public class HomeViewModel
    {
        public IEnumerable<User> Users { get; set; } = default!;
        public IEnumerable<Product> Products { get; set; } = default!;
    }
}
