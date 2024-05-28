using HelixToolkit.SharpDX.Core;
using HelixToolkit.WinUI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SharpDX;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIShaderTest
{
	/// <summary>
	/// An empty window that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainWindow : Window
	{
		public IEffectsManager EffectsManager { get; } = new CustomEffectsManager();

		public Camera Camera { get; private set; }
		public Geometry3D Geometry1 { get; private set; }
		public Geometry3D Geometry2 { get; private set; }
		public Material Material { get; private set; }

		public MainWindow()
		{
			this.InitializeComponent();

			Camera = new PerspectiveCamera();

			var builder = new MeshBuilder();
			builder.AddSphere(center: new Vector3(2, 0, -2), radius: 2);
			Geometry1 = builder.ToMeshGeometry3D();

			builder = new MeshBuilder();
			builder.AddSphere(center: new Vector3(-2, 0, 2), radius: 2);
			Geometry2 = builder.ToMeshGeometry3D();

			Material = new DiffuseMaterial
			{
				DiffuseColor = Color.White,
			};
		}
	}
}
