   M S B A M L   `   `   `  ����C  ?SpaceWar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SpaceWarSpaceWar  5   	   /clr-namespace:SpaceWar.viewsSpaceWar.views  5	   	       SpaceWar.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:SpaceWar     5   	   /myprojclr-namespace:SpaceWar.views     5	   	     � Title$  
MainWindow��5      $	��800��6   $
��1200��6(    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � AllowsTransparency . $��fonts/#Dosis)�5   	   -  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation$
 None=�5   	   ��5      �� 5   
    �� ImageSource$ images/Background.png��6   .��5      ��    windowStroke#��[  6   ._�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $	��180 �6#   .+�5      � -   5        $��2��5      .+�5      �� $��0,0,-8,0q�6   ���#0a1744.+�5      �� $
��0,20q�6"   .+�5      �� $��SPACEWAR��6$     menuLogo#��[ 64   �� 5       $��E  .  R  .  M��6$     subMenuLogo#��[ 69   5!      �� 5"      -   5        $
��HOME��5"        btnMenu#��[ 6,   6M   �� 5#      -   5        $
��PLAY��5#      #��[ 6,   6M   �� 5$      -   5        $
��SHOP��5$      #��[ 6,   6M   �� 5%      -   5        $��SETTINGS��5%      #��[ 60   6Q   5&      �� 5'      -   5        $
��Exit��5'        btnExit#��[ 6(   6I   5(      � 5)      -   5         �Name$ Screens��5)      .+�5*         SpaceWar.views.Home  $y�Visible=�6      SpaceWar.views.Play  5+      $y�Hidden=�6      SpaceWar.views.Shop  5,      $y�Hidden=�6   !   SpaceWar.views.SettingsView  5-      $y�Hidden=�6#   5.      50      51      52      