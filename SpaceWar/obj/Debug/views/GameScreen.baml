   M S B A M L   `   `   `  ����C  ?SpaceWar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SpaceWar.viewsSpaceWar.views  5   	       SpaceWar.views.GameScreen   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SpaceWar.views     5   	   -   5          � Title$  
GameScreen��5   	   $	��600��6   $	��900��6)    � WindowState$ 	Maximized=�65    � WindowStyle$
 None=�6M   ��5	      �� 5
   
    �� ImageSource$/ )/SpaceWar;component/images/Background.png��6   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��0��6   $��20q�6%   .+�5      �� -   5         ��Name$ liveText��5      $
��live��6,      text#��[  68   $
��Left=�6V   �� 5      -   5        $ shipLvelText��5      $��
ship level��60   #��[  6B   $
��Left=�6`   5      �� 5   
   -   5        $ 	levelText��5   #   $
��0,20q�6   $��level��66   #��[  6C   $��1��6a   $��Center=�6q   $��60(�6�   �� 5    
   -   5        $ 
enemeyText��5        $��20q�6   $��
enemyCount��64   #��[  6F   $��2��6d   $��Right=�6t   �� 5"   
   -   5         ��Name$ 	gameBoard��5"   6   $��3��6   $��3��6%   |�. .+�5#      �� -   5         ��Name$ 	attackPrg��5#      	 �� Left$	 20��6+   

 �� Top$	
 100��6<   $��0��5$      $��40��6    �� RadiusX$ 10��6*    �� RadiusY$ 10��5%      
������� J� Opacity$	 0.5Q�6.   $
��Left=�6<   $	��Top=�6W   �� 5'      $	 20��6   $	
 100��6*   $	��130��5(      $��40��6    $ 10��6,   $ 10��5)      
������ 
�������$��2��5*   #   $
��Left=�67   $��Center=�6R   5-      5.      5/      