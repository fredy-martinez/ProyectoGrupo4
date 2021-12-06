using ProyectoGrupo4.Controladores;
using System.Windows.Forms;

namespace ProyectoGrupo4.Vistas
{
    public partial class LoginView : Form
    {
        public LoginView()
        {
            InitializeComponent();
            LoginController controlador = new LoginController(this);
        }
    }
}
