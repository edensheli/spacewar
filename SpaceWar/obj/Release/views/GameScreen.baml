   M S B A M L   `   `   `  ���� C  ?SpaceWar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SpaceWar.viewsSpaceWar.views      SpaceWar.views.GameScreen   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:SpaceWar.views     -     � Title$  
GameScreen��$	��600��$	��900�� � WindowState$ 	Maximized=� � WindowStyle$
 None=�����  �� ImageSource$/ )/SpaceWar;component/images/Background.png��.���  � ColumnDefinitions �� �� ��  � RowDefinitions �� �� .+��� $��0��$��20q�.+��� -    ��Name$ liveText��$
��live��   text#��[  $
��Left=��� -   $ shipLvelText��$��
ship level��#��[  $
��Left=��� -   $ 	levelText��$
��0,20q�$��level��#��[  $��1��$��Center=�$��60(��� -   $ 
enemeyText��$��20q�$��
enemyCount��#��[  $��2��$��Right=��� -    ��Name$ 	gameBoard��$��3��$��3��|�. .+��� -    ��Name$ 	attackPrg��	 �� Left$	 20��

 �� Top$	
 100��$��0��$��40�� �� RadiusX$ 10�� �� RadiusY$ 10��
������� J� Opacity$	 0.5Q�$
��Left=�$	��Top=��� $	 20��$	
 100��$	��130��$��40��$ 10��$ 10��
������ 
�������$��2��$
��Left=�$��Center=�