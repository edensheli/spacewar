   M S B A M L   `   `   `  ���� C  ?SpaceWar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SpaceWarSpaceWar  /clr-namespace:SpaceWar.viewsSpaceWar.views      SpaceWar.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:SpaceWar     /myprojclr-namespace:SpaceWar.views       � Title$  
MainWindow��$	��800��$
��1200�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � AllowsTransparency . $��fonts/#Dosis)�-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation$
 None=�����  �� ImageSource$ images/Background.png��.����    windowStroke#��[  ._��  � ColumnDefinitions �� $��* ��� $	��180 �.+�� -   $��2��.+��� $��0,0,-8,0q����#0a1744.+��� $
��0,20q�.+��� $��SPACEWAR��  menuLogo#��[ �� $��E  .  R  .  M��  subMenuLogo#��[ �� -   $
��HOME��  btnMenu#��[ �� -   $
��PLAY��#��[ �� -   $
��SHOP��#��[ �� -   $��SETTINGS��#��[ �� -   $
��Exit��  btnExit#��[ � -    �Name$ Screens��.+�   SpaceWar.views.Home  $y�Visible=�   SpaceWar.views.Play  $y�Hidden=�   SpaceWar.views.Shop  $y�Hidden=�!   SpaceWar.views.SettingsView  $y�Hidden=�