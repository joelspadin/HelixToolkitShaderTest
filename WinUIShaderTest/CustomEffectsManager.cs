using HelixToolkit.SharpDX.Core.Shaders;
using HelixToolkit.SharpDX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WinUIShaderTest;

public static class CustomShaderNames
{
	public static readonly string Checkerboard = "Checkerboard";
}

public static class ShaderHelper
{
	public static byte[] LoadShaderCode(string path)
	{
		path = Path.Join(AppDomain.CurrentDomain.BaseDirectory, path);

		return File.ReadAllBytes(path);
	}
}

public static class CustomPSShaderDescription
{
	public static readonly ShaderDescription PSCheckerboard = new(
		nameof(PSCheckerboard), ShaderStage.Pixel,
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
			PassDescriptions =
			[
				new ShaderPassDescription(DefaultPassNames.Default)
				{
					ShaderList =
					[
						DefaultVSShaderDescriptions.VSMeshDefault,
						CustomPSShaderDescription.PSCheckerboard,
					],
					BlendStateDescription = DefaultBlendStateDescriptions.BSAlphaBlend,
					DepthStencilStateDescription = DefaultDepthStencilDescriptions.DSSDepthLess,
				}
			]
		};

		AddTechnique(checkerboard);
	}
}

