   M S B A M L   `   `   `  ���� F  BWPF Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPF_ProjectWPF_Project      WPF_Project.ModelWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:WPF_Project       � Title$  ModelWindow��$	��450��$	��800�� � WindowStartupLocation$ CenterScreen=� � SizeToContent$ Height=�.��� .+�&   System.Windows.Controls.DataGrid  -     Name$ dgModels��   AutoGenerateColumns$ False��$��2��$��3��$��4��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 
Model Name��   
IsReadOnly$
 True��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+  $ Colour��$
 True�� �� *Colour+  $ 
Horsepower��$
 True�� �� *
Horsepower+  $ Torque�� �� *Torque+  $ 
# of Seats��$
 True�� �� *NumberOfSeats+  $ Height��$
 True�� �� *Height+  $ Width��$
 True�� �� *Width+  $ Length��$
 True�� �� *Length+  $ Engine��$
 True�� �� *EngineOption+  $ 	Fuel Type��$
 True�� �� *
FuelType+  $ 	Body Type��$
 True�� �� *
BodyType+  $ Quantity�� �� *ModelQuantity+	 �� UpdateSourceTrigger$	 PropertyChanged=�