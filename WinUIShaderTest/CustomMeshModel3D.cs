using HelixToolkit.SharpDX.Core.Model.Scene;
using HelixToolkit.WinUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIShaderTest;

internal class CustomMeshModel3D : MeshGeometryModel3D
{
	protected override SceneNode OnCreateSceneNode()
	{
		var node = base.OnCreateSceneNode();
		node.OnSetRenderTechnique = (host) => { return node.EffectsManager[CustomShaderNames.Checkerboard]; };
		return node;
	}
}
