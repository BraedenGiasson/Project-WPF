   M S B A M L   `   `   `  ���� F  BWPF Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPF_ProjectWPF_Project      WPF_Project.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:WPF_Project     -     � Title$  
MainWindow��$	��480��$
��1000�� � WindowStartupLocation$ CenterScreen=� � SizeToContent$ Height=�.��� 
������� � ColumnDefinitions �� $��20 ��� $
��0.5* ��� $��2* ��� $��50 � � RowDefinitions �� $��20 ��� $��35 ��� $��75 ��� $��70 ��� $��70 ��� $��70 ��� $��70 ��� $��50 �.+�o� $��5��$��0,0,0,32q�$��2��.@�m� $��_File��.@�m� -   $
��Save��m� -   $��Save As��m� $��_Help��.@�m� -   $��About Us��c� $��1��$��5��
�������.@��� -   .���� $��/Images/Save_16x.png���� $��Center=�$��1��$��2��$��3��$��1�� �� Orientation$ 
Horizontal=�.+��� -    ��Name$ txtWelcomeName��$��Audi Inventory Tracker ��$��35(�$
��Bold"�$��0,15,0,0q��� $
��Left=�$��8��$��2��.+��� $,��&Select Row and press DEL key to delete��$��14(�$��DemiBold"�$��10q��� $��2��$��2��$��	0,50,20,0q�$��Right=�$ 
Horizontal=�.+��� $��Inventory quantity: ��$
��Bold"�$��13(�$	��130���� -   $ txtQuantityOnScreen��$�� ��$��0,1,0,0q�$��13(�$��25��&   System.Windows.Controls.DataGrid  -     Name$ dgModels��   AutoGenerateColumns$ False��$��2��$��3��$��4��	   CanUserDeleteRows$
	 True��
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 
Model Name��   
IsReadOnly$
 True��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+  $ Colour��$
 True�� �� *Colour+  $ 
Horsepower��$
 True�� �� *
Horsepower+  $ Torque�� �� *Torque+  $ 
# of Seats��$
 True�� �� *NumberOfSeats+  $ Height��$
 True�� �� *Height+  $ Width��$
 True�� �� *Width+  $ Length��$
 True�� �� *Length+  $ Engine��$
 True�� �� *EngineOption+  $ 	Fuel Type��$
 True�� �� *
FuelType+  $ 	Body Type��$
 True�� �� *
BodyType+  $ Quantity�� �� *ModelQuantity+ �� UpdateSourceTrigger$ PropertyChanged=��� -	    � Cursor$
 Hand��$��	Add a car��$��16(�$��DemiBold"�$��3��$��1��$	��120��$��50��$��0,0,15,0q��� -
   $
 Hand��$��	Load Cars��$��16(�$��DemiBold"�$��4��$��1��$	��120��$��50��$��0,0,15,0q��� -   $
 Hand��$��Shopping List��$��16(�$��DemiBold"�$��5��$��1��$	��120��$��50��$��0,0,15,0q�