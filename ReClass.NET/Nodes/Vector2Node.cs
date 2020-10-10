using System.Drawing;
using System.Runtime.InteropServices;
using ReClassNET.Controls;
using ReClassNET.UI;

namespace ReClassNET.Nodes
{
	public class Vector2Node : BaseMatrixNode
	{
		[StructLayout(LayoutKind.Explicit)]
		private readonly struct Vector2Data
		{
			[FieldOffset(0)]
			public readonly float X;
			[FieldOffset(4)]
			public readonly float Y;
		}

		public override int ValueTypeSize => sizeof(float);

		public override int MemorySize => 2 * ValueTypeSize;

		public override void GetUserInterfaceInfo(out string name, out Image icon)
		{
			name = "Vector2";
			icon = Properties.Resources.B16x16_Button_Vector_2;
		}

		public override Size Draw(DrawContext context, int x2, int y2)
		{
			return DrawVectorType(context, x2, y2, "Vector2", (ref int x, ref int y) =>
			{
				var value = context.Memory.ReadObject<Vector2Data>(Offset);

				x = AddText(context, x, y, context.Settings.NameColor, HotSpot.NoneId, "(");
				x = AddText(context, x, y, context.Settings.ValueColor, 0, $"{value.X:0.000}");
				x = AddText(context, x, y, context.Settings.NameColor, HotSpot.NoneId, ",");
				x = AddText(context, x, y, context.Settings.ValueColor, 1, $"{value.Y:0.000}");
				x = AddText(context, x, y, context.Settings.NameColor, HotSpot.NoneId, ")");
			});
		}

		protected override int CalculateValuesHeight(DrawContext view)
		{
			return 0;
		}

		public override void Update(HotSpot spot)
		{
			base.Update(spot);

			Update(spot, 2);
		}
	}
}
