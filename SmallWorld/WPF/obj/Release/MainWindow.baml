   M S B A M L   `   `   `  ���� >  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFWPF      WPF.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     !wpfclr-namespace:WPF     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � WindowStartupLocation$  CenterScreen=� � Title$ 
SmallWorld��$	��400��$	��300������  �� ImageSource$. (pack://application:,,,/Resources/sw2.jpg�� � 	Resources   WPF.NegatingConverter   NegatingConverter0  *WPF.SelectedIndexToTextLabelColorConverter * &SelectedIndexToTextLabelColorConverter��%   &	        &	          .��� $
��auto��$��Center=�$��Center=� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � � ColumnDefinitions �� $	��250 �.+��� -    ��Name$ StartUpButton��$��40q�$��Lancer Partie��$��Bottom=�$	��120�� �� IsCancel . $��24��$��3��$��0���� -   $ ChargerButton��$��5q�$��Charger Partie...��$��Bottom=�$	��120�� . $��24��$��4��$��0���� -    ��Name$ GameTypeComboBox��$��Center=�$	��Top=�$	��150��$��10q�$��0��$��0��.@��� -   	 ��Name$	 DemoItem��
 �� 
IsSelected
 . $��Carte Demo (5x5)���� -   $	 	SmallItem��$��Petite Carte (10x10)���� -   $	 
NormalItem��$��Carte Normale (15x15)���� $��10q�$��Center=�$��Center=�$��1��$��0��.+��� -    ��Name$ labelPlayer1��$��10q�$��24��$��Center=�$��Center=�$��Center=�$	��150��$��Joueur 1���� -   $ ComboBoxNationPlayer1��$��Center=�$��Bottom=�$	��150��.@��� -	   $	 Gaul1��$��Gaulois��{��� *
IsSelected+ �� 	Converter# [   �� ElementName$ Gaul2�� �� Mode$ OneWay=��� -
   $	 Nain1��$��Nains��{��� *
IsSelected+# [  $ Nain2��$ OneWay=��� -   $	 Viking1��$��Vikings��{��� *
IsSelected+# [  $ Viking2��$ OneWay=��� $��10q�$��Center=�$��Center=�$��2��$��0��.+��� -   $ labelPlayer2��$��10q�$��24��$��Center=�$��Center=�$��Center=�$	��150��$��Joueur 2���� -   $ ComboBoxNationPlayer2��$��Center=�$��Bottom=�$	��150��.@��� -   $	 Gaul2��$��Gaulois��{��� *
IsSelected+# [  $ Gaul1��$ OneWay=��� -   $	 Nain2��$��Nains��{��� *
IsSelected+# [  $ Nain1��$ OneWay=��� -   $	 Viking2��$��Vikings��{��� *
IsSelected+# [  $ Viking1��$ OneWay=�