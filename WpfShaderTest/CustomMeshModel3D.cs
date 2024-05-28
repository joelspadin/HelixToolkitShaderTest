using HelixToolkit.Wpf.SharpDX;
using HelixToolkit.Wpf.SharpDX.Model.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfShaderTest;

internal class CustomMeshModel3D : MeshGeometryModel3D
{
	protected override SceneNode OnCreateSceneNode()
	{
		var node = base.OnCreateSceneNode();
		node.OnSetRenderTechnique = (host) => { return node.EffectsManager[CustomShaderNames.Checkerboard]; };
		return node;
	}
}
