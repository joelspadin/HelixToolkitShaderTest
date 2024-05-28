using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HelixToolkit.Wpf.SharpDX.Shaders;
using HelixToolkit.Wpf.SharpDX;

namespace WpfFrameworkShaderTest
{
	public static class CustomShaderNames
	{
		public static readonly string Checkerboard = "Checkerboard";
	}

	public static class ShaderHelper
	{
		public static byte[] LoadShaderCode(string path)
		{
			path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

			return File.ReadAllBytes(path);
		}
	}

	public static class CustomPSShaderDescription
	{
		public static readonly ShaderDescription PSCheckerboard = new ShaderDescription(nameof(PSCheckerboard), ShaderStage.Pixel,
			new ShaderReflector(), ShaderHelper.LoadShaderCode("Shaders/psCheckerboard.cso"));
	}

	public class CustomEffectsManager : DefaultEffectsManager
	{
		public CustomEffectsManager()
		{
			LoadCustomTechniqueDescription();
		}

		private void LoadCustomTechniqueDescription()
		{
			var checkerboard = new TechniqueDescription(CustomShaderNames.Checkerboard)
			{
				InputLayoutDescription = new InputLayoutDescription(DefaultVSShaderByteCodes.VSMeshDefault, DefaultInputLayout.VSInput),
				PassDescriptions = new[]
				{
					new ShaderPassDescription(DefaultPassNames.Default)
					{
						ShaderList = new[]
						{
							DefaultVSShaderDescriptions.VSMeshDefault,
							CustomPSShaderDescription.PSCheckerboard,
						},
						BlendStateDescription = DefaultBlendStateDescriptions.BSAlphaBlend,
						DepthStencilStateDescription = DefaultDepthStencilDescriptions.DSSDepthLess,
					}
				}
			};

			AddTechnique(checkerboard);
		}
	}
}