   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFWPF  5   	       WPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   !wpfclr-namespace:WPF     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ 
SmallWorld��5   	   $	��400��6   $	��300��6)   ��5	      �� 5
   
    �� ImageSource$. (pack://application:,,,/Resources/sw2.jpg��6    � 	Resources 5        WPF.NegatingConverter   NegatingConverter0  *WPF.SelectedIndexToTextLabelColorConverter * &SelectedIndexToTextLabelColorConverter��%:   &	        &	        5   
   6      5   
   65   5      .��5      � $
��auto��6   $��Center=�6   $��Center=�66    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $	��250 �6   .+�5   
   �� -   5         ��Name$ StartUpButton��5      $��40q�6   $��Lancer Partie��64   $��Bottom=�6M   $	��120��6h    �� IsCancel . $��24��6�   $��3��6�   $��0��6�   �� 5   
   -   5        $ ChargerButton��5      $��5q�6   $��Charger Partie...��63   $��Bottom=�6P   $	��120��6k    . $��24��6�   $��4��6�   $��0��6�   �� 5    
   -   5         ��Name$ GameTypeComboBox��5       $��Center=�6-   $	��Top=�6J   $	��150��6b   $��10q�6n   $��0��6{   $��0��6�   .@�5!      �� -   5        	 ��Name$	 DemoItem��5!      
 �� 
IsSelected
 . $��Carte Demo (5x5)��6?   6Z   �� 5"      -   5        $	 	SmallItem��5"      $��Petite Carte (10x10)��6.   6M   �� 5#      -   5        $	 
NormalItem��5#      $��Carte Normale (15x15)��6/   6O   5$      �� 5&   
   $��10q�6   $��Center=�6!   $��Center=�6>   $��1��6Y   $��0��6f   .+�5'      �� -   5         ��Name$ labelPlayer1��5'   �   $��10q�6   $��24��6"   $��Center=�6.   $��Center=�6P   $��Center=�6m   $	��150��6�   $��Joueur 1��6�   6  �� 5(      -   5        $ ComboBoxNationPlayer1��5(      $��Center=�66   $��Bottom=�6S   $	��150��6n   .@�5)      �� -	   5        $	 Gaul1��5)      $��Gaulois��6�   {�6.   �� *
IsSelected+ �� 	Converter# [   �� ElementName$ Gaul2�� �� Mode$ OneWay=�6�   �� 5*      -
   5        $	 Nain1��5*      $��Nains��6�   {�6.   �� *
IsSelected+# [  $ Nain2��$ OneWay=�6�   �� 5+      -   5        $	 Viking1��5+      $��Vikings��6�   {�60   �� *
IsSelected+# [  $ Viking2��$ OneWay=�6�   5,      5-      �� 5/   
   $��10q�6   $��Center=�6!   $��Center=�6>   $��2��6Y   $��0��6f   .+�50      �� -   5        $ labelPlayer2��50   �   $��10q�6   $��24��6"   $��Center=�6.   $��Center=�6P   $��Center=�6m   $	��150��6�   $��Joueur 2��6�   6  �� 51      -   5        $ ComboBoxNationPlayer2��51      $��Center=�66   $��Bottom=�6S   $	��150��6n   .@�52      �� -   5        $	 Gaul2��52      $��Gaulois��6�   {�6.   �� *
IsSelected+# [  $ Gaul1��$ OneWay=�6�   �� 53      -   5        $	 Nain2��53      $��Nains��6�   {�6.   �� *
IsSelected+# [  $ Nain1��$ OneWay=�6�   �� 54      -   5        $	 Viking2��54      $��Vikings��6�   {�60   �� *
IsSelected+# [  $ Viking1��$ OneWay=�6�   55      56      58      59      