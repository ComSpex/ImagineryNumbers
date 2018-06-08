using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Graphy {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow:Window {
		Point origin;
		double wide, high;
		bool initialState = true;
		int index = 0;
		Point[] leftuppers;
		private void box_MouseDown(object sender,MouseButtonEventArgs e) {
			if(leftuppers==null) {
				MessageBox.Show("First, make the window resized!!",this.Title,button:MessageBoxButton.OK,icon:MessageBoxImage.Information);
				return;
			}
			Point leftupper = leftuppers[index];
			Canvas.SetTop(box,leftupper.Y);
			Canvas.SetLeft(box,leftupper.X);
			if(++index>=leftuppers.Length) {
				index=0;
			}
		}
		public MainWindow() {
			InitializeComponent();
			this.SizeChanged+=(sender,e) => {
				double a_width = e.NewSize.Width;
				double aheight = e.NewSize.Height;
				Debug.Assert(a_width==ActualWidth);
				Debug.Assert(aheight==ActualHeight);
				wide = a_width-2*SystemParameters.ResizeFrameVerticalBorderWidth;
				high = aheight-2*SystemParameters.ResizeFrameHorizontalBorderHeight-SystemParameters.CaptionHeight;
				origin = new Point(wide/2-6,high/2-6);
				Lx.X2=wide;
				Lx.Y1=Lx.Y2=origin.Y;
				Ly.Y2=high;
				Ly.X1=Ly.X2=origin.X;
				if(!initialState) {
					box.Width=wide/2;
					box.Height=high/2;
					leftuppers =new Point[]{new Point(0,0),new Point(origin.X,0),new Point(0,origin.Y),new Point(origin.X,origin.Y) };
				}
				initialState=false;
			};
			for(int i = 0;i<MainGrid.Children.Count;++i) {
				UIElement elem = MainGrid.Children[i];
				Debug.WriteLine(elem.ToString());
				if(elem is System.Windows.Controls.TextBlock) {
					TextBlock co = elem as TextBlock;
					if(co.Name.Contains("Tx")) {
						//MainGrid.Children.Remove(elem);
						co.Visibility=Visibility.Hidden;
					}
				}
			}
		}
	}
}
