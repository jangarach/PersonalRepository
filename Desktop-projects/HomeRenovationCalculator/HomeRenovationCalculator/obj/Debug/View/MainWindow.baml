   M S B A M L   `   `   `  ����S  OHomeRenovationCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:HomeRenovationCalculatorHomeRenovationCalculator  5   	   M+clr-namespace:HomeRenovationCalculator.ViewHomeRenovationCalculator.View  5   	   W0clr-namespace:HomeRenovationCalculator.ViewModel"HomeRenovationCalculator.ViewModel  5   	   )    #HomeRenovationCalculator.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:HomeRenovationCalculator     5   	   <view+clr-namespace:HomeRenovationCalculator.View     5   	   ?vm0clr-namespace:HomeRenovationCalculator.ViewModel     5   	     � WindowStartupLocation$  CenterScreen=�5
   	    � Title$E ?Расчет стоимости ремонта квартиры��5   	   $	��650��63   $	��800��6@   $	��650��6L    � DataContext 5   	   �� *Main+   Locator �� Source# [   � 	Resources 5        tbxParam �� 
TargetType �� Property �� Value �� DataType0   *HomeRenovationCalculator.ViewModel.FloorVM)   #HomeRenovationCalculator.View.Floor/   )HomeRenovationCalculator.ViewModel.CeilVM(   "HomeRenovationCalculator.View.Ceil/   )HomeRenovationCalculator.ViewModel.WallVM(   "HomeRenovationCalculator.View.Wall��%}  &	       (�� �     5      *, +)(�� �     5      *, +)(�� �     5      *, +)�� 5   
   " ��6!   .�5      ��  � ��$ 2q�6'   �� 5       � ��$	 150��6&   �� 5       � ��$
 Left=�64   5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      5      .��5      � 	 � RowDefinitions	 5   
   �� 5       $
��auto �6   �� 5!      $
��auto �6   �� 5"      .+�5$   
   o� $��0��6   .@�5%      m� $��Файл��6   $
��Left=�6%   .@�5&      m� $��
Выход��6   
 m� Command
 6*   �� *CommandExit+5'      m� 5(      $��Настройки��6   $
��Left=�6*   .@�5)      m� $%��Настройка данных��6   
 65   �� *CommandSettingDatas+5*      5+      � 5,   
   $��1��6   $	��100��6    � ColumnDefinitions 5-      �� 5.      �� 5/      51      �� 52   
   $��1��6   $$��Общие параметры:��6    $��2q�6:   .��53      �  54      �� 55      $	��150 �6'   �� 56      �� 57      $	��150 �6'   �� 58      	 5:      �� 5;      $
��auto �6$   �� 5<      $
��auto �6$   .+�5>      �� $��0��6   $��0��6)   $��2q�69   $!��Высота стен [м]:��6D   �� 5?      $��0��6   $��1��6'   #��[ 67   ��6Y   �� *RoomParameters.WallHeight+ �� ValidatesOnDataErrors . �� 5@      $��1��6   $��0��6)   $��2q�69   $!��Ширина стен [м]:��6D   �� 5A      $��1��6   $��1��6'   #��[ 67   ��6Y   �� *RoomParameters.WallLength+ . �� 5C      $��0��6   $��2��6)   $��2q�69   �� 5D      $'�!Площадь потолка [м��6    �� 5E      $�2��6    K� Variants$ Superscript=�6#    �� 5F      $�]:��6   5G      �� 5H      $��0��6   $��3��6'   #��[ 67   ��6Y   �� *RoomParameters.CeilingArea+ . �� 5I      $��1��6   $��2��6)   $��2q�69   �� 5J      $!�Площадь пола [м��6    �� 5K      $�2��6   $ Superscript=�6#    �� 5L      $�]:��6   5M      �� 5N      $��1��6   $��3��6'   #��[ 67   ��6Y   �� *RoomParameters.FloorArea+ . 5O      5P      � 5Q   
   $��2��6    5R      �� 5S      $
��0.5* �6#   $	��200��60   �� 5T      .+�5V      �� $��0��6   $��0��6&   ���	#FFEEEEEE.+�5W      �� $8��2Расчет напольного покрытия��6   $��14(�6>   $��FloorVm��6z   ��6L   �� *CommandChangeNavigationVM+6z   �� 5X      $��14(�6   $��	CeilingVm��6U   ��6'   �� *CommandChangeNavigationVM+.��5Y      �� $Q��KРасчет штукатурки и шпаклевки на потолок��6    $
��Wrap=�6P   5Z      �� 5[      $��14(�6   $��WallVm��6U   ��6'   �� *CommandChangeNavigationVM+.��5\      �� $M��GРасчет штукатурки и шпаклевки на стену��6    $
��Wrap=�6N   5]      5^      �� 5_      $��0��6   $��1��6*   $��2q�6:   $��Visible=�6j   ��6E   �� *NavigationBaseVM+6j   5`      5a      5b      