using HelixToolkit.Wpf.SharpDX;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SharpDX;
using Point3D = System.Windows.Media.Media3D.Point3D;
using Vector3D = System.Windows.Media.Media3D.Vector3D;

namespace WpfShaderTest
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public IEffectsManager EffectsManager { get; } = new CustomEffectsManager();

		public Camera Camera { get; private set; }
		public Geometry3D Geometry1 { get; private set; }
		public Geometry3D Geometry2 { get; private set; }
		public Material Material { get; private set; }

		public MainWindow()
		{
			InitializeComponent();

			Camera = new PerspectiveCamera();

			var builder = new MeshBuilder();
			builder.AddSphere(center: new Vector3(5, 0, -5), radius: 5);
			Geometry1 = builder.ToMeshGeometry3D();

			builder = new MeshBuilder();
			builder.AddSphere(center: new Vector3(-5, 0, 5), radius: 5);
			Geometry2 = builder.ToMeshGeometry3D();

			Material = new DiffuseMaterial
			{
				DiffuseColor = Color4.White,
				EnableUnLit = true,
			};
		}
	}
}